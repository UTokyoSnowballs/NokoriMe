using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    // Pandita: define vector in correlation coefficient array

    public class CorrList
    {
        public string Name { get; set;}
        public double Coefficient { get; set;}
        public string Note { get; set; }
        public bool Positive { get; set; }
        public string Picture { get; set; }

        // ToDO: Significance test
        // public double significance { get; set;}
        
    }
}