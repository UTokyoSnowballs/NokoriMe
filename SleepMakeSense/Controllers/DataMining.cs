using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SleepMakeSense.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace SleepMakeSense.Controllers
{
    public class DataMining
    {

        /*


        private FitbitClient GetFitbitClient(OAuth2AccessToken accessToken = null)
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

        private List<Userdata> DataImport()
        {
            List<Userdata> data = null;
            FitbitClient client = GetFitbitClient();

            string userId = null;
            bool userLogedIn = false;
            Models.Database Db = new Models.Database();
            List<Userdata> queryList = new List<Userdata>();

            DateTime dateStop = DateTime.UtcNow.AddDays(-40);

            userLogedIn = true;
            userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var query = from a in Db.Userdatas
                         where a.AspNetUserId.Equals(userId) && a.DateStamp >= dateStop
                         orderby a.DateStamp
                         select a;

            foreach (Userdata entry in query)
            {
                if (Convert.ToDouble(entry.MinutesAsleep) > 0)
                    data.Add(entry);
            }
   
               return data;
        }

        private List<UserDataDouble>  ConvertToDouble(List<Userdata> input)
        {
            List<UserDataDouble> output = new List<UserDataDouble>();
            foreach (Userdata data in input)
            {
                output.Add(new UserDataDouble()
                {
                    DateStamp = data.DateStamp,
                    MinutesAsleep = Convert.ToDouble(data.MinutesAsleep),
                    MinutesAwake = Convert.ToDouble(data.MinutesAwake),
                    AwakeningsCount = Convert.ToDouble(data.AwakeningsCount),
                    TimeInBed = Convert.ToDouble(data.TimeInBed),
                    MinutesToFallAsleep = Convert.ToDouble(data.MinutesToFallAsleep),
                    MinutesAfterWakeup = Convert.ToDouble(data.MinutesAfterWakeup),
                    SleepEfficiency = Convert.ToDouble(data.SleepEfficiency),
                    WakeUpFreshness = Convert.ToDouble(data.WakeUpFreshness),
                    Coffee = Convert.ToDouble(data.Coffee),
                    CoffeeTime = Convert.ToDouble(data.CoffeeTime),
                    Alcohol = Convert.ToDouble(data.Alcohol),
                    Mood = Convert.ToDouble(data.Mood),
                    Stress = Convert.ToDouble(data.Stress),
                    Tiredness = Convert.ToDouble(data.Tiredness),
                    Dream = Convert.ToDouble(data.Dream),
                    DigitalDev = Convert.ToDouble(data.DiaryData),
                    Light = Convert.ToDouble(data.Light),
                    NapDuration = Convert.ToDouble(data.NapDuration),
                    NapTime = Convert.ToDouble(data.NapTime),
                    SocialActivity = Convert.ToDouble(data.SocialActivity),
                    DinnerTime = Convert.ToDouble(data.DinnerTime),
                    AmbientTemp = Convert.ToDouble(data.AmbientTemp),
                    AmbientHumd = Convert.ToDouble(data.AmbientHumd),
                    ExerciseTime = Convert.ToDouble(data.ExerciseTime),
                    BodyTemp = Convert.ToDouble(data.BodyTemp),
                    Hormone = Convert.ToDouble(data.Hormone),
                    CaloriesIn = Convert.ToDouble(data.CaloriesIn),
                    Water = Convert.ToDouble(data.Water),
                    CaloriesOut = Convert.ToDouble(data.CaloriesOut),
                    Steps = Convert.ToDouble(data.Steps),
                    Distance = Convert.ToDouble(data.Distance),
                    MinutesSedentary = Convert.ToDouble(data.MinutesSedentary),
                    MinutesLightlyActive = Convert.ToDouble(data.MinutesLightlyActive),
                    MinutesFairlyActive = Convert.ToDouble(data.MinutesFairlyActive),
                    MinutesVeryActive = Convert.ToDouble(data.MinutesVeryActive),
                    ActivityCalories = Convert.ToDouble(data.ActivityCalories),
                    TimeEnteredBed = Convert.ToDouble(data.TimeEnteredBed),
                    Weight = Convert.ToDouble(data.Weight),
                    BMI = Convert.ToDouble(data.BMI),
                    Fat = Convert.ToDouble(data.Fat)
                }
                );
            }
            return output;
        }

        private UserDataCounter  CountData (List<UserDataDouble> input)
        {
            UserDataCounter output = new UserDataCounter();

            foreach (UserDataDouble data in input)
            {
                // Adding +1 to counter for evey varible
                if (data.WakeUpFreshness >= 0) output.CNTwakeUpFreshness++;
                if (data.Coffee >= 0) output.CNTcoffee++;
                if (data.CoffeeTime > 0) output.CNTcoffeeTime++;
                if (data.Alcohol >= 0) output.CNTalcohol++;
                if (data.Mood >= 0) output.CNTmood++;
                if (data.Stress >= 0) output.CNTstress++;
                if (data.Tiredness >= 0) output.CNTtiredness++;
                if (data.Dream >= 0) output.CNTdream++;
                if (data.DigitalDev >= 0) output.CNTdigitalDev++;
                if (data.Light >= 0) output.CNTlight++;
                if (data.NapDuration > 0) output.CNTnapDuration++;
                if (data.NapTime > 0) output.CNTnapTime++;
                if (data.SocialActivity >= 0) output.CNTsocialActivity++;
                if (data.DinnerTime > 0) output.CNTdinnerTime++;
                if (data.ExerciseTime > 0) output.CNTexerciseTime++;
                if (data.AmbientTemp > 0) output.CNTambientTemp++;
                if (data.AmbientHumd > 0) output.CNTambientHumd++;
                if (data.BodyTemp > 0) output.CNTbodyTemp++;
                if (data.Hormone > 0) output.CNThormone++;
                if (data.CaloriesIn > 0) output.CNTcaloriesIn++;
                if (data.Water > 0 ) output.CNTwater++;
                if (data.CaloriesOut > 0 )output.CNTcaloriesOut++;
                if (data.Steps > 0) output.CNTsteps++;
                if (data.Weight > 0) output.CNTweight++;
                if (data.Fat > 0) output.CNTfat++;
            }

            return output;
        }


        */
    }
}