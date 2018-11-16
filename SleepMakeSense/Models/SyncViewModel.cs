using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SleepMakeSense.Models
{
    public class SyncViewModel
    {
        public List<CorrList> StressCorrList { get; set; }

        public List<CorrList> MinutesAsleepCorrList { get; set; }

        public List<CorrList> ExerciseCorrList { get; set; }

        public List<CorrList> SleepEffiencyCorrList { get; set; }

        public List<Userdata> UserData { get; set; }

    }
}

