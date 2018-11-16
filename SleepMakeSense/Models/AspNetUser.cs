using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// 20171023 Pandita: added from the Sleepbeta.designer.cs
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;

namespace SleepMakeSense.Models
{
    public class AspNetUser
    {
        public AspNetUser() {
            }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public List<DiaryData> DiaryDatas { get; set; }
        public List<FitbitData> FitbitDatas { get; set; }
        public List<UserQuestions> UserQuestions { get; set; }
        public List<TokenManagement> TokenManagements { get; set; }

    }
}

// 20171022 Pandita: Create AspNetUser using EF 
// Probably try to use ICollection<DiaryData> DiaryDatas { get; set;} or HashSet<DiaryData> DiaryDatas { get; set;}, so that there is no duplicate entries?
