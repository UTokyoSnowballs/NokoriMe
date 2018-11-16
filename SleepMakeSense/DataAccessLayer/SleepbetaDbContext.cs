using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SleepMakeSense.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;

namespace SleepMakeSense.DataAccessLayer
{
    public class SleepbetaDataContext : DbContext
    {
        public SleepbetaDataContext() : base("SleepBetaConnectionString")
        {
        }

        //public DbSet<AspNetUser> AspNetUser { get; set; }
        public DbSet<DiaryData> DiaryData { get; set; }
        public DbSet<FitbitData> FitbitData { get; set; }
        public DbSet<UserQuestions> UserQuestions { get; set; }
        // 20171026 Pandita: Removed Token table
        //public DbSet<TokenManagement> TokenManagement { get; set; }

        public static SleepbetaDataContext Create()
        {
            return new SleepbetaDataContext();
        }

        // Specifying singular table names
        // The modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents table names from being pluralized.
        // If you didn't do this, the generated tables in the database would be named "FitbitDatas" instead of "FitbitData"
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/

        /*
        internal void SaveChanges(int id)
        {
            throw new NotImplementedException();
        }
        */

    }
}