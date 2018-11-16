namespace SleepMakeSense.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Userdata 
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to AspNetUser
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }

        public DateTime DateStamp { get; set; }

        public double? MinutesAsleep { get; set; }

        public double? MinutesAwake { get; set; }

        public double? AwakeningsCount { get; set; }

        public double? TimeInBed { get; set; }

        public double? MinutesToFallAsleep { get; set; }

        public double? MinutesAfterWakeup { get; set; }

        public double? SleepEfficiency { get; set; }

        public double? CaloriesIn { get; set; }

        public double? Water { get; set; }

        public double? CaloriesOut { get; set; }

        public double? Steps { get; set; }

        public double? Distance { get; set; }

        public double? MinutesSedentary { get; set; }

        public double? MinutesLightlyActive { get; set; }

        public double? MinutesFairlyActive { get; set; }

        public double? MinutesVeryActive { get; set; }

        public double? ActivityCalories { get; set; }

        public TimeSpan? TimeEnteredBed { get; set; }

        public double? Weight { get; set; }

        public double? BMI { get; set; }

        public double? Fat { get; set; }

        //Diary Data
        public double? PerceivedStress { get; set; }
        public double? pss1 { get; set; }
        public double? pss2 { get; set; }
        public double? pss3 { get; set; }
        public double? pss4 { get; set; }
        public double? pss5 { get; set; }
        public double? pss6 { get; set; }
        public double? pss7 { get; set; }
        public double? pss8 { get; set; }
        public double? pss9 { get; set; }
        public double? pss10 { get; set; }

        public double? WakeUpFreshness { get; set; }

        public double? Mood { get; set; }

        public double? Stress { get; set; }

        public double? Tiredness { get; set; }

        public double? Dream { get; set; }

        public double? BodyTemp { get; set; }

        public double? Hormone { get; set; }

        public double? SchoolStress { get; set; }

        public double? CoffeeAmt { get; set; }

        public DateTime? CoffeeTime { get; set; }

        public double? AlcoholAmt { get; set; }

        public DateTime? AlcoholTime { get; set; }

        public DateTime? NapTime { get; set; }

        public double? NapDuration { get; set; }

        // 230170214 Pandita: added social time spent with family and friends before bed time
        public double? SocialFamily { get; set; }

        public double? SocialFriend { get; set; }

        public double? DigDeviceDuration { get; set; }

        public double? GamesDuration { get; set; }

        // 20170214 Pandita: added social media
        public double? SocialMedia { get; set; }

        //public double? SocialActivity { get; set; }

        public double? MusicDuration { get; set; }

        public double? TVDuration { get; set; }

        public DateTime? WorkTime { get; set; }

        public double? WorkDuration { get; set; }

        public double? ExerciseDuration { get; set; }

        public double? ExerciseIntensity { get; set; }

        public DateTime? DinnerTime { get; set; }

        public DateTime? SnackTime { get; set; }

        public double? AmbientTemp { get; set; }

        public double? AmbientHumd { get; set; }

        public double? Light { get; set; }

        public DateTime? SunRiseTime { get; set; }

        public DateTime? SunSetTime { get; set; }

    }
}
