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

    public class FitbitData
    {
        [Key]
        public int Id { get; set; }

        // Foreign key to AspNetUser
        [ForeignKey("AspNetUser")]
        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }

        public DateTime DateStamp { get; set; }
        public string SleepEfficiency { get; set; }
        public string TimeEnteredBed { get; set; }
        public string MinutesAsleep { get; set; }
        public string MinutesAwake { get; set; }
        public string TimeInBed { get; set; }
        public string AwakeningsCount { get; set; }
        public string MinutesToFallAsleep { get; set; }
        public string MinutesAfterWakeup { get; set; }
        public string Steps { get; set; }
        public string Distance { get; set; }
        public string MinutesSedentary { get; set; }
        public string MinutesLightlyActive { get; set; }
        public string MinutesFairlyActive { get; set; }
        public string MinutesVeryActive { get; set; }
        public string Water { get; set; }
        public string CaloriesIn { get; set; }
        public string CaloriesOut { get; set; }
        public string ActivityCalories { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string Fat { get; set; }
    }
}