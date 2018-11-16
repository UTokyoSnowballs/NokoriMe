using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
 
using Excel = Microsoft.Office.Interop.Excel;

//Refer to Fitbit Library
using Fitbit.Models;
using SleepMakeSense.Models;
using SleepMakeSense.DataAccessLayer;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

//Refer to MathNet.Numerics Library for statistical analysis
using MathNet.Numerics.Statistics;


namespace SleepMakeSense.Controllers
{

    public class UserdatasController : Controller
    {

        // 20161105 Pandita
        // private ApplicationDbContext db = new ApplicationDbContext();
        private SleepbetaDataContext Db = new SleepbetaDataContext();


        /*
        // GET: Userdatas
        public ActionResult Index()
        {
            // 20161107 Pandita
            // return View(db.Userdatas.ToList());
            return View(Db.Userdatas.ToList());

        }

        // GET: Userdatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            var userdata = Db.Userdatas.Find(id);

            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // GET: Userdatas/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult FactorList()
        {
            return View("FactorList");
        }

        // POST: Userdatas/Create
        // To prevent excessive posting attack , please enable the specific property to be bound to.
        // For more information , http: Please refer to the //go.microsoft.com/fwlink/ LinkId = 317598?.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Steps, MinutesAsleep, DateStamp, Water, Distance, MinutesSedentary, MinutesVeryActive, AwakeningsCount, TimeEnteredBed, Weight, MinutesAwake, TimeInBed, MinutesToFallAsleep, MinutesAfterWakeUp, CaloriesIn, CaloriesOut, MinutesLightlyActive, MinutesFairlyActive, ActivityCalories, BMI,Fat,SleepEfficiency,WakeUpFreshness,Coffee,CoffeeTime,Alcohol,Mood,Stress,Tiredness,Dream,DigitalDev, Light,NapDuration,NapTime,SocialFamily,DinnerTime,AmbientTemp,AmbientHumd,ExerciseTime,BodyTemp,Hormone,FitbitData,DiaryDataNight,WatchTV,ExerciseDuration,ExerciseIntensity,ExerciseType,Snack,Snack2,Job,Job2,Phone,SleepDiary,Music,MusicDuration,MusicType,SocialMedia,Games,Assessment,AspNetUserId")] Userdata userdata)
        {
            var data = userdata;
            if (ModelState.IsValid)
            {
                // 20161107 Pandita
                // db.Userdatas.Add(data);
                // db.SaveChanges();

                Db.Userdatas.Add(data);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userdata);
        }

        // GET: Userdatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            var userdata = Db.Userdatas.Find(id);

            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }

        // POST: Userdatas/Edit/5
        // To prevent excessive posting attack , please enable the specific property to be bound to 
        // For more information , http: Please refer to the //go.microsoft.com/fwlink/ LinkId = 317598?.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Steps, MinutesAsleep, DateStamp, Water, Distance, MinutesSedentary, MinutesVeryActive, AwakeningsCount, TimeEnteredBed, Weight, MinutesAwake, TimeInBed, MinutesToFallAsleep, MinutesAfterWakeUp, CaloriesIn, CaloriesOut, MinutesLightlyActive, MinutesFairlyActive, ActivityCalories, BMI,Fat,SleepEfficiency,WakeUpFreshness,Coffee,CoffeeTime,Alcohol,Mood,Stress,Tiredness,Dream,DigitalDev, Light,NapDuration,NapTime,SocialFamily,DinnerTime,AmbientTemp,AmbientHumd,ExerciseTime,BodyTemp,Hormone,FitbitData,DiaryDataNight,WatchTV,ExerciseDuration,ExerciseIntensity,ExerciseType,Snack,Snack2,Job,Job2,Phone,SleepDiary,Music,MusicDuration,MusicType,SocialMedia,Games,Assessment,AspNetUserId")] Userdata userdata)
        {
            if (ModelState.IsValid)
            {
                // 20161107 Pandita
                // db.Entry(userdata).State = EntityState.Modified;
                // db.SaveChanges();

                Db.Entry(userdata).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userdata);
        }

        // GET: Userdatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 20161107 Pandita
            // var userdata = db.Userdatas.Find(id);
            var userdata = Db.Userdatas.Find(id);

            if (userdata == null)
            {
                return HttpNotFound();
            }
            return View(userdata);
        }
       
        // POST: Userdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var userdata = Db.Userdatas.Find(id);
            Db.Userdatas.Remove(userdata);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }
         */

       



        // For releasing "unmanaged" resources(for example, sockets, file handles, Bitmap handles, etc), 
        // and if it's being called outside a finalizer (that's what the disposing flag signifies, BTW), 
        // for disposing other IDisposable objects it holds that are no longer useful. 
        // can be found throughout the .net framework
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();

            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// HttpClient and hence FitbitClient are designed to be long-lived for the duration of the session. This method ensures only one client is created for the duration of the session.
        /// More info at: http://stackoverflow.com/questions/22560971/what-is-the-overhead-of-creating-a-new-httpclient-per-call-in-a-webapi-client
        /// </summary>
        /// <returns></returns>
        /// 


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

        private DateTime FindingDateStop(string userId)
        {
            // Pandita 20170824: going back too many days cause Gateway Timeout error? Then let's just go back 40 days
            // DateTime dateStop = DateTime.UtcNow.Date.AddDays(-365);
            DateTime dateStop = DateTime.UtcNow.Date.AddDays(-60);


            IEnumerable<FitbitData> lastSyncedData = from table in Db.FitbitData
                                                     where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                                                     select table;

            foreach (FitbitData daysData in lastSyncedData)
            {
                if (daysData.DateStamp >= dateStop) dateStop = daysData.DateStamp.AddDays(1);
            }
            return dateStop;
        }


        private async Task<ActionResult> FitbitDataSync(string userId)
        {

            FitbitClient client = GetFitbitClient();
            DateTime dateStop = FindingDateStop(userId);

            // 20170302 Pandita: use local time
            DateTime baseTime = DateTime.UtcNow;
            baseTime = DateTime.SpecifyKind(baseTime, DateTimeKind.Unspecified);

            TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time").GetUtcOffset(baseTime); // offset value is between -14.0 (towards easthemisphere) ~ 14.0 (towards westhemisphere)
            DateTimeOffset sourceTime = new DateTimeOffset(baseTime, -offset);
            DateTime dateNow = sourceTime.LocalDateTime;

            bool syncRequired = false;

            if (dateStop < dateNow)
            {
                syncRequired = true;
            }

            if (syncRequired)
            {
                List<FitbitData> fitbitInputDatas = new List<FitbitData>();

                //Each set is 1 call - calling 40 or 60 only increase the size by a small amount
                //21 calls
                var minutesAsleep = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAsleep, dateStop, dateNow);
                var minutesAwake = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAwake, dateStop, dateNow);
                var awakeningsCount = await client.GetTimeSeriesAsync(TimeSeriesResourceType.AwakeningsCount, dateStop, dateNow);
                var timeInBed = await client.GetTimeSeriesAsync(TimeSeriesResourceType.TimeInBed, dateStop, dateNow);
                var minutesToFallAsleep = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesToFallAsleep, dateStop, dateNow);
                var minutesAfterWakeup = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesAfterWakeup, dateStop, dateNow);
                var sleepEfficiency = await client.GetTimeSeriesAsync(TimeSeriesResourceType.SleepEfficiency, dateStop, dateNow);
                var caloriesIn = await client.GetTimeSeriesAsync(TimeSeriesResourceType.CaloriesIn, dateStop, dateNow);
                var water = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Water, dateStop, dateNow);
                var caloriesOut = await client.GetTimeSeriesAsync(TimeSeriesResourceType.CaloriesOut, dateStop, dateNow);
                var steps = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Steps, dateStop, dateNow);
                var distance = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Distance, dateStop, dateNow);
                var minutesSedentary = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesSedentary, dateStop, dateNow);
                var minutesLightlyActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesLightlyActive, dateStop, dateNow);
                var minutesFairlyActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesFairlyActive, dateStop, dateNow);
                var minutesVeryActive = await client.GetTimeSeriesAsync(TimeSeriesResourceType.MinutesVeryActive, dateStop, dateNow);
                var activityCalories = await client.GetTimeSeriesAsync(TimeSeriesResourceType.ActivityCalories, dateStop, dateNow);
                var timeEnteredBed = await client.GetTimeSeriesAsync(TimeSeriesResourceType.TimeEnteredBed, dateStop, dateNow);
                var weight = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Weight, dateStop, dateNow);
                var bmi = await client.GetTimeSeriesAsync(TimeSeriesResourceType.BMI, dateStop, dateNow);
                var fat = await client.GetTimeSeriesAsync(TimeSeriesResourceType.Fat, dateStop, dateNow);

                foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAsleep.DataList)
                {

                    if (Convert.ToDouble(data.Value) > 0)  // Remove entries with no sleep log (e.g. due to battery issue)
                    {
                        fitbitInputDatas.Add(new FitbitData()
                        {
                            //Id = Guid.NewGuid(),
                            // DateStamp = data.DateTime.Date.AddDays(-1),
                            DateStamp = data.DateTime.Date, // In QUT study, participants will fill in the diary in the morning, not before going to bed. 
                            MinutesAsleep = data.Value,
                            MinutesAwake = null,
                            AwakeningsCount = null,
                            TimeInBed = null,
                            MinutesToFallAsleep = null,
                            MinutesAfterWakeup = null,
                            SleepEfficiency = null,
                            CaloriesIn = null,
                            Water = null,
                            CaloriesOut = null,
                            Steps = null,
                            Distance = null,
                            MinutesSedentary = null,
                            MinutesLightlyActive = null,
                            MinutesFairlyActive = null,
                            MinutesVeryActive = null,
                            ActivityCalories = null,
                            TimeEnteredBed = null,
                            Weight = null,
                            BMI = null,
                            Fat = null,
                            AspNetUserId = userId
                        });
                    }
                }


                //Each set is 1 call - calling 40 or 60 only increase the size by a small amount
                //21 calls

                    foreach (FitbitData fitbitInputData in fitbitInputDatas)
                {
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAwake.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesAwake = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in awakeningsCount.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.AwakeningsCount = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in timeInBed.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.TimeInBed = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesToFallAsleep.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesToFallAsleep = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesAfterWakeup.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesAfterWakeup = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in sleepEfficiency.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.SleepEfficiency = data.Value;
                    }

                    // Potential impacting factors; need filter out untracked factors.
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in caloriesIn.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.CaloriesIn = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in water.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.Water = data.Value;
                    }
                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in caloriesOut.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.CaloriesOut = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in steps.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.Steps = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in distance.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.Distance = data.Value;
                    }


                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesSedentary.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesSedentary = data.Value;
                        //if (Convert.ToDouble(item.MinutesSedentary) > 0) CNTminutesSedentary++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesLightlyActive.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesLightlyActive = data.Value;
                        //if (Convert.ToDouble(item.MinutesLightlyActive) > 0) CNTminutesLightlyActive++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesFairlyActive.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesFairlyActive = data.Value;
                        //if (Convert.ToDouble(item.MinutesFairlyActive) > 0) CNTminutesFairlyActive++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in minutesVeryActive.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.MinutesVeryActive = data.Value;
                        //if (Convert.ToDouble(item.MinutesVeryActive) > 0) CNTminutesVeryActive++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in activityCalories.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.ActivityCalories = data.Value;
                        //if (Convert.ToDouble(item.ActivityCalories) > 0) CNTactivityCalories++; 
                    }


                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in timeEnteredBed.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.TimeEnteredBed = data.Value;
                        //if (Convert.ToDouble(item.TimeEnteredBed) > 0) CNTtimeEnteredBed++; 
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in weight.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.Weight = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in bmi.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.BMI = data.Value;
                    }

                    foreach (Fitbit.Models.TimeSeriesDataList.Data data in fat.DataList.Where(data => data.DateTime == fitbitInputData.DateStamp))
                    {
                        fitbitInputData.Fat = data.Value;
                    }
                }
                //Comparing Saved data with new data

                foreach (FitbitData data in fitbitInputDatas)
                {
                    //Db.FitbitData.InsertOnSubmit(data);
                    Db.FitbitData.Add(data);
                }

                //Db.SubmitChanges();
                Db.SaveChanges();
            }
            ViewBag.FitbitSynced = true;

            return View();
        }


        public int reverseScore(int q)
        {

            if (q == 5) {
                q = q - 4; }
            else if (q == 4) { q = q - 2; }
            else if (q == 2) { q = q + 2; }
            else if(q==1) { q = q + 4; }
            return q;
            
        }

        public int CalculatePercievedStress(string q1, string q2, string q3, string q4, string q5, string q6, string q7, string q8, string q9, string q10) {
            var StressScore = 0;
            
            if ( q1 != null && q2 != null && q3 != null && q4 != null && q5 != null && q6 != null && q7 != null && q8 != null && q9 != null && q10 != null ){
                var Rq4 = reverseScore(Int32.Parse(q4));
                var Rq5 = reverseScore(Int32.Parse(q5));
                var Rq7 = reverseScore(Int32.Parse(q7));
                var Rq8 = reverseScore(Int32.Parse(q8));



             StressScore = Int32.Parse(q1) + Int32.Parse(q2) + Int32.Parse(q3) + Rq4 + Rq5 + Int32.Parse(q6) + Rq7 + Rq8 + Int32.Parse(q9) + Int32.Parse(q10);

            }
            else { }

            return StressScore;
        }  

    public async Task<ActionResult> Sync()
        {

            // Get numofDays data entries to correlation analysis
            // 20170214 Pandita: I feel this parameter can be tweeked, but 40 sounds like a good value for the time being
            int numOfDays = 40;

            // 20170302 Pandita: use local time
            DateTime baseTime = DateTime.UtcNow;
            baseTime = DateTime.SpecifyKind(baseTime, DateTimeKind.Unspecified);

            TimeSpan offset = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time").GetUtcOffset(baseTime); // offset value is between -14.0 (towards easthemisphere) ~ 14.0 (towards westhemisphere)
            DateTimeOffset sourceTime = new DateTimeOffset(baseTime, -offset);
            DateTime dateNow = sourceTime.LocalDateTime;

            //Comment out the bellow line to disable getting the current logged in user data
            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //UnComment the bellow line to select a specific use to show the users sync page screen
            //string userId = "862a567a-a845-4d48-a2c2-91b2e7627924";

            List<Userdata> userDatas = UserDatas(userId, numOfDays);
            // bool todaySync = true;
            bool todaySync = false;
            ViewBag.todaySync = true;


         

            foreach (Userdata userData in userDatas)
            {
                if (userData.DateStamp >= dateNow)
                {
                    todaySync = true;
                }
            }



            // 20170213 Pandita: If today not synced, sync data; if today already synced, not sync data??? 
            // But, it kept on syncing the latest day!!! Also, need to check if an entry for a certain day already exists to avoid writing multiple entries for a same day.
            if (!todaySync)
            {
                await FitbitDataSync(userId);
            }

            SyncViewModel model = DataModelCreation(userDatas);
            return View(model);

        }



        /// <summary>
        /// Handels all data retrieval and outputs the user data
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

            // 20170213 Pandita: merge Fitbit data and diary data for correlation analysis
        private List<Userdata> UserDatas(string userId, int numOfDays)
        {
            //Item Stup
            DateTime dateStop = DateTime.UtcNow.Date.AddDays(-numOfDays);
            List<Userdata> userDatas = new List<Userdata>();

            //Data retieval
            var diaryDatas = from table in Db.DiaryData
                             where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                             orderby table.DateStamp
                             select table;

            var fitbitDatas = from table in Db.FitbitData
                              where table.AspNetUserId.Equals(userId) && table.DateStamp >= dateStop
                              orderby table.DateStamp
                              select table;

        //    foreach (DiaryData diaryData in diaryDatas)
        //    {
        //        userDatas.Add(new Userdata()
        //        {


        //            // 31 questions in total
        //            //added percieved stress level Questions
        //            Id = diaryData.Id,
        //            DateStamp = diaryData.DateStamp,
        //            PerceivedStress = Convert.ToDouble(diaryData.pss1)



        //        });
        //}

          
        //    foreach (Userdata userdata in userDatas)
        //    {
        //       foreach (FitbitData fitbitData in fitbitDatas.Where(fitbitData => DbFunctions.TruncateTime(fitbitData.DateStamp)  == DbFunctions.TruncateTime(userdata.DateStamp)))
        //        {

        //            userdata.MinutesAsleep = Convert.ToDouble(fitbitData.MinutesAsleep);
                    
        //        }
        //    }




            foreach (FitbitData fitbitdata in fitbitDatas)
            {
                userDatas.Add(new Userdata()
                {
                    Id = fitbitdata.Id,
                    DateStamp = fitbitdata.DateStamp,
                    MinutesAsleep = Convert.ToDouble(fitbitdata.MinutesAsleep),
                    MinutesAwake = Convert.ToDouble(fitbitdata.MinutesAwake),
                    AwakeningsCount = Convert.ToDouble(fitbitdata.AwakeningsCount),
                    TimeInBed = Convert.ToDouble(fitbitdata.TimeInBed),
                    //Minutestfallasleep = Convert.ToDouble(fitbitdata.MinutesToFallAsleep),
                    //minutesafterwakeup = Convert.ToDouble(fitbitdata.minutesafterwakeup),
                    SleepEfficiency = Convert.ToDouble(fitbitdata.SleepEfficiency),
                    //caloriesin = Convert.ToDouble(fitbitdata.caloriesin),
                    CaloriesOut = Convert.ToDouble(fitbitdata.CaloriesOut),
                    //water = convert.todouble(fitbitdata.water),
                   Steps = Convert.ToDouble(fitbitdata.Steps),
                    Distance = Convert.ToDouble(fitbitdata.Distance),
                    MinutesSedentary = Convert.ToDouble(fitbitdata.MinutesSedentary),
                    MinutesLightlyActive = Convert.ToDouble(fitbitdata.MinutesLightlyActive),
                    MinutesFairlyActive = Convert.ToDouble(fitbitdata.MinutesFairlyActive),
                    MinutesVeryActive = Convert.ToDouble(fitbitdata.MinutesVeryActive),
                    ActivityCalories = Convert.ToDouble(fitbitdata.ActivityCalories),
                    // userdata.timeenteredbed = timespan.parse(fitbitdata.timeenteredbed); //was getting null exception error

                   // weight = convert.todouble(fitbitdata.weight),
                   // bmi = convert.todouble(fitbitdata.bmi),
                   // fat = convert.todouble(fitbitdata.fat)
                });
            }



            foreach (Userdata userdata in userDatas)
            {
                foreach (DiaryData diaryData in diaryDatas.Where(diaryData => DbFunctions.TruncateTime(diaryData.DateStamp) == DbFunctions.TruncateTime(userdata.DateStamp))) 
                {
                    // 31 questions in total
                    //added percieved stress level questions
                    userdata.PerceivedStress = Convert.ToDouble(CalculatePercievedStress(diaryData.pss1, diaryData.pss2, diaryData.pss3, diaryData.pss4, diaryData.pss5, diaryData.pss6, diaryData.pss7, diaryData.pss8, diaryData.pss9, diaryData.pss10));

                    userdata.pss1 = Convert.ToDouble(diaryData.pss1);
                    userdata.pss2 = Convert.ToDouble(diaryData.pss2);
                    userdata.pss3 = Convert.ToDouble(diaryData.pss3);
                    userdata.pss4 = Convert.ToDouble(diaryData.pss4);
                    userdata.pss5 = Convert.ToDouble(diaryData.pss5);
                    userdata.pss6 = Convert.ToDouble(diaryData.pss6);
                    userdata.pss7 = Convert.ToDouble(diaryData.pss7);
                    userdata.pss8 = Convert.ToDouble(diaryData.pss8);
                    userdata.pss9 = Convert.ToDouble(diaryData.pss9);
                    userdata.pss10 = Convert.ToDouble(diaryData.pss10);



                    /*userdata.wakeupfreshness = convert.todouble(diarydata.wakeupfreshness);
                    userdata.mood = convert.todouble(diarydata.mood);
                    userdata.stress = convert.todouble(diarydata.stress);
                    userdata.tiredness = convert.todouble(diarydata.tiredness);
                    userdata.dream = convert.todouble(diarydata.dream);
                    userdata.bodytemp = convert.todouble(diarydata.bodytemp);
                    userdata.hormone = convert.todouble(diarydata.hormone);
                    userdata.schoolstress = convert.todouble(diarydata.schoolstress);
                    userdata.coffeeamt = convert.todouble(diarydata.coffeeamt);
                    userdata.coffeetime = diarydata.datestamp.addhours(convert.toint32(diarydata.coffeetime));
                    userdata.alcoholamt = convert.todouble(diarydata.alcoholamt);
                    userdata.alcoholtime = diarydata.datestamp.addhours(convert.toint32(diarydata.alcoholtime));
                    userdata.naptime = diarydata.datestamp.addhours(convert.toint32(diarydata.naptime));
                    userdata.napduration = convert.todouble(diarydata.napduration);
                    userdata.digdeviceduration = convert.todouble(diarydata.digdeviceduration);
                    userdata.gamesduration = convert.todouble(diarydata.gamesduration);
                    // 20170214 pandita: added socialfamily, socialfriend, and socialmedia
                    userdata.socialfamily = convert.todouble(diarydata.socialfamily);
                    userdata.socialfriend = convert.todouble(diarydata.socialfriend);
                    userdata.socialmedia = convert.todouble(diarydata.socialmedia);

                    userdata.musicduration = convert.todouble(diarydata.musicduration);
                    userdata.tvduration = convert.todouble(diarydata.tvduration);
                    userdata.worktime = diarydata.datestamp.addhours(convert.toint32(diarydata.worktime));
                    userdata.workduration = convert.todouble(diarydata.workduration);
                    userdata.exerciseduration = convert.todouble(diarydata.exerciseduration);
                    userdata.exerciseintensity = convert.todouble(diarydata.exerciseintensity);
                    userdata.dinnertime = diarydata.datestamp.addhours(convert.toint32(diarydata.dinnertime));
                    userdata.snacktime = diarydata.datestamp.addhours(convert.toint32(diarydata.snacktime));
                    userdata.ambienttemp = convert.todouble(diarydata.ambienttemp);
                    userdata.ambienthumd = convert.todouble(diarydata.ambienthumd);
                    userdata.light = convert.todouble(diarydata.light);
                    userdata.sunrisetime = diarydata.datestamp.addhours(convert.toint32(diarydata.sunrisetime));
                    userdata.sunsettime = diarydata.datestamp.addhours(convert.toint32(diarydata.sunsettime));*/
                }
            }
            return userDatas;
        }

       

        // 20170213 Pandita: Prepare data to be passed to front end
        private SyncViewModel DataModelCreation(List<Userdata> userDatas)
        {
            /*Fixing the data to make it easier to work on in the future.
             * Thinking of making this into a differnt class and splitting it into smaller methods as alot of the code is repetitive
             * Just need to figure out a way to be able to subsite the variable in the code and change to a different varible on each run
             * EG.. steps, then go to distance and use the same generic code
             * It could be split into 3 types, int, time and bool
             * 
             * Update on this thought - should the wakeup freashness be redesigned?
            */

            //Part of the redesign - this will allow the datamining method to flick through all of the classes with less commplication

            SyncViewModel syncViewModel = new SyncViewModel();
            syncViewModel.UserData = new List<Userdata>();
            //added stresscorrelation list
            List<CorrList> StressCorrList = new List<CorrList>();
            List<CorrList> minutesAsleepCorrList = new List<CorrList>();
            List<CorrList> awakeCountCorrList = new List<CorrList>();
            List<CorrList> sleepEffiencyCorrList = new List<CorrList>();
            List<CorrList> ExerciceCorrList = new List<CorrList>();

            ViewBag.FitbitSynced = true;


            //Fitbit Data Counters
            int CNTSteps = 0, CNTDistance = 0, CNTMinutesSedentary = 0, CNTMinutesLightlyActive = 0,
                CNTMinutesFairlyActive = 0, CNTMinutesVeryActive = 0, CNTWater = 0,
                CNTCaloriesOut = 0, CNTActivityCalories = 0, CNTWeight = 0, CNTBMI = 0, CNTFat = 0, CNTCaloriesIn = 0;

            

            //Diary Data Counters
            int CNTWakeUpFreshness = 0, CNTMood = 0, CNTStress = 0, CNTTiredness = 0, CNTPercievedStress = 0, 
                CNTDream = 0, CNTBodyTemp = 0, CNTHormone = 0,
                CNTSchoolStress = 0,
                CNTCoffeeAmt = 0, CNTCoffeeTime = 0, CNTAlcoholAmt = 0, CNTAlcoholTime = 0,
                CNTNapTime = 0, CNTNapDuration = 0,
                CNTDigDeviceDuration = 0, CNTGamesDuration = 0, CNTSocialFriend = 0, CNTSocialFamily = 0, CNTSocialMedia = 0, CNTMusicDuration = 0, CNTTVDuration = 0,
                CNTWorkTime = 0, CNTWorkDuration = 0, CNTExerciseDuration = 0, CNTExerciseIntensity = 0,
                CNTDinnerTime = 0, CNTSnackTime = 0,
                CNTAmbientTemp = 0, CNTAmbientHumd = 0, CNTLight = 0, CNTSunRiseTime = 0, CNTSunSetTime = 0 ;

            foreach (Userdata userData in userDatas)
            {
                //Fitbit Data Counter
                if (userData.Steps > 0) CNTSteps++;
                if (userData.Distance >= 0) CNTDistance++;
                if (userData.MinutesSedentary > 0) CNTMinutesSedentary++;
                if (userData.MinutesLightlyActive > 0) CNTMinutesLightlyActive++;
                if (userData.MinutesFairlyActive > 0) CNTMinutesFairlyActive++;
                if (userData.MinutesVeryActive > 0) CNTMinutesVeryActive++;
                if (userData.Water > 0) CNTWater++;
                if (userData.CaloriesIn > 0) CNTCaloriesIn++;
                if (userData.CaloriesOut > 0) CNTCaloriesOut++;
                if (userData.ActivityCalories > 0) CNTActivityCalories++;
                if (userData.Weight > 0) CNTWeight++;
                if (userData.BMI > 0) CNTBMI++;
                if (userData.Fat > 0) CNTFat++;



                //Diary Data Counter
                if (userData.PerceivedStress > 0) CNTPercievedStress++;
               /* if (userData.pss1 > 0) CNTPss1++;
                if (userData.pss2 > 0) CNTPss2++;
                if (userData.pss3 > 0) CNTPss3++;
                if (userData.pss4 > 0) CNTPss4++;
                if (userData.pss5 > 0) CNTPss5++;
                if (userData.pss6 > 0) CNTPss6++;
                if (userData.pss7 > 0) CNTPss7++;
                if (userData.pss8 > 0) CNTPss8++;
                if (userData.pss9 > 0) CNTPss9++;
                if (userData.pss10 > 0) CNTPss10++;*/

                if (userData.WakeUpFreshness > 0) CNTWakeUpFreshness++;
                if (userData.Mood > 0) CNTMood++;
                if (userData.Stress > 0) CNTStress++;
                if (userData.Tiredness > 0) CNTTiredness++;
                if (userData.Dream > 0) CNTDream++;
                if (userData.BodyTemp > 0) CNTBodyTemp++;
                if (userData.Hormone > 0) CNTHormone++;
                if (userData.SchoolStress > 0) CNTSchoolStress++;
                if (userData.CoffeeAmt >= 0) CNTCoffeeAmt++;
                if (userData.CoffeeTime != null) CNTCoffeeTime++;
                if (userData.AlcoholAmt > 0) CNTAlcoholAmt++;
                if (userData.AlcoholTime != null) CNTAlcoholTime++;
                if (userData.NapTime != null) CNTNapTime++;
                if (userData.NapDuration > 0) CNTNapDuration++;
                if (userData.DigDeviceDuration > 0) CNTDigDeviceDuration++;
                if (userData.GamesDuration > 0) CNTGamesDuration++;
                if (userData.SocialFriend > 0) CNTSocialFriend++;
                if (userData.SocialFamily > 0) CNTSocialFamily++;
                if (userData.SocialMedia > 0) CNTSocialMedia++;  
                if (userData.MusicDuration >= 0) CNTMusicDuration++;
                if (userData.TVDuration > 0) CNTTVDuration++;
                if (userData.WorkTime != null) CNTWorkTime++;
                if (userData.ExerciseDuration > 0) CNTExerciseDuration++;
                if (userData.ExerciseIntensity > 0) CNTExerciseIntensity++;
                if (userData.DinnerTime != null) CNTDinnerTime++;
                if (userData.SnackTime != null) CNTSnackTime++;
                if (userData.AmbientTemp > 0) CNTAmbientTemp++;
                if (userData.AmbientHumd > 0) CNTAmbientHumd++;
                if (userData.Light > 0) CNTLight++;
                if (userData.SunRiseTime != null) CNTSunRiseTime++;
                if (userData.SunSetTime != null) CNTSunSetTime++;

                //To Ignore anything with 0

                // 20171214 Zilu: You probably need to modify the following condition cuz 
                // you focus on stress, not sleep. 
                // There may be some entries with 0 MinutesAsleep (e.g. simply no sleep data from Fitbit),
                // but if the stress data is logged, then this entry should be added to the userData.  
                
                if (userData.MinutesAsleep > 0)
                {
                    syncViewModel.UserData.Add(userData);
                }/*
                if (userData.PerceivedStress > 0 || userData.pss1 > 0)
                {
                    syncViewModel.UserData.Add(userData);
                }*/

                //All - I like the idea of seeing when data is not present


            }


            int countOfDaysData = userDatas.Count;


            //adding stress
            double[] PercievedStress = new double[countOfDaysData];
            //double[] PercievedStress = new double[countOfDaysData];

            double[] MinutesAsleep = new double[countOfDaysData];
            double[] MinutesAwake = new double[countOfDaysData];
            double[] AwakeningsCount = new double[countOfDaysData];
            double[] MinutesToFallAsleep = new double[countOfDaysData];
            double[] SleepEfficiency = new double[countOfDaysData];
            double[] ActivityCalories = new double[countOfDaysData];
            double[] MinutesSedentary = new double[countOfDaysData];
            double[] MinutesLightlyActive = new double[countOfDaysData];
            double[] MinutesFairlyActive = new double[countOfDaysData];
            double[] MinutesVeryActive = new double[countOfDaysData];

            // should correlate to all tracked factors, including the ones tracked using diary  

            //No idea what this is ment to do :/ - Sean
            double[] WakeUpFreshnessSteps = new double[CNTSteps];
            double[] WakeUpFreshnessDistance = new double[CNTDistance];
            double[] WakeUpFreshnessMinutesSedentary = new double[CNTMinutesSedentary];
            double[] WakeUpFreshnessMinutesLightlyActive = new double[CNTMinutesLightlyActive];
            double[] WakeUpFreshnessMinutesFairlyActive = new double[CNTMinutesFairlyActive];
            double[] WakeUpFreshnessMinutesVeryActive = new double[CNTMinutesVeryActive];
            double[] WakeUpFreshnessWater = new double[CNTWater];
            double[] WakeUpFreshnessCaloriesIn = new double[CNTCaloriesIn];
            double[] WakeUpFreshnessCaloriesOut = new double[CNTCaloriesOut];
            double[] WakeUpFreshnessActivityCalories = new double[CNTActivityCalories];
            double[] WakeUpFreshnessWeight = new double[CNTWeight];
            double[] WakeUpFreshnessBMI = new double[CNTBMI];
            double[] WakeUpFreshnessFat = new double[CNTFat];

            double[] WakeUpFreshnessMood = new double[CNTMood];
            double[] WakeUpFreshnessStress = new double[CNTStress];
            double[] WakeUpFreshnessTiredness = new double[CNTTiredness];
            double[] WakeUpFreshnessDream = new double[CNTDream];
            double[] WakeUpFreshnessBodyTemp = new double[CNTBodyTemp];
            double[] WakeUpFreshnessHormone = new double[CNTHormone];
            double[] WakeUpFreshnessSchoolStress = new double[CNTHormone];
            double[] WakeUpFreshnessCoffeeAmt = new double[CNTCoffeeAmt];
            double[] WakeUpFreshnessCoffeeTime = new double[CNTCoffeeTime];
            double[] WakeUpFreshnessAlcoholAmt = new double[CNTAlcoholAmt];
            double[] WakeUpFreshnessAlcoholTime = new double[CNTAlcoholTime];
            double[] WakeUpFreshnessNapTime = new double[CNTNapTime];
            double[] WakeUpFreshnessNapDuration = new double[CNTNapDuration];
            double[] WakeUpFreshnessDigDeviceDuration = new double[CNTDigDeviceDuration];
            double[] WakeUpFreshnessGamesDuration = new double[CNTGamesDuration];
            double[] WakeUpFreshnessSocialFriend = new double[CNTSocialFriend];
            double[] WakeUpFreshnessSocialFamily = new double[CNTSocialFamily];
            double[] WakeUpFreshnessSocialMedia = new double[CNTSocialMedia];
            double[] WakeUpFreshnessMusicDuration = new double[CNTMusicDuration];
            double[] WakeUpFreshnessTVDuration = new double[CNTTVDuration];
            double[] WakeUpFreshnessWorkTime = new double[CNTWorkTime];
            double[] WakeUpFreshnessWorkDuration = new double[CNTWorkDuration];
            double[] WakeUpFreshnessExerciseDuration = new double[CNTExerciseDuration];
            double[] WakeUpFreshnessExerciseIntensity = new double[CNTExerciseIntensity];
            double[] WakeUpFreshnessDinnerTime = new double[CNTDinnerTime];
            double[] WakeUpFreshnessSnackTime = new double[CNTSnackTime];
            double[] WakeUpFreshnessAmbientTemp = new double[CNTAmbientTemp];
            double[] WakeUpFreshnessAmbientHumd = new double[CNTAmbientHumd];
            double[] WakeUpFreshnessLight = new double[CNTLight];
            double[] WakeUpFreshnessSunRiseTime = new double[CNTSunRiseTime];
            double[] WakeUpFreshnessSunSetTime = new double[CNTSunSetTime];


            //Temp Values
            //Fitbit
            double[] tmpSteps = new double[CNTSteps];
            double[] tmpDistance = new double[CNTDistance];
            double[] tmpMinutesSedentary = new double[CNTMinutesSedentary];
            double[] tmpMinutesLightlyActive = new double[CNTMinutesLightlyActive];
            double[] tmpMinutesFairlyActive = new double[CNTMinutesFairlyActive];
            double[] tmpMinutesVeryActive = new double[CNTMinutesVeryActive];
            double[] tmpWater = new double[CNTWater];
            double[] tmpCaloriesIn = new double[CNTCaloriesIn];
            double[] tmpCaloriesOut = new double[CNTCaloriesOut];
            double[] tmpActivityCalories = new double[CNTActivityCalories];
            double[] tmpWeight = new double[CNTWeight];
            double[] tmpBMI = new double[CNTBMI];
            double[] tmpFat = new double[CNTFat];

            //Diary 
            double[] tmpPercievedStress = new double[CNTPercievedStress];
          /* 
            double[] tmpPss1 = new double[CNTPss1];
            double[] tmpPss2 = new double[CNTPss2];
            double[] tmpPss3 = new double[CNTPss3];
            double[] tmpPss4 = new double[CNTPss4];
            double[] tmpPss5 = new double[CNTPss5];
            double[] tmpPss6 = new double[CNTPss6];
            double[] tmpPss7 = new double[CNTPss7];
            double[] tmpPss8 = new double[CNTPss8];
            double[] tmpPss9 = new double[CNTPss9];
            double[] tmpPss10 = new double[CNTPss10];*/


            double[] tmpMood = new double[CNTMood];
            double[] tmpStress = new double[CNTStress];
            double[] tmpTiredness = new double[CNTTiredness];
            double[] tmpDream = new double[CNTDream];
            double[] tmpBodyTemp = new double[CNTBodyTemp];
            double[] tmpHormone = new double[CNTHormone];
            double[] tmpSchoolStress = new double[CNTSchoolStress];
            double[] tmpCoffeeAmt = new double[CNTCoffeeAmt];
            double[] tmpCoffeeTime = new double[CNTCoffeeTime];
            double[] tmpAlcoholAmt = new double[CNTAlcoholAmt];
            double[] tmpAlcoholTime = new double[CNTAlcoholTime];
            double[] tmpNapTime = new double[CNTNapTime];
            double[] tmpNapDuration = new double[CNTNapDuration];
            double[] tmpDigDeviceDuration = new double[CNTDigDeviceDuration];
            double[] tmpGamesDuration = new double[CNTGamesDuration];
            double[] tmpSocialFriend = new double[CNTSocialFriend];
            double[] tmpSocialFamily = new double[CNTSocialFamily];
            double[] tmpSocialMedia = new double[CNTSocialMedia];
            double[] tmpMusicDuration = new double[CNTMusicDuration];
            double[] tmpTVDuration = new double[CNTTVDuration];
            double[] tmpWorkTime = new double[CNTWorkTime];
            double[] tmpWorkDuration = new double[CNTWorkDuration];
            double[] tmpExerciseDuration = new double[CNTExerciseDuration];
            double[] tmpExerciseIntensity = new double[CNTExerciseIntensity];
            double[] tmpDinnerTime = new double[CNTDinnerTime];
            double[] tmpSnackTime = new double[CNTSnackTime];
            double[] tmpAmbientTemp = new double[CNTAmbientTemp];
            double[] tmpAmbientHumd = new double[CNTAmbientHumd];
            double[] tmpLight = new double[CNTLight];
            double[] tmpSunRiseTime = new double[CNTSunRiseTime];
            double[] tmpSunSetTime = new double[CNTSunSetTime];



            //Fitbit Data incruments 
            int iMinutesAsleep = 0, iMinutesAwake = 0,
            iAwakeningsCount = 0, iMinutesToFallAsleep = 0, iSleepEfficiency = 0;

#pragma warning disable CS0219 // The variable 'iSteps' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iDistance' is assigned but its value is never used
            int iSteps = 0, iDistance = 0, iMinutesSedentary = 0, iMinutesLightlyActive = 0,
#pragma warning restore CS0219 // The variable 'iDistance' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSteps' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWater' is assigned but its value is never used
                iMinutesFairlyActive = 0, iMinutesVeryActive = 0, iWater = 0,
#pragma warning restore CS0219 // The variable 'iWater' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iCaloriesOut' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iCaloriesIn' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iActivityCalories' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWeight' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iBMI' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iFat' is assigned but its value is never used
                iCaloriesOut = 0, iActivityCalories = 0, iWeight = 0, iBMI = 0, iFat = 0, iCaloriesIn = 0;
#pragma warning restore CS0219 // The variable 'iFat' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iBMI' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWeight' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iActivityCalories' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iCaloriesIn' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iCaloriesOut' is assigned but its value is never used

            //Diary Data incruments
#pragma warning disable CS0219 // The variable 'iMood' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWakeUpFreshness' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iStress' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iTiredness' is assigned but its value is never used
            int iWakeUpFreshness = 0, iMood = 0, iStress = 0, iTiredness = 0, iPercievedStress = 0,
#pragma warning restore CS0219 // The variable 'iTiredness' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iStress' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWakeUpFreshness' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iMood' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iBodyTemp' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iDream' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iHormone' is assigned but its value is never used
                iDream = 0, iBodyTemp = 0, iHormone = 0, 
#pragma warning restore CS0219 // The variable 'iHormone' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iDream' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iBodyTemp' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSchoolStress' is assigned but its value is never used
                iSchoolStress = 0,
#pragma warning restore CS0219 // The variable 'iSchoolStress' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iAlcoholTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iCoffeeTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iCoffeeAmt' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iAlcoholAmt' is assigned but its value is never used
                iCoffeeAmt = 0, iCoffeeTime = 0, iAlcoholAmt = 0, iAlcoholTime = 0,
#pragma warning restore CS0219 // The variable 'iAlcoholAmt' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iCoffeeAmt' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iCoffeeTime' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iAlcoholTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iNapDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iNapTime' is assigned but its value is never used
                iNapTime = 0, iNapDuration = 0,
#pragma warning restore CS0219 // The variable 'iNapTime' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iNapDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iMusicDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSocialFamily' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSocialFriend' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSocialMedia' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iGamesDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iDigDeviceDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iTVDuration' is assigned but its value is never used
                iDigDeviceDuration = 0, iGamesDuration = 0, iSocialFriend = 0, iSocialFamily = 0, iSocialMedia = 0, iMusicDuration = 0, iTVDuration = 0,
#pragma warning restore CS0219 // The variable 'iTVDuration' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iDigDeviceDuration' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iGamesDuration' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSocialMedia' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSocialFriend' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSocialFamily' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iMusicDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iExerciseIntensity' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWorkTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWorkDuration' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iExerciseDuration' is assigned but its value is never used
                iWorkTime = 0, iWorkDuration = 0, iExerciseDuration = 0, iExerciseIntensity = 0,
#pragma warning restore CS0219 // The variable 'iExerciseDuration' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWorkDuration' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWorkTime' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iExerciseIntensity' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSnackTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iDinnerTime' is assigned but its value is never used
                iDinnerTime = 0, iSnackTime = 0,
#pragma warning restore CS0219 // The variable 'iDinnerTime' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSnackTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iLight' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSunSetTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iAmbientTemp' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iSunRiseTime' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iAmbientHumd' is assigned but its value is never used
                iAmbientTemp = 0, iAmbientHumd = 0, iLight = 0, iSunRiseTime = 0, iSunSetTime = 0;
#pragma warning restore CS0219 // The variable 'iAmbientHumd' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSunRiseTime' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iAmbientTemp' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iSunSetTime' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iLight' is assigned but its value is never used

            //int iFloors = 0;
            //int iTimeEnteredBed = 0;

#pragma warning disable CS0219 // The variable 'iWakeUpFreshnessMinutesAsleep' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWakeUpFreshnessMinutesAwake' is assigned but its value is never used
            int iWakeUpFreshnessMinutesAsleep = 0, iWakeUpFreshnessMinutesAwake = 0,
#pragma warning restore CS0219 // The variable 'iWakeUpFreshnessMinutesAwake' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWakeUpFreshnessMinutesAsleep' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWakeUpFreshnessSleepEfficiency' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWakeUpFreshnessAwakeningsCount' is assigned but its value is never used
#pragma warning disable CS0219 // The variable 'iWakeUpFreshnessMinutesToFallAsleep' is assigned but its value is never used
                iWakeUpFreshnessAwakeningsCount = 0, iWakeUpFreshnessMinutesToFallAsleep = 0, iWakeUpFreshnessSleepEfficiency = 0;
#pragma warning restore CS0219 // The variable 'iWakeUpFreshnessMinutesToFallAsleep' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWakeUpFreshnessAwakeningsCount' is assigned but its value is never used
#pragma warning restore CS0219 // The variable 'iWakeUpFreshnessSleepEfficiency' is assigned but its value is never used

            int iWakeUpFreshnessSteps = 0, iWakeUpFreshnessDistance = 0, iWakeUpFreshnessMinutesSedentary = 0, iWakeUpFreshnessMinutesLightlyActive = 0,
                iWakeUpFreshnessMinutesFairlyActive = 0, iWakeUpFreshnessMinutesVeryActive = 0, iWakeUpFreshnessWater = 0,
                iWakeUpFreshnessCaloriesOut = 0, iWakeUpFreshnessActivityCalories = 0, iWakeUpFreshnessWeight = 0, iWakeUpFreshnessBMI = 0, iWakeUpFreshnessFat = 0, iWakeUpFreshnessCaloriesIn = 0;

            //Diary Data incruments
            int iWakeUpFreshnessMood = 0, iWakeUpFreshnessStress = 0, iWakeUpFreshnessTiredness = 0,
                iWakeUpFreshnessDream = 0, iWakeUpFreshnessBodyTemp = 0, iWakeUpFreshnessHormone = 0,
#pragma warning disable CS0219 // The variable 'iWakeUpFreshnessSchoolStress' is assigned but its value is never used
                iWakeUpFreshnessSchoolStress = 0,
#pragma warning restore CS0219 // The variable 'iWakeUpFreshnessSchoolStress' is assigned but its value is never used
                iWakeUpFreshnessCoffeeAmt = 0, iWakeUpFreshnessCoffeeTime = 0, iWakeUpFreshnessAlcoholAmt = 0, iWakeUpFreshnessAlcoholTime = 0,
                iWakeUpFreshnessNapTime = 0, iWakeUpFreshnessNapDuration = 0,
                iWakeUpFreshnessDigDeviceDuration = 0, iWakeUpFreshnessGamesDuration = 0, iWakeUpFreshnessSocialFriend = 0, iWakeUpFreshnessSocialFamily = 0, iWakeUpFreshnessSocialMedia = 0, iWakeUpFreshnessMusicDuration = 0, iWakeUpFreshnessTVDuration = 0,
                iWakeUpFreshnessWorkTime = 0, iWakeUpFreshnessWorkDuration = 0, iWakeUpFreshnessExerciseDuration = 0, iWakeUpFreshnessExerciseIntensity = 0,
                iWakeUpFreshnessDinnerTime = 0, iWakeUpFreshnessSnackTime = 0,
                iWakeUpFreshnessAmbientTemp = 0, iWakeUpFreshnessAmbientHumd = 0, iWakeUpFreshnessLight = 0, iWakeUpFreshnessSunRiseTime = 0, iWakeUpFreshnessSunSetTime = 0;



            foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
            {

                //Console.Write(item); //didnt work!!!
                // System.Diagnostics.Debug.Write(item.MinutesAsleep); // didnt work!!!!
                //System.Diagnostics.Trace.Write(item); // didnt work!!!!

                // ******** Add entry to DB !!! *************         

                // 20161105 Pandita: Not necessary here? 
                //No - Think it was left from Old code
                //Db.Userdatas.Add(item);
                PercievedStress[iPercievedStress++] = Convert.ToDouble(daysData.PerceivedStress);
                MinutesAsleep[iMinutesAsleep++] = Convert.ToDouble(daysData.MinutesAsleep);
                MinutesAwake[iMinutesAwake++] = Convert.ToDouble(daysData.MinutesAwake);
                AwakeningsCount[iAwakeningsCount++] = Convert.ToDouble(daysData.AwakeningsCount);
                MinutesToFallAsleep[iMinutesToFallAsleep++] = Convert.ToDouble(daysData.MinutesToFallAsleep);
                SleepEfficiency[iSleepEfficiency++] = Convert.ToDouble(daysData.SleepEfficiency);

                MinutesSedentary[iMinutesSedentary++] = Convert.ToDouble(daysData.MinutesSedentary);
                MinutesLightlyActive[iMinutesLightlyActive++] = Convert.ToDouble(daysData.MinutesLightlyActive);
                MinutesFairlyActive[iMinutesFairlyActive++] = Convert.ToDouble(daysData.MinutesFairlyActive);
                MinutesVeryActive[iMinutesVeryActive++] = Convert.ToDouble(daysData.MinutesVeryActive);
                ActivityCalories[iActivityCalories++] = Convert.ToDouble(daysData.ActivityCalories);
                if (Convert.ToDouble(daysData.WakeUpFreshness) > 0)
                {
                    //Fitbit Data
                    if (Convert.ToDouble(daysData.Steps) > 0)
                    {
                        WakeUpFreshnessSteps[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSteps[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.Steps);
                        iWakeUpFreshnessSteps++;
                    }
                    if (Convert.ToDouble(daysData.Distance) > 0)
                    {
                        WakeUpFreshnessWater[iWakeUpFreshnessDistance] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDistance[iWakeUpFreshnessDistance] = Convert.ToDouble(daysData.Distance);
                        iWakeUpFreshnessDistance++;
                    }
                    if (Convert.ToDouble(daysData.MinutesSedentary) > 0)
                    {
                        WakeUpFreshnessMinutesSedentary[iWakeUpFreshnessMinutesSedentary] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesSedentary[iWakeUpFreshnessMinutesSedentary] = Convert.ToDouble(daysData.MinutesSedentary);
                        iWakeUpFreshnessMinutesSedentary++;
                    }
                    if (Convert.ToDouble(daysData.MinutesLightlyActive) > 0)
                    {
                        WakeUpFreshnessMinutesLightlyActive[iWakeUpFreshnessSteps] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesLightlyActive[iWakeUpFreshnessMinutesLightlyActive] = Convert.ToDouble(daysData.MinutesLightlyActive);
                        iWakeUpFreshnessMinutesLightlyActive++;
                    }
                    if (Convert.ToDouble(daysData.MinutesFairlyActive) > 0)
                    {
                        WakeUpFreshnessMinutesFairlyActive[iWakeUpFreshnessMinutesFairlyActive] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesFairlyActive[iWakeUpFreshnessMinutesFairlyActive] = Convert.ToDouble(daysData.MinutesFairlyActive);
                        iWakeUpFreshnessMinutesFairlyActive++;
                    }
                    if (Convert.ToDouble(daysData.MinutesVeryActive) >= 0)
                    {
                        WakeUpFreshnessMinutesVeryActive[iWakeUpFreshnessMinutesVeryActive] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMinutesVeryActive[iWakeUpFreshnessMinutesVeryActive] = Convert.ToDouble(daysData.MinutesVeryActive);
                        iWakeUpFreshnessMinutesVeryActive++;
                    }
                    if (Convert.ToDouble(daysData.Water) >= 0)
                    {
                        WakeUpFreshnessWater[iWakeUpFreshnessWater] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWater[iWakeUpFreshnessWater] = Convert.ToDouble(daysData.Water);
                        iWakeUpFreshnessWater++;
                    }
                    if (Convert.ToDouble(daysData.CaloriesIn) >= 0)
                    {
                        WakeUpFreshnessCaloriesIn[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCaloriesIn[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.CaloriesIn);
                        iWakeUpFreshnessCaloriesIn++;
                    }
                    if (Convert.ToDouble(daysData.CaloriesOut) >= 0)
                    {
                        WakeUpFreshnessCaloriesOut[iWakeUpFreshnessCaloriesOut] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCaloriesOut[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.CaloriesIn);
                        iWakeUpFreshnessCaloriesIn++;
                    }
                    if (Convert.ToDouble(daysData.ActivityCalories) >= 0)
                    {
                        WakeUpFreshnessActivityCalories[iWakeUpFreshnessActivityCalories] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpActivityCalories[iWakeUpFreshnessCaloriesIn] = Convert.ToDouble(daysData.ActivityCalories);
                        iWakeUpFreshnessActivityCalories++;
                    }
                    if (Convert.ToDouble(daysData.Weight) > 0)
                    {
                        WakeUpFreshnessWeight[iWakeUpFreshnessWeight] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWeight[iWakeUpFreshnessWeight] = Convert.ToDouble(daysData.Weight);
                        iWakeUpFreshnessWeight++;
                    }
                    if (Convert.ToDouble(daysData.Fat) > 0)
                    {
                        WakeUpFreshnessFat[iWakeUpFreshnessFat] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpFat[iWakeUpFreshnessFat] = Convert.ToDouble(daysData.Fat);
                        iWakeUpFreshnessFat++;
                    }
                    if (Convert.ToDouble(daysData.Fat) > 0)
                    {
                        WakeUpFreshnessBMI[iWakeUpFreshnessBMI] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpBMI[iWakeUpFreshnessBMI] = Convert.ToDouble(daysData.BMI);
                        iWakeUpFreshnessBMI++;
                    }
                    //Diary data
                    //Percieved Stress
                    if (Convert.ToDouble(daysData.PerceivedStress) >= 0)
                    {
                        PercievedStress[iPercievedStress] = Convert.ToDouble(daysData.PerceivedStress);
                        tmpPercievedStress[iPercievedStress] = Convert.ToDouble(daysData.PerceivedStress);
                        iPercievedStress++;
                    }

                    if (Convert.ToDouble(daysData.Mood) >= 0)
                    {
                        WakeUpFreshnessMood[iWakeUpFreshnessMood] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMood[iWakeUpFreshnessMood] = Convert.ToDouble(daysData.Mood);
                        iWakeUpFreshnessMood++;
                    }
                    if (Convert.ToDouble(daysData.Stress) > 0)
                    {
                        WakeUpFreshnessStress[iWakeUpFreshnessStress] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpStress[iWakeUpFreshnessStress] = Convert.ToDouble(daysData.Stress);
                        iWakeUpFreshnessStress++;
                    }
                    if (Convert.ToDouble(daysData.Tiredness) >= 0)
                    {
                        WakeUpFreshnessTiredness[iWakeUpFreshnessTiredness] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpTiredness[iWakeUpFreshnessTiredness] = Convert.ToDouble(daysData.Tiredness);
                        iWakeUpFreshnessTiredness++;
                    }
                    if (Convert.ToDouble(daysData.Dream) >= 0)
                    {
                        WakeUpFreshnessDream[iWakeUpFreshnessDream] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDream[iWakeUpFreshnessDream] = Convert.ToDouble(daysData.Dream);
                        iWakeUpFreshnessDream++;
                    }
                    if (Convert.ToDouble(daysData.BodyTemp) >= 0)
                    {
                        WakeUpFreshnessBodyTemp[iWakeUpFreshnessBodyTemp] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpBodyTemp[iWakeUpFreshnessBodyTemp] = Convert.ToDouble(daysData.BodyTemp);
                        iWakeUpFreshnessBodyTemp++;
                    }
                    if (Convert.ToDouble(daysData.Hormone) >= 0)
                    {
                        WakeUpFreshnessHormone[iWakeUpFreshnessHormone] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpHormone[iWakeUpFreshnessHormone] = Convert.ToDouble(daysData.Hormone);
                        iWakeUpFreshnessHormone++;
                    }
                    if (Convert.ToDouble(daysData.CoffeeAmt) >= 0)
                    {
                        WakeUpFreshnessCoffeeAmt[iWakeUpFreshnessCoffeeAmt] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCoffeeAmt[iWakeUpFreshnessCoffeeAmt] = Convert.ToDouble(daysData.CoffeeAmt);
                        iWakeUpFreshnessCoffeeAmt++;
                    }
                    if (Convert.ToDouble(daysData.CoffeeTime) >= 0)
                    {
                        WakeUpFreshnessCoffeeTime[iWakeUpFreshnessCoffeeTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpCoffeeTime[iWakeUpFreshnessCoffeeTime] = Convert.ToDouble(daysData.CoffeeTime);
                        iWakeUpFreshnessCoffeeTime++;
                    }
                    if (Convert.ToDouble(daysData.AlcoholAmt) >= 0)
                    {
                        WakeUpFreshnessAlcoholAmt[iWakeUpFreshnessAlcoholAmt] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAlcoholAmt[iWakeUpFreshnessAlcoholAmt] = Convert.ToDouble(daysData.AlcoholAmt);
                        iWakeUpFreshnessAlcoholAmt++;
                    }
                    if (Convert.ToDouble(daysData.AlcoholTime) >= 0)
                    {
                        WakeUpFreshnessAlcoholTime[iWakeUpFreshnessAlcoholTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAlcoholTime[iWakeUpFreshnessAlcoholTime] = Convert.ToDouble(daysData.AlcoholTime);
                        iWakeUpFreshnessAlcoholTime++;
                    }
                    if (Convert.ToDouble(daysData.NapTime) > 0)
                    {
                        WakeUpFreshnessNapTime[iWakeUpFreshnessNapTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpNapTime[iWakeUpFreshnessNapTime] = Convert.ToDouble(daysData.NapTime);
                        iWakeUpFreshnessNapTime++;
                    }
                    if (Convert.ToDouble(daysData.NapDuration) >= 0)
                    {
                        WakeUpFreshnessNapDuration[iWakeUpFreshnessNapDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpNapDuration[iWakeUpFreshnessNapDuration] = Convert.ToDouble(daysData.NapDuration);
                        iWakeUpFreshnessNapDuration++;
                    }
                    if (Convert.ToDouble(daysData.DigDeviceDuration) > 0)
                    {
                        WakeUpFreshnessDigDeviceDuration[iWakeUpFreshnessDigDeviceDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDigDeviceDuration[iWakeUpFreshnessDigDeviceDuration] = Convert.ToDouble(daysData.DigDeviceDuration);
                        iWakeUpFreshnessDigDeviceDuration++;
                    }
                    if (Convert.ToDouble(daysData.GamesDuration) > 0)
                    {
                        WakeUpFreshnessGamesDuration[iWakeUpFreshnessGamesDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpGamesDuration[iWakeUpFreshnessGamesDuration] = Convert.ToDouble(daysData.GamesDuration);
                        iWakeUpFreshnessGamesDuration++;
                    }
                    // 20170214 Pandita: added time spent with family and friend, as well as time spent on social media
                    if (Convert.ToDouble(daysData.SocialFriend) > 0)
                    {
                        WakeUpFreshnessSocialFriend[iWakeUpFreshnessSocialFriend] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSocialFriend[iWakeUpFreshnessSocialFriend] = Convert.ToDouble(daysData.SocialFriend);
                        iWakeUpFreshnessSocialFriend++;
                    }
                    if (Convert.ToDouble(daysData.SocialFamily) > 0)
                    {
                        WakeUpFreshnessSocialFamily[iWakeUpFreshnessSocialFamily] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSocialFamily[iWakeUpFreshnessSocialFamily] = Convert.ToDouble(daysData.SocialFamily);
                        iWakeUpFreshnessSocialFamily++;
                    }
                    if (Convert.ToDouble(daysData.SocialMedia) > 0)
                    {
                        WakeUpFreshnessSocialMedia[iWakeUpFreshnessSocialMedia] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSocialMedia[iWakeUpFreshnessSocialMedia] = Convert.ToDouble(daysData.SocialMedia);
                        iWakeUpFreshnessSocialMedia++;
                    }



                    if (Convert.ToDouble(daysData.MusicDuration) > 0)
                    {
                        WakeUpFreshnessMusicDuration[iWakeUpFreshnessMusicDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpMusicDuration[iWakeUpFreshnessMusicDuration] = Convert.ToDouble(daysData.MusicDuration);
                        iWakeUpFreshnessMusicDuration++;
                    }
                    if (Convert.ToDouble(daysData.TVDuration) > 0)
                    {
                        WakeUpFreshnessTVDuration[iWakeUpFreshnessTVDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpTVDuration[iWakeUpFreshnessTVDuration] = Convert.ToDouble(daysData.TVDuration);
                        iWakeUpFreshnessTVDuration++;
                    }
                    if (Convert.ToDouble(daysData.WorkTime) > 0)
                    {
                        WakeUpFreshnessWorkTime[iWakeUpFreshnessWorkTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWorkTime[iWakeUpFreshnessWorkTime] = Convert.ToDouble(daysData.WorkTime);
                        iWakeUpFreshnessWorkTime++;
                    }
                    if (Convert.ToDouble(daysData.WorkDuration) > 0)
                    {
                        WakeUpFreshnessWorkDuration[iWakeUpFreshnessWorkDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpWorkDuration[iWakeUpFreshnessWorkDuration] = Convert.ToDouble(daysData.WorkDuration);
                        iWakeUpFreshnessWorkDuration++;
                    }
                    if (Convert.ToDouble(daysData.ExerciseDuration) > 0)
                    {
                        WakeUpFreshnessExerciseDuration[iWakeUpFreshnessExerciseDuration] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpExerciseDuration[iWakeUpFreshnessExerciseDuration] = Convert.ToDouble(daysData.ExerciseDuration);
                        iWakeUpFreshnessExerciseDuration++;
                    }
                    if (Convert.ToDouble(daysData.ExerciseIntensity) > 0)
                    {
                        WakeUpFreshnessExerciseIntensity[iWakeUpFreshnessExerciseIntensity] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpExerciseIntensity[iWakeUpFreshnessExerciseIntensity] = Convert.ToDouble(daysData.ExerciseIntensity);
                        iWakeUpFreshnessExerciseIntensity++;
                    }
                    if (Convert.ToDouble(daysData.DinnerTime) > 0)
                    {
                        WakeUpFreshnessDinnerTime[iWakeUpFreshnessDinnerTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpDinnerTime[iWakeUpFreshnessDinnerTime] = Convert.ToDouble(daysData.DinnerTime);
                        iWakeUpFreshnessDinnerTime++;
                    }
                    if (Convert.ToDouble(daysData.SnackTime) > 0)
                    {
                        WakeUpFreshnessSnackTime[iWakeUpFreshnessSnackTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSnackTime[iWakeUpFreshnessSnackTime] = Convert.ToDouble(daysData.SnackTime);
                        iWakeUpFreshnessSnackTime++;
                    }
                    if (Convert.ToDouble(daysData.AmbientTemp) > 0)
                    {
                        WakeUpFreshnessAmbientTemp[iWakeUpFreshnessAmbientTemp] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAmbientTemp[iWakeUpFreshnessAmbientTemp] = Convert.ToDouble(daysData.AmbientTemp);
                        iWakeUpFreshnessAmbientTemp++;
                    }
                    if (Convert.ToDouble(daysData.AmbientHumd) > 0)
                    {
                        WakeUpFreshnessAmbientHumd[iWakeUpFreshnessAmbientHumd] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpAmbientHumd[iWakeUpFreshnessAmbientHumd] = Convert.ToDouble(daysData.AmbientHumd);
                        iWakeUpFreshnessAmbientHumd++;
                    }
                    if (Convert.ToDouble(daysData.Light) > 0)
                    {
                        WakeUpFreshnessLight[iWakeUpFreshnessLight] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpLight[iWakeUpFreshnessLight] = Convert.ToDouble(daysData.Light);
                        iWakeUpFreshnessLight++;
                    }
                    if (Convert.ToDouble(daysData.SunRiseTime) > 0)
                    {
                        WakeUpFreshnessSunRiseTime[iWakeUpFreshnessSunRiseTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSunRiseTime[iWakeUpFreshnessSunRiseTime] = Convert.ToDouble(daysData.SunRiseTime);
                        iWakeUpFreshnessSunRiseTime++;
                    }
                    if (Convert.ToDouble(daysData.SunSetTime) > 0)
                    {
                        WakeUpFreshnessSunSetTime[iWakeUpFreshnessSunSetTime] = Convert.ToDouble(daysData.WakeUpFreshness);
                        tmpSunSetTime[iWakeUpFreshnessSunSetTime] = Convert.ToDouble(daysData.SunSetTime);
                        iWakeUpFreshnessSunSetTime++;
                    }
                }

            }
            /*
            // WakeUpFreshness
            double rWakeUpFreshness = 0;

            if (iWakeUpFreshnessSteps > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSteps, tmpSteps);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "Wake Up Freshness", Name = "Steps", Coefficient = rWakeUpFreshness, Note = "The more steps you walked, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Steps", Coefficient = rWakeUpFreshness, Note = "The more steps you walked, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesSedentary > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesSedentary, tmpMinutesSedentary);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Stationary", Coefficient = rWakeUpFreshness, Note = "The more time you spent stationary, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Stationary", Coefficient = rWakeUpFreshness, Note = "The more time you spent stationary, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesLightlyActive > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesLightlyActive, tmpMinutesLightlyActive);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Lightly Active", Coefficient = rWakeUpFreshness, Note = "The more light exersise that you did, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Lightly Active", Coefficient = rWakeUpFreshness, Note = "The more light exersise that you did, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesFairlyActive > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesFairlyActive, tmpMinutesFairlyActive);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Fairly Active", Coefficient = rWakeUpFreshness, Note = "The more moderate exersise that you did, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Fairly Active", Coefficient = rWakeUpFreshness, Note = "The more moderate exersise that you did, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessMinutesVeryActive > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMinutesVeryActive, tmpMinutesVeryActive);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Very Active", Coefficient = rWakeUpFreshness, Note = "The more intense exercise you did, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Minutes Very Active", Coefficient = rWakeUpFreshness, Note = "The more intense exercise you did, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessWater > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessWater, tmpWater);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Water", Coefficient = rWakeUpFreshness, Note = "The more water you had in the day, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Water", Coefficient = rWakeUpFreshness, Note = "The more water you had in the day, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessCaloriesIn > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCaloriesIn, tmpCaloriesIn);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Food Intake", Coefficient = rWakeUpFreshness, Note = "The more you ate, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Food Intake", Coefficient = rWakeUpFreshness, Note = "The more you ate, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessCaloriesOut > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCaloriesOut, tmpCaloriesOut);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Energy Burned", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Energy Burned", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessActivityCalories > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessActivityCalories, tmpActivityCalories);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Active Moments", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day from exercise, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Active Moments", Coefficient = rWakeUpFreshness, Note = "The more engery you burn throughout the day from exercise, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessWeight > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessWeight, tmpWeight);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Weight", Coefficient = rWakeUpFreshness, Note = "The more you weighted, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Weight", Coefficient = rWakeUpFreshness, Note = "The more you weighted, the more alert you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessBMI > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessBMI, tmpBMI);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BMI", Coefficient = rWakeUpFreshness, Note = "The higher your BMI was, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BMI", Coefficient = rWakeUpFreshness, Note = "The higher your BMI was, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessFat > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessFat, tmpFat);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Fat", Coefficient = rWakeUpFreshness, Note = "The more fat you had, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Fat", Coefficient = rWakeUpFreshness, Note = "The more fat you had, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }

            
            //Diary data
            if (iWakeUpFreshnessMood > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMood, tmpMood);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Mood", Coefficient = rWakeUpFreshness, Note = "The better your mood before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Mood", Coefficient = rWakeUpFreshness, Note = "The better your mood before bed time, the more dizzy you felt when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessStress > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessStress, tmpStress);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Stress", Coefficient = rWakeUpFreshness, Note = "The more Stressed you felt before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Stress", Coefficient = rWakeUpFreshness, Note = "The more Stressed you felt before bed time, the more dizzy you felt when you woke up." });
                    }
                }
            }

            if (iWakeUpFreshnessTiredness > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessTiredness, tmpTiredness);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Tiredness", Coefficient = rWakeUpFreshness, Note = "The more tired you felt before bed time, the more alert you felt when you woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Tiredness", Coefficient = rWakeUpFreshness, Note = "The more tired you felt before bed time, the more dizzy you felt when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessDream > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessDream, tmpDream);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Dream", Coefficient = rWakeUpFreshness, Note = "Dreaming makes you feel dizzy when woke up the second morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Dream", Coefficient = rWakeUpFreshness, Note = "Dreaming makes you feel alert when you woke up the second morning." });
                    }
                }
            }
            if (iWakeUpFreshnessBodyTemp > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessBodyTemp, tmpBodyTemp);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BodyTemp", Coefficient = rWakeUpFreshness, Note = "The higher your body temperature was before bed time, the more alert you felt when you woke up in the morning." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "BodyTemp", Coefficient = rWakeUpFreshness, Note = "The higher your body temperature was before bed time, the less alert you felt when you woke up in the morning." });
                    }
                }
            }
            if (iWakeUpFreshnessHormone > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessHormone, tmpHormone);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Hormone", Coefficient = rWakeUpFreshness, Note = "As the next period approaches, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Hormone", Coefficient = rWakeUpFreshness, Note = "As the next period approaches, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessCoffeeAmt > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCoffeeAmt, tmpCoffeeAmt);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Amount", Coefficient = rWakeUpFreshness, Note = "The more coffee you had, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Amount", Coefficient = rWakeUpFreshness, Note = "The more coffee you had, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessCoffeeTime > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessCoffeeTime, tmpCoffeeTime);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Time", Coefficient = rWakeUpFreshness, Note = "The later you had coffee, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Coffee Time", Coefficient = rWakeUpFreshness, Note = "The later you had coffee, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessAlcoholAmt > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessAlcoholAmt, tmpAlcoholAmt);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Amount", Coefficient = rWakeUpFreshness, Note = "The more Alcohol you had, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Amount", Coefficient = rWakeUpFreshness, Note = "The more Alcohol you had, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessAlcoholTime > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessAlcoholTime, tmpAlcoholTime);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Time", Coefficient = rWakeUpFreshness, Note = "The later you had Alcohol, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Alcohol Time", Coefficient = rWakeUpFreshness, Note = "The later you had Alcohol, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessNapTime > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessNapTime, tmpNapTime);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Time", Coefficient = rWakeUpFreshness, Note = "The later you had a nap, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Time", Coefficient = rWakeUpFreshness, Note = "The later you had a nap, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessNapDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessNapDuration, tmpNapDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Duration", Coefficient = rWakeUpFreshness, Note = "The longer you had a nap, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Nap Duration", Coefficient = rWakeUpFreshness, Note = "The longer you had a nap, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessDigDeviceDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessDigDeviceDuration, tmpDigDeviceDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Digital Devices", Coefficient = rWakeUpFreshness, Note = "The heavier you used digital devices before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Digital Devices", Coefficient = rWakeUpFreshness, Note = "The heavier you used digital devices before bed time, the more dizzy you felt when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessGamesDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessGamesDuration, tmpGamesDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Games", Coefficient = rWakeUpFreshness, Note = "The heavier you played games before bed time, the more alert you felt when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Games", Coefficient = rWakeUpFreshness, Note = "The heavier you played games before bed time, the more dizzy you felt when you woke up.." });
                    }
                }
            }
            if (iWakeUpFreshnessSocialFriend > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSocialFriend, tmpSocialFriend);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Activites", Coefficient = rWakeUpFreshness, Note = "The more social activites you do before bed, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Activites", Coefficient = rWakeUpFreshness, Note = "The more social activites you do before bed, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessSocialFamily > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessSocialFamily, tmpSocialFamily);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Media", Coefficient = rWakeUpFreshness, Note = "The heavier you were on social media before bed time, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Social Media", Coefficient = rWakeUpFreshness, Note = "The heavier you were on social media before bed time, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessMusicDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessMusicDuration, tmpMusicDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Music", Coefficient = rWakeUpFreshness, Note = "The longer you had listened to Music, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Music", Coefficient = rWakeUpFreshness, Note = "The longer you had listened to Music, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessTVDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessTVDuration, tmpTVDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "TV", Coefficient = rWakeUpFreshness, Note = "The longer you had watched TV, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "TV", Coefficient = rWakeUpFreshness, Note = "The longer you had watched TV, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessExerciseDuration > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessExerciseDuration, tmpExerciseDuration);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Duration", Coefficient = rWakeUpFreshness, Note = "The longer you Exercised, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Duration", Coefficient = rWakeUpFreshness, Note = "The longer you Exercised, you tend to feel more dizzy when you woke up." });
                    }
                }
            }
            if (iWakeUpFreshnessExerciseIntensity > 4)
            {
                rWakeUpFreshness = Correlation.Pearson(WakeUpFreshnessExerciseIntensity, tmpExerciseIntensity);
                if (Math.Abs(rWakeUpFreshness) >= 0.3)
                {
                    if (rWakeUpFreshness > 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Intensity", Coefficient = rWakeUpFreshness, Note = "The more intense you Exercised, you tend to feel more alert when you woke up." });
                    }
                    else if (rWakeUpFreshness < 0)
                    {
                        CoefficientList.Add(new CorrList() { Belong = "WakeUpFreshness", Name = "Exercise Intensity", Coefficient = rWakeUpFreshness, Note = "The more intense you Exercised, you tend to feel more dizzy when you woke up." });
                    }
                }
            }*/

            // MinutesAsleep
            
        
            double rstress = Correlation.Pearson(MinutesAsleep, PercievedStress);
            if (Math.Abs(rstress) >= 0.3)
            {
                if (rstress > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Percieved Stress", Coefficient = rstress, Picture = "", Note = "The more sleep, the more stressed you felt" });
                }
                else if (rstress < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Percieved Stress", Coefficient = rstress, Picture = "", Note = "The more sleep, the less stressed you felt." });
                }
            }
            double rMinutesSedentary = Correlation.Pearson(MinutesAsleep, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary your were, the longer you were asleep during night." });
                }
                else if (rMinutesSedentary < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary your were, the shorter you were asleep during night." });
                }
            }

            double rMinutesLightlyActive = Correlation.Pearson(MinutesAsleep, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise your did, the longer you were asleep during night." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise your did, the shorter you were asleep during night." });
                }
            }

            double rMinutesFairlyActive = Correlation.Pearson(MinutesAsleep, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise your did, the longer you were asleep during night." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise your did, the shorter you were asleep during night." });
                }
            }

            double rMinutesVeryActive = Correlation.Pearson(MinutesAsleep, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise your did, the longer you were asleep during night." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise your did, the shorter you were asleep during night." });
                }
            }
            //Stress

            //EXERCISE
             rMinutesSedentary = Correlation.Pearson(PercievedStress, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary your were, the less stressed  you felt." });
                }
                else if (rMinutesSedentary < 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Sedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary your were, the More stressed you felt" });
                }
            }

           

             rMinutesLightlyActive = Correlation.Pearson(PercievedStress, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise your did, the less stres you felt." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Lightly Active", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise your did, the more stress you felt." });
                }
            }

              rMinutesFairlyActive = Correlation.Pearson(PercievedStress, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise your did, the less stressed you felt." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Fairly Active", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise your did, the more stressed you felt." });
                }
            }

              rMinutesVeryActive = Correlation.Pearson(PercievedStress, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise your did, the less stressed you felt." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Very Active", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise your did, the more stressed you felt." });
                }
            }



            //SLEEP
            double rMinutesAsleep = Correlation.Pearson(PercievedStress, MinutesAsleep);
            if (Math.Abs(rMinutesAsleep) >= 0.3)
            {
                if (rMinutesAsleep > 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Asleep", Coefficient = rMinutesAsleep, Picture = "", Note = "The more hours you slept, the more stressed  you felt." });
                }
                else if (rMinutesAsleep < 0)
                {
                    StressCorrList.Add(new CorrList() { Name = "Minutes Asleep", Coefficient = rMinutesAsleep, Picture = "", Note = "The more hours your slept, the less stressed you felt" });
                }
            }



            //Exercise

            //stress
             rstress = Correlation.Pearson(ActivityCalories, PercievedStress);
            if (Math.Abs(rstress) >= 0.3)
            {
                if (rstress > 0)
                {
                    ExerciceCorrList.Add(new CorrList() { Name = "Percieved Stress", Coefficient = rstress, Picture = "", Note = "The more active your were, the less stressed  you felt." });
                }
                else if (rstress < 0)
                {
                    ExerciceCorrList.Add(new CorrList() { Name = "Percieved Stress", Coefficient = rstress, Picture = "", Note = "The less active your were, the More stressed you felt" });
                }
            }



           

            //SLEEP
            rMinutesAsleep = Correlation.Pearson(ActivityCalories, MinutesAsleep);
            if (Math.Abs(rMinutesAsleep) >= 0.3)
            {
                if (rMinutesAsleep > 0)
                {
                    ExerciceCorrList.Add(new CorrList() { Name = "Minutes Asleep", Coefficient = rMinutesAsleep, Picture = "", Note = "The more hours you slept, the more stressed  you felt." });
                }
                else if (rMinutesAsleep < 0)
                {
                    ExerciceCorrList.Add(new CorrList() { Name = "Minutes Asleep", Coefficient = rMinutesAsleep, Picture = "", Note = "The more hours your slept, the less stressed you felt" });
                }
            }
            /*
            // AwakeningsCount
            rMinutesSedentary = Correlation.Pearson(AwakeningsCount, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary you were, the more often you were awake during night." });
                }
                else if (rMinutesSedentary < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary you were, the less often you were awake during night." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(AwakeningsCount, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise you did, the more often you were awake during night." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise you did, the less often you were awake during night." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(AwakeningsCount, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise you did, the more often you were awake during night." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise you did, the less often you were awake during night." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(AwakeningsCount, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise you did, the more often you were awake during night." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise you did, the less often you were awake during night." });
                }
            }*/

            // SleepEfficiency

            rstress = Correlation.Pearson(SleepEfficiency, PercievedStress);
            if (Math.Abs(rstress) >= 0.3)
            {
                if (rstress > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "PercievedStress", Coefficient = rstress, Picture = "", Note = "The more sedentary you were, the better you sleep efficiency was." });
                }
                else if (rstress < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "PercievedStress", Coefficient = rstress, Picture = "", Note = "The less sedentary you were, the better you sleep efficiency was." });
                }
            }
            rMinutesSedentary = Correlation.Pearson(SleepEfficiency, MinutesSedentary);
            if (Math.Abs(rMinutesSedentary) >= 0.3)
            {
                if (rMinutesSedentary > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The more sedentary you were, the better you sleep efficiency was." });
                }
                else if (rMinutesSedentary < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesSedentary", Coefficient = rMinutesSedentary, Picture = "", Note = "The less sedentary you were, the better you sleep efficiency was." });
                }
            }


            rMinutesLightlyActive = Correlation.Pearson(SleepEfficiency, MinutesLightlyActive);
            if (Math.Abs(rMinutesLightlyActive) >= 0.3)
            {
                if (rMinutesLightlyActive > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise you did, the better you sleep efficiency was." });
                }
                else if (rMinutesLightlyActive < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesLightlyActive", Coefficient = rMinutesLightlyActive, Picture = "", Note = "The more light exercise you did, the worse you sleep efficiency was." });
                }
            }

            rMinutesFairlyActive = Correlation.Pearson(SleepEfficiency, MinutesFairlyActive);
            if (Math.Abs(rMinutesFairlyActive) >= 0.3)
            {
                if (rMinutesFairlyActive > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise you did, the better you sleep efficiency was." });
                }
                else if (rMinutesFairlyActive < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesFairlyActive", Coefficient = rMinutesFairlyActive, Picture = "", Note = "The more moderate exercise you did, the worse you sleep efficiency was." });
                }
            }

            rMinutesVeryActive = Correlation.Pearson(SleepEfficiency, MinutesVeryActive);
            if (Math.Abs(rMinutesVeryActive) >= 0.3)
            {
                if (rMinutesVeryActive > 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise you did, the better you sleep efficiency was." });
                }
                else if (rMinutesVeryActive < 0)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "MinutesVeryActive", Coefficient = rMinutesVeryActive, Picture = "", Note = "The more intense exercise you did, the worse you sleep efficiency was." });
                }
            }

            

            // CaloriesIn - DONE!!! YEAH!!!
            int temp = 0, identifier = 0;
            double pearson = 0, tempValue = 0;
            if (CNTCaloriesIn > 4)
            {
                double[] CaloriesIn = new double[CNTCaloriesIn];
                double[] tempMinutesAsleepCalariesIn = new double[CNTCaloriesIn];
                double[] tempAwakeningsCountCalariesIn = new double[CNTCaloriesIn];
                double[] tempSleepEfficiencyCalariesIn = new double[CNTCaloriesIn];

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {

                    tempValue = Convert.ToDouble(daysData.CaloriesIn);
                    if (tempValue > 0)
                    {
                        CaloriesIn[temp] = tempValue;
                        tempMinutesAsleepCalariesIn[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountCalariesIn[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyCalariesIn[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you intook, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you intook, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you intook, the more often were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you intook, the less often were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCalariesIn, CaloriesIn);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you intook, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesIn", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you intook, the worse your sleep efficiency was." });
                    }
                }

            }

            // CaloriesOut -- DONE !!! YEAH !!!

            if (CNTCaloriesOut > 4)
            {
                double[] CaloriesOut = new double[CNTCaloriesOut];
                double[] tempMinutesAsleepCalariesOut = new double[CNTCaloriesOut];
                double[] tempAwakeningsCountCalariesOut = new double[CNTCaloriesOut];
                double[] tempSleepEfficiencyCalariesOut = new double[CNTCaloriesOut];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.CaloriesOut);
                    if (tempValue > 0)
                    {
                        CaloriesOut[temp] = tempValue;
                        tempMinutesAsleepCalariesOut[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountCalariesOut[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyCalariesOut[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you output, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you output, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you output, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you output, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCalariesOut, CaloriesOut);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you output, the better you sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CaloriesOut", Coefficient = pearson, Picture = "fa fa-cutlery fa-2", Note = "The more calories you output, the worse you sleep efficiency was." });
                    }
                }

            }

            // Water -- DONE YEAH!!

            if (CNTWater > 4)
            {
                double[] Water = new double[CNTWater];
                double[] tempMinutesAsleepWater = new double[CNTWater];
                double[] tempAwakeningsCountWater = new double[CNTWater];
                double[] tempSleepEfficiencyWater = new double[CNTWater];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Water);
                    if (tempValue > 0)
                    {
                        Water[temp] = tempValue;
                        tempMinutesAsleepWater[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountWater[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyWater[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "The more water you drunk, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "The more water you drunk, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "The more water you drunk, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "The more water you drunk, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyWater, Water);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "The more water you drunk, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Water", Coefficient = pearson, Picture = "fa fa-beer fa-2", Note = "The more water you drunk, the worse your sleep efficiency was." });
                    }
                }

            } 

            // Steps -- DONE YEAH!!
            //added stress
            /*

            if (CNTSteps > 4)
            {
                double[] Steps = new double[CNTSteps];
               // double[] Stress = new double[CNTPss1 + CNTPss2 + CNTPss3 + CNTPss4 +CNTPss5 + CNTPss6 + CNTPss7 +CNTPss8 + CNTPss9 +CNTPss10];
                double[] tempMinutesAsleepSteps = new double[CNTSteps];
                double[] tempAwakeningsCountSteps = new double[CNTSteps]; ;
                double[] tempSleepEfficiencySteps = new double[CNTSteps];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Steps);
                    if (tempValue > 0)
                    {
                        Steps[temp] = tempValue;
                        tempMinutesAsleepSteps[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountSteps[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencySteps[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "The more steps you walked, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "The more steps you walked, the shorter time you were asleep during night." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "The more steps you walked, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "The more steps you walked, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencySteps, Steps);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "The more steps you walked, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Steps", Coefficient = pearson, Picture = "fa fa-bicycle fa-2", Note = "The more steps you walked, the worse your sleep efficiency was." });
                    }
                }

            }

            // weight -- DONE YEAH!!

            if (CNTWeight > 4)
            {
                double[] Weight = new double[CNTWeight];
                double[] tempMinutesAsleepWeight = new double[CNTWeight];
                double[] tempAwakeningsCountWeight = new double[CNTWeight];
                double[] tempSleepEfficiencyWeight = new double[CNTWeight];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Weight);
                    if (tempValue > 0)
                    {
                        Weight[temp] = tempValue;
                        tempMinutesAsleepWeight[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountWeight[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyWeight[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "The heavier your weight was, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "The heavier your weight was, the shorter time you were asleep during night." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "The heavier your weight was, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "The heavier your weight was, the less often you were awake during night." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWeight, Weight);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "The heavier your weight was, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Weight", Coefficient = pearson, Picture = "fa fa-balance-scale fa-2", Note = "The heavier your weight was, the worse your sleep efficiency was." });
                    }
                }

            }

            // Fat -- DONE YEAH!!

            if (CNTFat > 4)
            {
                double[] Fat = new double[CNTFat];
                double[] tempMinutesAsleepFat = new double[CNTFat];
                double[] tempAwakeningsCountFat = new double[CNTFat];
                double[] tempSleepEfficiencyFat = new double[CNTFat];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    tempValue = Convert.ToDouble(daysData.Fat);
                    if (tempValue > 0)
                    {
                        Fat[temp] = tempValue;
                        tempMinutesAsleepFat[temp] = MinutesAsleep[identifier];
                        tempAwakeningsCountFat[temp] = AwakeningsCount[identifier];
                        tempSleepEfficiencyFat[temp] = SleepEfficiency[identifier];

                        temp++;
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Fat", Coefficient = pearson, Picture = "fa fa-child fa-2" });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "Fat", Coefficient = pearson, Picture = "fa fa-child fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyFat, Fat);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Fat", Coefficient = pearson, Picture = "fa fa-child fa-2" });
                }

            }



            // Coffee -- DONE YEAH!!

            if (CNTCoffeeAmt > 4)
            {
                double[] Coffee = new double[CNTCoffeeAmt];
                double[] tempMinutesAsleepCoffee = new double[CNTCoffeeAmt];
                double[] tempAwakeningsCountCoffee = new double[CNTCoffeeAmt];
                double[] tempSleepEfficiencyCoffee = new double[CNTCoffeeAmt];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.CoffeeAmt != null)
                    {
                        tempValue = Convert.ToDouble(daysData.CoffeeAmt);
                        if (tempValue >= 0)
                        {
                            Coffee[temp] = tempValue;
                            tempMinutesAsleepCoffee[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountCoffee[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyCoffee[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The more coffee you consumed during the day, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The more coffee you consumed during the day, the shorter time you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The more coffee you consumed during the day, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The more coffee you consumed during the day, the less often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCoffee, Coffee);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The more coffee you consumed during the day, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Coffee", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The more coffee you consumed during the day, the worse your sleep efficiency was." });
                    }
                }

            }



            // CoffeeTime -- DONE YEAH!!

            if (CNTCoffeeTime > 4)
            {
                double[] CoffeeTime = new double[CNTCoffeeTime];
                double[] tempMinutesAsleepCoffeeTime = new double[CNTCoffeeTime];
                double[] tempAwakeningsCountCoffeeTime = new double[CNTCoffeeTime];
                double[] tempSleepEfficiencyCoffeeTime = new double[CNTCoffeeTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.CoffeeTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.CoffeeTime);
                        if (tempValue > 0)
                        {
                            CoffeeTime[temp] = tempValue;
                            tempMinutesAsleepCoffeeTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountCoffeeTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyCoffeeTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (Math.Abs(pearson) >= 0.3)
                    {
                        if (pearson > 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The earlier you drunk coffee, the shorter time you were asleep during night." });
                        }
                        else if (pearson < 0)
                        {
                            minutesAsleepCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The earlier you drunk coffee, the longer time you were asleep during night." });
                        }
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The earlier you drunk coffee, the less often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The earlier you drunk coffee, the more often you were awake during night." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyCoffeeTime, CoffeeTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The earlier you drunk coffee, the worse your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "CoffeeTime", Coefficient = pearson, Picture = "fa fa-coffee fa-2", Note = "The earlier you drunk coffee, the better your sleep efficiency was." });
                    }
                }

            }

            // Alcohol -- DONE YEAH!!

            if (CNTAlcoholAmt > 4)
            {
                double[] Alcohol = new double[CNTAlcoholAmt];
                double[] tempMinutesAsleepAlcohol = new double[CNTAlcoholAmt];
                double[] tempAwakeningsCountAlcohol = new double[CNTAlcoholAmt];
                double[] tempSleepEfficiencyAlcohol = new double[CNTAlcoholAmt];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.AlcoholAmt != null)
                    {
                        tempValue = Convert.ToDouble(daysData.AlcoholAmt);
                        if (tempValue >= 0)
                        {
                            Alcohol[temp] = tempValue;
                            tempMinutesAsleepAlcohol[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAlcohol[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAlcohol[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }

                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "The more alcohol you consumed, the longer time you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "The more alcohol you consumed, the shorter time you were asleep during night." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "The more alcohol you consumed, the more often you were awake during night." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "The more alcohol you consumed, the less often you were awake during night." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAlcohol, Alcohol);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "The more alcohol you consumed, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Alcohol", Coefficient = pearson, Picture = "fa fa-glass fa-2", Note = "The more alcohol you consumed, the worse your sleep efficiency was." });
                    }
                }

            }


            // Mood -- DONE YEAH!!

            if (CNTMood > 4)
            {
                double[] Mood = new double[CNTMood];
                double[] tempMinutesAsleepMood = new double[CNTMood];
                double[] tempAwakeningsCountMood = new double[CNTMood];
                double[] tempSleepEfficiencyMood = new double[CNTMood];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Mood != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Mood);
                        if (tempValue >= 0)
                        {
                            Mood[temp] = tempValue;
                            tempMinutesAsleepMood[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountMood[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyMood[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "The happier you felt before bed time, the more minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "The happier you felt before bed time, the less minutes you were asleep." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "The happier you felt before bed time, the more often you were awake during sleep." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "The happier you felt before bed time, the less often you were awake during sleep." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyMood, Mood);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "The happier you felt before bed time, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Mood", Coefficient = pearson, Picture = "fa fa-smile-o fa-2", Note = "Oops! The happier you felt before bed time, the worse your sleep efficiency was." });
                    }
                }

            }


            // Stress -- DONE YEAH!!

           /* if (CNTStress > 4)
            {
                double[] Stress = new double[CNTStress];
                double[] tempMinutesAsleepStress = new double[CNTStress];
                double[] tempAwakeningsCountStress = new double[CNTStress];
                double[] tempSleepEfficiencyStress = new double[CNTStress];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Stress != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Stress);
                        if (tempValue >= 0)
                        {
                            Stress[temp] = tempValue;
                            tempMinutesAsleepStress[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountStress[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyStress[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "The more stressed you were, the more minutes you were asleep during night." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "The more stressed you were, the less minutes you were asleep during night." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "The more stressed you were, the more awakenings you had." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "The more stressed you were, the less awakenings you had." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyStress, Stress);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "The more stressed you were, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Stress", Coefficient = pearson, Picture = "fa fa-frown-o fa-2", Note = "The less stressed you were, the better your sleep efficiency was." });
                    }
                }

            }*/

            // Tiredness -- DONE YEAH!!
            /*
            if (CNTTiredness > 4)
            {
                double[] Tiredness = new double[CNTTiredness];
                double[] tempMinutesAsleepTiredness = new double[CNTTiredness];
                double[] tempAwakeningsCountTiredness = new double[CNTTiredness];
                double[] tempSleepEfficiencyTiredness = new double[CNTTiredness];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Tiredness != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Tiredness);
                        if (tempValue >= 0)
                        {
                            Tiredness[temp] = tempValue;
                            tempMinutesAsleepTiredness[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountTiredness[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyTiredness[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "The more tired you were before bed time, the more minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "The more tired you were before bed time, the less minutes you were asleep." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "The more tired you were before bed time, the more often you were awake." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "The more tired you were before bed time, the less often you were awake." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyTiredness, Tiredness);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "The more tired you were before bed time, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Tiredness", Coefficient = pearson, Picture = "fa fa-bed fa-2", Note = "The more tired you were before bed time, the worse your sleep efficiency was." });
                    }
                }

            }



            // Dream -- DONE YEAH!!

            if (CNTDream > 4)
            {
                double[] Dream = new double[CNTDream];
                double[] tempMinutesAsleepDream = new double[CNTDream];
                double[] tempAwakeningsCountDream = new double[CNTDream];
                double[] tempSleepEfficiencyDream = new double[CNTDream];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Dream != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Dream);
                        if (tempValue >= 0)
                        {
                            Dream[temp] = tempValue;
                            tempMinutesAsleepDream[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountDream[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyDream[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "The more you dreamed, the less minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "The more you dreamed, the more minutes you were asleep." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "The more you dreamed, the less often you were awake." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "The more you dreamed, the more often you were awake." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDream, Dream);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "The more you dreamed, the worse your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Dream", Coefficient = pearson, Picture = "fa fa-cloud fa-2", Note = "The more you dreamed, the better your sleep efficiency was." });
                    }
                }

            }

            // DigitalDev -- DONE YEAH!!

            if (CNTDigDeviceDuration > 4)
            {
                double[] DigitalDev = new double[CNTDigDeviceDuration];
                double[] tempMinutesAsleepDigitalDev = new double[CNTDigDeviceDuration];
                double[] tempAwakeningsCountDigitalDev = new double[CNTDigDeviceDuration];
                double[] tempSleepEfficiencyDigitalDev = new double[CNTDigDeviceDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DigDeviceDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DigDeviceDuration);
                        if (tempValue >= 0)
                        {
                            DigitalDev[temp] = tempValue;
                            tempMinutesAsleepDigitalDev[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountDigitalDev[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyDigitalDev[temp] = SleepEfficiency[identifier];
                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "The heavier you used digital devices before bed time, the more minutes you were asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "The heavier you used digital devices before bed time, the less minutes you were asleep." });
                    }
                }

                pearson = Correlation.Pearson(tempAwakeningsCountDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "The heavier you used digital devices before bed time, the more often you were awake." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "The heavier you used digital devices before bed time, the less often you were awake." });
                    }
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDigitalDev, DigitalDev);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "The heavier you used digital devices before bed time, the better your sleep efficiency was." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "DigitalDevices", Coefficient = pearson, Picture = "fa fa-mobile fa-2", Note = "The heavier you used digital devices before bed time, the worse your sleep efficiency was." });
                    }
                }

            }


            // NapDuration -- DONE YEAH!!

            if (CNTNapDuration > 4)
            {
                double[] NapDuration = new double[CNTNapDuration];
                double[] tempMinutesAsleepNapDuration = new double[CNTNapDuration];
                double[] tempAwakeningsCountNapDuration = new double[CNTNapDuration];
                double[] tempSleepEfficiencyNapDuration = new double[CNTNapDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.NapDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.NapDuration);
                        if (tempValue >= 0)
                        {
                            NapDuration[temp] = tempValue;
                            tempMinutesAsleepNapDuration[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountNapDuration[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyNapDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "NapDuration", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "NapDuration", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyNapDuration, NapDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "NapDuration", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

            }


            // NapTime -- DONE YEAH!!

            if (CNTNapTime > 4)
            {
                double[] NapTime = new double[CNTNapTime];
                double[] tempMinutesAsleepNapTime = new double[CNTNapTime];
                double[] tempAwakeningsCountNapTime = new double[CNTNapTime];
                double[] tempSleepEfficiencyNapTime = new double[CNTNapTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.NapTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.NapTime);
                        if (tempValue > 0)
                        {
                            NapTime[temp] = tempValue;
                            tempMinutesAsleepNapTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountNapTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyNapTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "NapTime", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "NapTime", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyNapTime, NapTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "NapTime", Coefficient = pearson, Picture = "fa fa-bed fa-2" });
                }

            }

            // SocialFamily -- DONE YEAH!!

            if (CNTSocialFamily > 4)
            {
                double[] SocialFamily = new double[CNTSocialFamily];
                double[] tempMinutesAsleepSocialFamily = new double[CNTSocialFamily];
                double[] tempAwakeningsCountSocialFamily = new double[CNTSocialFamily];
                double[] tempSleepEfficiencySocialFamily = new double[CNTSocialFamily];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialFamily != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialFamily);
                        if (tempValue >= 0)
                        {
                            SocialFamily[temp] = tempValue;
                            tempMinutesAsleepSocialFamily[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSocialFamily[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySocialFamily[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialFamily, SocialFamily);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Time with Family", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSocialFamily, SocialFamily);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "Time with Family", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialFamily, SocialFamily);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Time with Family", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }

            }

            // SocialFriend -- DONE YEAH!!

            if (CNTSocialFriend > 4)
            {
                double[] SocialFriend = new double[CNTSocialFriend];
                double[] tempMinutesAsleepSocialFriend = new double[CNTSocialFriend];
                double[] tempAwakeningsCountSocialFriend = new double[CNTSocialFriend];
                double[] tempSleepEfficiencySocialFriend = new double[CNTSocialFriend];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialFriend != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialFriend);
                        if (tempValue >= 0)
                        {
                            SocialFriend[temp] = tempValue;
                            tempMinutesAsleepSocialFriend[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSocialFriend[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySocialFriend[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialFriend, SocialFriend);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Time with Friend", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSocialFriend, SocialFriend);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "Time with Friend", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialFriend, SocialFriend);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Time with Friend", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }

            }

            // SocialFriend -- DONE YEAH!!

            if (CNTSocialMedia > 4)
            {
                double[] SocialMedia = new double[CNTSocialMedia];
                double[] tempMinutesAsleepSocialMedia = new double[CNTSocialMedia];
                double[] tempAwakeningsCountSocialMedia = new double[CNTSocialMedia];
                double[] tempSleepEfficiencySocialMedia = new double[CNTSocialMedia];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialMedia != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialMedia);
                        if (tempValue >= 0)
                        {
                            SocialMedia[temp] = tempValue;
                            tempMinutesAsleepSocialMedia[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSocialMedia[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySocialMedia[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Time on social media", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "Time on social media", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Time on social media", Coefficient = pearson, Picture = "fa fa-users fa-2" });
                }

            }

            // DinnerTime -- DONE YEAH!!

            if (CNTDinnerTime > 4)
            {
                double[] DinnerTime = new double[CNTDinnerTime];
                double[] tempMinutesAsleepDinnerTime = new double[CNTDinnerTime];
                double[] tempAwakeningsCountDinnerTime = new double[CNTDinnerTime];
                double[] tempSleepEfficiencyDinnerTime = new double[CNTDinnerTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.DinnerTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.DinnerTime);
                        if (tempValue > 0)
                        {
                            DinnerTime[temp] = tempValue;
                            tempMinutesAsleepDinnerTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountDinnerTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyDinnerTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "DinnerTime", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "DinnerTime", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyDinnerTime, DinnerTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "DinnerTime", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                }

            }

            // ExerciseTime -- DONE YEAH!!

            if (CNTExerciseDuration > 4)
            {
                double[] ExerciseTime = new double[CNTExerciseDuration];
                double[] tempMinutesAsleepExerciseTime = new double[CNTExerciseDuration];
                double[] tempAwakeningsCountExerciseTime = new double[CNTExerciseDuration];
                double[] tempSleepEfficiencyExerciseTime = new double[CNTExerciseDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.ExerciseDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.ExerciseDuration);
                        if (tempValue > 0)
                        {
                            ExerciseTime[temp] = tempValue;
                            tempMinutesAsleepExerciseTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountExerciseTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyExerciseTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "ExerciseTime", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2" });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "ExerciseTime", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyExerciseTime, ExerciseTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "ExerciseTime", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2" });
                }

            }


            // AmbientTemp -- DONE YEAH!!

            if (CNTAmbientTemp > 4)
            {
                double[] AmbientTemp = new double[CNTAmbientTemp];
                double[] tempMinutesAsleepAmbientTemp = new double[CNTAmbientTemp];
                double[] tempMinutesAwakeAmbientTemp = new double[CNTAmbientTemp];
                double[] tempAwakeningsCountAmbientTemp = new double[CNTAmbientTemp];
                double[] tempMinutesToFallAsleepAmbientTemp = new double[CNTAmbientTemp];
                double[] tempSleepEfficiencyAmbientTemp = new double[CNTAmbientTemp];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.AmbientTemp != null)
                    {
                        tempValue = Convert.ToDouble(daysData.AmbientTemp);
                        if (tempValue > 0)
                        {
                            AmbientTemp[temp] = tempValue;
                            tempMinutesAsleepAmbientTemp[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAmbientTemp[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAmbientTemp[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "AmbientTemp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "AmbientTemp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAmbientTemp, AmbientTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "AmbientTemp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

            }


            // AmbientHumd -- DONE YEAH!!

            if (CNTAmbientHumd > 4)
            {
                double[] AmbientHumd = new double[CNTAmbientHumd];
                double[] tempMinutesAsleepAmbientHumd = new double[CNTAmbientHumd];
                double[] tempAwakeningsCountAmbientHumd = new double[CNTAmbientHumd];
                double[] tempSleepEfficiencyAmbientHumd = new double[CNTAmbientHumd];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.AmbientHumd != null)
                    {
                        tempValue = Convert.ToDouble(daysData.AmbientHumd);
                        if (tempValue > 0)
                        {
                            AmbientHumd[temp] = tempValue;
                            tempMinutesAsleepAmbientHumd[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAmbientHumd[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAmbientHumd[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "AmbientHumd", Coefficient = pearson, Picture = "fa fa-tint fa-2" });
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "AmbientHumd", Coefficient = pearson, Picture = "fa fa-tint fa-2" });
                }



                pearson = Correlation.Pearson(tempSleepEfficiencyAmbientHumd, AmbientHumd);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "AmbientHumd", Coefficient = pearson, Picture = "fa fa-tint fa-2" });
                }

            }


            // BodyTemp -- DONE YEAH!!

            if (CNTBodyTemp > 4)
            {
                double[] BodyTemp = new double[CNTBodyTemp];
                double[] tempMinutesAsleepBodyTemp = new double[CNTBodyTemp];
                double[] tempMinutesAwakeBodyTemp = new double[CNTBodyTemp];
                double[] tempAwakeningsCountBodyTemp = new double[CNTBodyTemp];
                double[] tempMinutesToFallAsleepBodyTemp = new double[CNTBodyTemp];
                double[] tempSleepEfficiencyBodyTemp = new double[CNTBodyTemp];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.BodyTemp != null)
                    {
                        tempValue = Convert.ToDouble(daysData.BodyTemp);
                        if (tempValue > 0)
                        {
                            BodyTemp[temp] = tempValue;
                            tempMinutesAsleepBodyTemp[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeBodyTemp[temp] = MinutesAwake[identifier];
                            tempAwakeningsCountBodyTemp[temp] = AwakeningsCount[identifier];
                            tempMinutesToFallAsleepBodyTemp[temp] = MinutesToFallAsleep[identifier];
                            tempSleepEfficiencyBodyTemp[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    minutesAsleepCorrList.Add(new CorrList() { Name = "Body Temp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

                pearson = Correlation.Pearson(tempAwakeningsCountBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    awakeCountCorrList.Add(new CorrList() { Name = "Body Temp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

                pearson = Correlation.Pearson(tempSleepEfficiencyBodyTemp, BodyTemp);
                if (Math.Abs(pearson) >= 0.3)
                {
                    sleepEffiencyCorrList.Add(new CorrList() { Name = "Body Temp", Coefficient = pearson, Picture = "fa fa-thermometer-full fa-2" });
                }

            }


            // Hormone -- DONE YEAH!!

            if (CNTHormone > 4)
            {
                double[] Hormone = new double[CNTHormone];
                double[] tempMinutesAsleepHormone = new double[CNTHormone];
                double[] tempMinutesAwakeHormone = new double[CNTHormone];
                double[] tempAwakeningsCountHormone = new double[CNTHormone];
                double[] tempMinutesToFallAsleepHormone = new double[CNTHormone];
                double[] tempSleepEfficiencyHormone = new double[CNTHormone];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.Hormone != null)
                    {
                        tempValue = Convert.ToDouble(daysData.Hormone);
                        if (tempValue > 0)
                        {
                            Hormone[temp] = tempValue;
                            tempMinutesAsleepHormone[temp] = MinutesAsleep[identifier];
                            tempMinutesAwakeHormone[temp] = MinutesAwake[identifier];
                            tempAwakeningsCountHormone[temp] = AwakeningsCount[identifier];
                            tempMinutesToFallAsleepHormone[temp] = MinutesToFallAsleep[identifier];
                            tempSleepEfficiencyHormone[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "As the next period approaches, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "As the next period approaches, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "As the next period approaches, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "As the next period approaches, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyHormone, Hormone);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "As the next period approaches, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Hormone", Coefficient = pearson, Picture = "fa fa-female fa-2", Note = "As the next period approaches, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // WatchTV -- DONE YEAH!!

            if (CNTTVDuration > 4)
            {
                double[] WatchTV = new double[CNTTVDuration];
                double[] tempMinutesAsleepWatchTV = new double[CNTTVDuration];
                double[] tempAwakeningsCountWatchTV = new double[CNTTVDuration];
                double[] tempSleepEfficiencyWatchTV = new double[CNTTVDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.TVDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.TVDuration);
                        if (tempValue > 0)
                        {
                            WatchTV[temp] = tempValue;
                            tempMinutesAsleepWatchTV[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountWatchTV[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyWatchTV[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "As you watch more TV, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "As you watch more TV, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "As you watch more TV, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "As you watch more TV, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWatchTV, WatchTV);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "As you watch more TV, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "WatchTV", Coefficient = pearson, Picture = "fa fa-television fa-2", Note = "As you watch more TV, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // ExerciseDuration -- DONE YEAH!!

            if (CNTExerciseIntensity > 4)
            {
                double[] ExerciseDuration = new double[CNTExerciseIntensity];
                double[] tempMinutesAsleepExerciseDuration = new double[CNTExerciseIntensity];
                double[] tempAwakeningsCountExerciseDuration = new double[CNTExerciseIntensity];
                double[] tempSleepEfficiencyExerciseDuration = new double[CNTExerciseIntensity];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.ExerciseIntensity != null)
                    {
                        tempValue = Convert.ToDouble(daysData.ExerciseIntensity);
                        if (tempValue > 0)
                        {
                            ExerciseDuration[temp] = tempValue;
                            tempMinutesAsleepExerciseDuration[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountExerciseDuration[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyExerciseDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "If your workout is longer, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "If your workout is longer, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "If your workout is longer, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "If your workout is longer, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyExerciseDuration, ExerciseDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "If your workout is longer, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Exercise Duration", Coefficient = pearson, Picture = "fa fa-futbol-o fa-2", Note = "If your workout is longer, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // SnackTime -- DONE YEAH!!

            if (CNTSnackTime > 4)
            {
                double[] SnackTime = new double[CNTSnackTime];
                double[] tempMinutesAsleepSnackTime = new double[CNTSnackTime];
                double[] tempAwakeningsCountSnackTime = new double[CNTSnackTime];
                double[] tempSleepEfficiencySnackTime = new double[CNTSnackTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SnackTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SnackTime);
                        if (tempValue > 0)
                        {
                            SnackTime[temp] = tempValue;
                            tempMinutesAsleepSnackTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSnackTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySnackTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySnackTime, SnackTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Snack Time", Coefficient = pearson, Picture = "fa fa-cutlery fa-2" });
                    }
                }

            }
            // WorkTime -- DONE YEAH!!

            if (CNTWorkTime > 4)
            {
                double[] WorkTime = new double[CNTWorkTime];
                double[] tempMinutesAsleepWorkTime = new double[CNTWorkTime];
                double[] tempAwakeningsCountWorkTime = new double[CNTWorkTime];
                double[] tempSleepEfficiencyWorkTime = new double[CNTWorkTime];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.WorkTime != null)
                    {
                        tempValue = Convert.ToDouble(daysData.WorkTime);
                        if (tempValue > 0)
                        {
                            WorkTime[temp] = tempValue;
                            tempMinutesAsleepWorkTime[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountWorkTime[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyWorkTime[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWorkTime, WorkTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWorkTime, WorkTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWorkTime, WorkTime);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Time", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "When your work is later, your sleep efficiency tends to become worse." });
                    }
                }

            }
            // Work Duration -- DONE YEAH!!

            if (CNTWorkDuration > 4)
            {
                double[] WorkDuration = new double[CNTWorkDuration];
                double[] tempMinutesAsleepWorkDuration = new double[CNTWorkDuration];
                double[] tempAwakeningsCountWorkDuration = new double[CNTWorkDuration];
                double[] tempSleepEfficiencyWorkDuration = new double[CNTWorkDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.WorkDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.WorkDuration);
                        if (tempValue > 0)
                        {
                            WorkDuration[temp] = tempValue;
                            tempMinutesAsleepWorkDuration[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountWorkDuration[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyWorkDuration[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepWorkDuration, WorkDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have longer time asleep." });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have shorter time asleep.." });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountWorkDuration, WorkDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have more awakenings." });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, you tend to have less awakenings." });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyWorkDuration, WorkDuration);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, your sleep efficiency tends to become better." });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Work Duration", Coefficient = pearson, Picture = "fa fa-briefcase fa-2", Note = "Working longer, your sleep efficiency tends to become worse." });
                    }
                }

            }

            // Music -- DONE YEAH!!

            if (CNTMusicDuration > 4)
            {
                double[] Music = new double[CNTMusicDuration];
                double[] tempMinutesAsleepMusic = new double[CNTMusicDuration];
                double[] tempAwakeningsCountMusic = new double[CNTMusicDuration];
                double[] tempSleepEfficiencyMusic = new double[CNTMusicDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.MusicDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.MusicDuration);
                        if (tempValue > 0)
                        {
                            Music[temp] = tempValue;
                            tempMinutesAsleepMusic[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountMusic[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyMusic[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepMusic, Music);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountMusic, Music);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyMusic, Music);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Music", Coefficient = pearson, Picture = "fa fa-headphones fa-2" });
                    }
                }

            }
            // Social Media-- DONE YEAH!!

            if (CNTSocialFriend > 4)
            {
                double[] SocialMedia = new double[CNTSocialFriend];
                double[] tempMinutesAsleepSocialMedia = new double[CNTSocialFriend];
                double[] tempAwakeningsCountSocialMedia = new double[CNTSocialFriend];
                double[] tempSleepEfficiencySocialMedia = new double[CNTSocialFriend];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SocialFriend != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SocialFriend);
                        if (tempValue > 0)
                        {
                            SocialMedia[temp] = tempValue;
                            tempMinutesAsleepSocialMedia[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountSocialMedia[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencySocialMedia[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountSocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencySocialMedia, SocialMedia);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Social Media", Coefficient = pearson, Picture = "fa fa-facebook fa-2" });
                    }
                }

            }


            // Social Media-- DONE YEAH!!

            if (CNTGamesDuration > 4)
            {
                double[] VideoGames = new double[CNTGamesDuration];
                double[] tempMinutesAsleepVideoGames = new double[CNTGamesDuration];
                double[] tempAwakeningsCountVideoGames = new double[CNTGamesDuration];
                double[] tempSleepEfficiencyVideoGames = new double[CNTGamesDuration];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.GamesDuration != null)
                    {
                        tempValue = Convert.ToDouble(daysData.GamesDuration);
                        if (tempValue > 0)
                        {
                            VideoGames[temp] = tempValue;
                            tempMinutesAsleepVideoGames[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountVideoGames[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyVideoGames[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepVideoGames, VideoGames);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountVideoGames, VideoGames);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyVideoGames, VideoGames);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Video Games", Coefficient = pearson, Picture = "fa fa-gamepad fa-2" });
                    }
                }

            }

            // Social Media-- DONE YEAH!!

            if (CNTSchoolStress > 4)
            {
                double[] Assignments = new double[CNTSchoolStress];
                double[] tempMinutesAsleepAssignments = new double[CNTSchoolStress];
                double[] tempAwakeningsCountAssignments = new double[CNTSchoolStress];
                double[] tempSleepEfficiencyAssignments = new double[CNTSchoolStress];

                // counters back to zero
                temp = 0;
                identifier = 0;

                foreach (SleepMakeSense.Models.Userdata daysData in userDatas)
                {
                    if (daysData.SchoolStress != null)
                    {
                        tempValue = Convert.ToDouble(daysData.SchoolStress);
                        if (tempValue > 0)
                        {
                            Assignments[temp] = tempValue;
                            tempMinutesAsleepAssignments[temp] = MinutesAsleep[identifier];
                            tempAwakeningsCountAssignments[temp] = AwakeningsCount[identifier];
                            tempSleepEfficiencyAssignments[temp] = SleepEfficiency[identifier];

                            temp++;
                        }
                    }
                    identifier++;
                }

                pearson = Correlation.Pearson(tempMinutesAsleepAssignments, Assignments);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        minutesAsleepCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempAwakeningsCountAssignments, Assignments);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        awakeCountCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                    }
                }


                pearson = Correlation.Pearson(tempSleepEfficiencyAssignments, Assignments);
                if (Math.Abs(pearson) >= 0.3)
                {
                    if (pearson > 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                    }
                    else if (pearson < 0)
                    {
                        sleepEffiencyCorrList.Add(new CorrList() { Name = "Assignments & Exams", Coefficient = pearson, Picture = "fa fa-graduation-cap fa-2" });
                    }
                }
            }*/

            // 20170216 Pandita: Correlation Coefficients are all positive values!!! "positive" indicates color
            foreach (var entry in minutesAsleepCorrList)
            {
                if (entry.Coefficient < 0)
                {
                    //entry.Coefficient = (entry.Coefficient) * -1;
                    entry.Positive = false;
                    // 20170216 Pandita: bad factor, red color
                }
                else
                {
                    entry.Positive = true; // good factor, blue color
                                           // rather than "Positive", maybe "Good" is more expressive?

                }
            }
            //Stress
            foreach (var entry in StressCorrList)
            {
                if (entry.Coefficient < 0)
                {
                    //negative correlation is good
                    entry.Positive = true;
                    // 20170216 Pandita: bad factor, red color
                }
                else
                {
                    entry.Positive = false; // good factor, blue color
                                           // rather than "Positive", maybe "Good" is more expressive?

                }
            }
            // 20170216 Pandita: red color indicates bad factor, not negative correlation. 
            // So for awakeCount, negatively correlated factor should be blue color, 
            // as it's a good factor for this sleep metric and lower value of this factor is preferred 
            
            foreach (var entry in awakeCountCorrList)
            {
                if (entry.Coefficient < 0)
                {
                    entry.Coefficient = (entry.Coefficient) * -1;
                    entry.Positive = false;
                }
                else
                {
                    entry.Positive = true;
                }
            }
            foreach (var entry in awakeCountCorrList)
            {
                if (entry.Coefficient < 0)
                {
                    //entry.Coefficient = (entry.Coefficient) * -1;
                    entry.Positive = true; // if negatively correlated, then a good factor
                }
                else
                {
                    entry.Positive = false;
                }
            }
            foreach (var entry in sleepEffiencyCorrList)
            {
                if (entry.Coefficient < 0)
                {
                    //entry.Coefficient = (entry.Coefficient) * -1;
                    entry.Positive = false;
                }
                else
                {
                    entry.Positive = true;
                }
            }
            foreach (var entry in ExerciceCorrList)
            {
                if (entry.Coefficient < 0)
                {
                    //entry.Coefficient = (entry.Coefficient) * -1;
                    entry.Positive = false;
                }
                else
                {
                    entry.Positive = true;
                }
            }

            syncViewModel.StressCorrList = StressCorrList.OrderByDescending(o => o.Coefficient).ToList();

            syncViewModel.MinutesAsleepCorrList = minutesAsleepCorrList.OrderByDescending(o => o.Coefficient).ToList();
            syncViewModel.ExerciseCorrList = awakeCountCorrList.OrderByDescending(o => o.Coefficient).ToList();
            syncViewModel.SleepEffiencyCorrList = sleepEffiencyCorrList.OrderByDescending(o => o.Coefficient).ToList();

            return syncViewModel;

        }
    }
}

