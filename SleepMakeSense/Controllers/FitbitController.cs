using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using SleepMakeSense.Models;
using System.Data.SqlClient;
//Fitbit Portable
using Fitbit.Models;
//UserControll Intergration
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using MathNet.Numerics.Statistics;
using Microsoft.AspNet.Identity;
using SleepMakeSense.DataAccessLayer;
using System.Data.Sql;

namespace SleepMakeSense.Controllers
{
    public class FitbitController : Controller
    {
        //
        // GET: /Fitbit/

        private SleepbetaDataContext Db = new SleepbetaDataContext();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /FitbitAuth/
        // Setup - prepare the user redirect to Fitbit.com to prompt them to authorize this app.
        public ActionResult Authorize()
        {
            var appCredentials = new FitbitAppCredentials()
            {
                ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
            };
            //make sure you've set these up in Web.Config under <appSettings>:

            Session["AppCredentials"] = appCredentials;

            //Provide the App Credentials. You get those by registering your app at dev.fitbit.com
            //Configure Fitbit authenticaiton request to perform a callback to this constructor's Callback method
            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");
            string[] scopes = new string[] { "profile", "activity", "sleep", "weight", "nutrition" };

            string authUrl = authenticator.GenerateAuthUrl(scopes, null);

            return Redirect(authUrl);
        }

        //Final step. Take this authorization information and use it in the app
        public async Task<ActionResult> Callback()
        {
            
            FitbitAppCredentials appCredentials = (FitbitAppCredentials)Session["AppCredentials"];

            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");

            string code = Request.Params["code"];

            OAuth2AccessToken accessToken = await authenticator.ExchangeAuthCodeForAccessTokenAsync(code);

            /*Console.WriteLine("Zilu-debug");
            Console.Write(accessToken);
            Console.WriteLine(accessToken);*/

            //Store credentials in FitbitClient. The client in its default implementation manages the Refresh process
            FitbitClient fitbitClient = GetFitbitClient(accessToken);

            //20171025 Pandita: removed saving tokens
            //SyncFitbitCred(accessToken);

            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Sync", "UserDatas"); // redirect to UserdatasController.cs/Sync().


        }

        // 20171026 Pandita: Mejor no poner token en DB
        /*
        // Add user token to the the TokenManagement Table in DB
        private void SyncFitbitCred(OAuth2AccessToken accessToken)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                var userToken = from table in Db.TokenManagement
                                where table.AspNetUserId.Equals(userId)
                                select table;
                bool tokenAvailable = false;

                foreach (TokenManagement token in userToken)
                {
                    if (token.AspNetUserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                    {
                        tokenAvailable = true;
                        token.DateChanged = DateTime.UtcNow;
                        token.Token = accessToken.Token;
                        token.TokenType = accessToken.TokenType;
                        token.ExpiresIn = accessToken.ExpiresIn;
                        token.RefreshToken = accessToken.RefreshToken;
                    }
                }

                if (tokenAvailable == false)
                {
                    TokenManagement token = new TokenManagement()
                    {
                    AspNetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                    DateChanged = DateTime.UtcNow,
                    Token = accessToken.Token,
                    TokenType = accessToken.TokenType,
                    ExpiresIn = accessToken.ExpiresIn,
                    RefreshToken = accessToken.RefreshToken
                };
                    
                    //Db.TokenManagement.InsertOnSubmit(token);
                    Db.TokenManagement.Add(token);
                }


                // 20171022 Pandita: unify with EF
                // Db.SubmitChanges();
                Db.SaveChanges();
            }
        }
        */
        public ActionResult DirectToSync()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                throw new Exception("You Must be Loged in to sync Fitbit Data");
            }
            //Loading Session data when the user has does not have Key creds in their session
            FitbitAppCredentials appCredentials = new FitbitAppCredentials()
            {
                ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
            };
            Session["AppCredentials"] = appCredentials;

            OAuth2AccessToken accessToken = new OAuth2AccessToken();
            /*
            // 20161108 Pandita
            bool fitbitConnected = false;

            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId(); // Get user ID
            IEnumerable <TokenManagement> userToken = from a in Db.TokenManagement // Get user token
                            where a.AspNetUserId.Equals(userId)
                            select a;

            // 20170828 Pandita: BUG!! should not retrieve token from DB, instead, should replace the token in DB by the new token
            // ************************** TO BE REVISED ********************************************************
            foreach (TokenManagement data in userToken)
            {
                if (data.AspNetUserId == userId && data.ExpiresIn == 28800)
                {
                    fitbitConnected = true;
                    accessToken.Token = data.Token;
                    accessToken.TokenType = data.TokenType;
                    accessToken.ExpiresIn = data.ExpiresIn;
                    accessToken.RefreshToken = data.RefreshToken;
                    accessToken.UserId = data.UserId;
                    accessToken.UtcExpirationDate = data.DateChanged.AddSeconds(data.ExpiresIn);
                }
            } 
            
            // 20170213 Pandita: Possibly more than one Token stored for a user? 
            // 20170828 Pandita: should renew the token in DB?
            if (fitbitConnected == true)
            {
                FitbitClient tempSyncClient = GetFitbitClient(accessToken);
                accessToken = tempSyncClient.AccessToken;
                // 20171026 Pandita: removed
                // SyncFitbitCred(accessToken); // 20170213 Pandita: Add token again to DB.TokenManagements?????
                //     return View("Callback");
                return RedirectToAction("Sync", "UserDatas"); // 20170213 Pandita: Should redirect to UserDatas/Sync() or UserDatas/FitbitDataSync(string UserID) ?????
            }*/

            return Authorize(); // If no token is found, direct user to Fitbit authorization page. 
        }




        /// <summary>
        /// In this example we show how to explicitly request a token refresh. However, FitbitClient V2 on its default implementation provide an OOB automatic token refresh.
        /// </summary>
        /// <returns>A refreshed token</returns>
        public async Task<ActionResult> RefreshToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = await fitbitClient.RefreshOAuth2TokenAsync();

            return View("Callback");
        }

        public async Task<ActionResult> TestToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = fitbitClient.AccessToken;

            ViewBag.UserProfile = await fitbitClient.GetUserProfileAsync();

            return View("TestToken");
        }

      


        /// <summary>
        /// HttpClient and hence FitbitClient are designed to be long-lived for the duration of the session. This method ensures only one client is created for the duration of the session.
        /// More info at: http://stackoverflow.com/questions/22560971/what-is-the-overhead-of-creating-a-new-httpclient-per-call-in-a-webapi-client
        /// </summary>
        /// <returns></returns>
        public FitbitClient GetFitbitClient(OAuth2AccessToken accessToken = null)
        {
            if (Session["FitbitClient"] == null)
            {
                if (accessToken != null)
                {
                    var appCredentials = (FitbitAppCredentials)Session["AppCredentials"];
                    FitbitClient client = new FitbitClient(appCredentials, accessToken);
                    Session["FitbitClient"] = client;
                    return client;
                }
                else
                {
                    throw new Exception("First time requesting a FitbitClient from the session you must pass the AccessToken.");
                }

            }
            else
            {
                return (FitbitClient)Session["FitbitClient"];
            }
        }


       
    }
}