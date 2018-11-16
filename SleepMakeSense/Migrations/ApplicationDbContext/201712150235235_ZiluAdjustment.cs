namespace SleepMakeSense.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ZiluAdjustment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "PerceivedStress", c => c.Double());
            AddColumn("dbo.DiaryDatas", "PerceivedStress", c => c.String());
            AddColumn("dbo.UserQuestions", "PerceivedStress", c => c.Boolean(nullable: false));
            DropColumn("dbo.Userdatas", "PercievedStress");
            DropColumn("dbo.UserQuestions", "percievedStress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserQuestions", "percievedStress", c => c.Boolean(nullable: false));
            AddColumn("dbo.Userdatas", "PercievedStress", c => c.Double());
            DropColumn("dbo.UserQuestions", "PerceivedStress");
            DropColumn("dbo.DiaryDatas", "PerceivedStress");
            DropColumn("dbo.Userdatas", "PerceivedStress");
        }
    }
}
