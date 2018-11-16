namespace SleepMakeSense.Migrations.SleepbetaDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpercievedstresssetuptable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserQuestions", "percievedStress", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserQuestions", "percievedStress");
        }
    }
}
