using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using SleepMakeSense.Models;

namespace SleepMakeSense
{
    public partial class Startup
    {
        //For more information about the authentication settings , http:? //go.microsoft.com/fwlink/ Please refer to the LinkId = 301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // DB context to use only one request per instance , user manager , and configure the sign-in Manager .
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Application uses a Cookie, so that you can store the user's information who sign in
            // In addition , the information about the user to log in using a third-party login provider , so that you can temporarily saved using the Cookie
            // Set of sign -in Cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Set to validate the security stamp when the user logs in .
                    // This is one of the security features , will be used to add an external login to and account when you change the password .
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Set to temporarily save the user information at the time to confirm the second element in the two-factor authentication process
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Set to store a second login verification elements (such as telephone and e-mail ) .
            // When this option is turned on , the second step of the confirmation in the login process , will be stored on the device that was used to log in .
            // This is , "remember this account " at the time of login is similar to the option .
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following line to enable the login you use a third-party login provider
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}