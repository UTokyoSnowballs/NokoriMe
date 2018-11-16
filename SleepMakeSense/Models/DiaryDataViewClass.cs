using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SleepMakeSense.Models
{
    public class DiaryDataViewClass
    {
       public  UserQuestions UserQuestion { get; set; }

        public QuestionsSelections QUESTIONSELECTION { get; set; }

        public DiaryData DiaryData { get; set; }

    }
}