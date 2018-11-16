using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// 20171023 Pandita: reimplement using EF
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SleepMakeSense.Models
{
    public class DiaryData
    {
        [Key]
        public int Id { get; set; }
        //public Guid Id { get; set; }

        // Foreign key to AspNetUser
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }
        public DateTime DateStamp { get; set; }

        public string PerceivedStress { get; set; }
        public string pss1 { get; set; }
        public string pss2 { get; set; }
        public string pss3 { get; set; }
        public string pss4 { get; set; }
        public string pss5 { get; set; }
        public string pss6 { get; set; }
        public string pss7 { get; set; }
        public string pss8 { get; set; }
        public string pss9 { get; set; }
        public string pss10 { get; set; }


        public string WakeUpFreshness { get; set; }
        public string Mood { get; set; }
        public string Stress { get; set; }
        public string Tiredness { get; set; }
        public string Dream { get; set; }
        public string BodyTemp { get; set; }
        public string Hormone { get; set; }
        public string SchoolStress { get; set; }
        public string CoffeeAmt { get; set; }
        public string CoffeeTime { get; set; }
        public string AlcoholAmt { get; set; }
        public string AlcoholTime { get; set; }
        public string NapTime { get; set; }
        public string NapDuration { get; set; }
        public string DigDeviceDuration { get; set; }
        public string GamesDuration { get; set; }
        public string SocialFamily { get; set; }
        public string SocialFriend { get; set; }
        public string MusicDuration { get; set; }
        public string TVDuration { get; set; }
        public string WorkTime { get; set; }
        public string WorkDuration { get; set; }
        public string ExerciseDuration { get; set; }
        public string ExerciseIntensity { get; set; }
        public string DinnerTime { get; set; }
        public string SnackTime { get; set; }
        public string AmbientTemp { get; set; }
        public string AmbientHumd { get; set; }
        public string Light { get; set; }
        public string SunRiseTime { get; set; }
        public string SunSetTime { get; set; }
        public string SocialMedia { get; set; }

        /*public void Add(Models.DiaryData diaryData)
        {
            throw new NotImplementedException();
        }*/

    }
}