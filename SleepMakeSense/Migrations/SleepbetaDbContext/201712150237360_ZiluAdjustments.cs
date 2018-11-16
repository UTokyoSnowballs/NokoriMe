namespace SleepMakeSense.Migrations.SleepbetaDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZiluAdjustments : DbMigration
    {
        public override void Up()
        {

           
            //AddColumn("dbo.DiaryDatas", "PerceivedStress", c => c.String());
            //AddColumn("dbo.UserQuestions", "PerceivedStress", c => c.Boolean(nullable: false));
            //DropColumn("dbo.UserQuestions", "percievedStress");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.UserQuestions", "percievedStress", c => c.Boolean(nullable: false));
           // DropColumn("dbo.UserQuestions", "PerceivedStress");
           // DropColumn("dbo.DiaryDatas", "PerceivedStress");
        }
    }
}
