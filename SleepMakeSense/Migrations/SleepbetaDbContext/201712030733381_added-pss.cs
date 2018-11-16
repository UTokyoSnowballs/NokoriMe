namespace SleepMakeSense.Migrations.SleepbetaDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiaryDatas", "pss1", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss2", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss3", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss4", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss5", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss6", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss7", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss8", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss9", c => c.String());
            AddColumn("dbo.DiaryDatas", "pss10", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiaryDatas", "pss10");
            DropColumn("dbo.DiaryDatas", "pss9");
            DropColumn("dbo.DiaryDatas", "pss8");
            DropColumn("dbo.DiaryDatas", "pss7");
            DropColumn("dbo.DiaryDatas", "pss6");
            DropColumn("dbo.DiaryDatas", "pss5");
            DropColumn("dbo.DiaryDatas", "pss4");
            DropColumn("dbo.DiaryDatas", "pss3");
            DropColumn("dbo.DiaryDatas", "pss2");
            DropColumn("dbo.DiaryDatas", "pss1");
        }
    }
}
