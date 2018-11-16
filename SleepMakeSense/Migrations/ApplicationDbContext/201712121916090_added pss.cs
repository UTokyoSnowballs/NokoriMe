namespace SleepMakeSense.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Userdatas", "PercievedStress", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Userdatas", "PercievedStress");
        }
    }
}
