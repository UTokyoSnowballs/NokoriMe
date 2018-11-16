namespace SleepMakeSense.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingToUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "pss1", c => c.Double());
            AddColumn("dbo.Userdatas", "pss2", c => c.Double());
            AddColumn("dbo.Userdatas", "pss3", c => c.Double());
            AddColumn("dbo.Userdatas", "pss4", c => c.Double());
            AddColumn("dbo.Userdatas", "pss5", c => c.Double());
            AddColumn("dbo.Userdatas", "pss6", c => c.Double());
            AddColumn("dbo.Userdatas", "pss7", c => c.Double());
            AddColumn("dbo.Userdatas", "pss8", c => c.Double());
            AddColumn("dbo.Userdatas", "pss9", c => c.Double());
            AddColumn("dbo.Userdatas", "pss10", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Userdatas", "pss10");
            DropColumn("dbo.Userdatas", "pss9");
            DropColumn("dbo.Userdatas", "pss8");
            DropColumn("dbo.Userdatas", "pss7");
            DropColumn("dbo.Userdatas", "pss6");
            DropColumn("dbo.Userdatas", "pss5");
            DropColumn("dbo.Userdatas", "pss4");
            DropColumn("dbo.Userdatas", "pss3");
            DropColumn("dbo.Userdatas", "pss2");
            DropColumn("dbo.Userdatas", "pss1");
        }
    }
}
