namespace SleepMakeSense.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Userdatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        DateStamp = c.DateTime(nullable: false),
                        MinutesAsleep = c.Double(),
                        MinutesAwake = c.Double(),
                        AwakeningsCount = c.Double(),
                        TimeInBed = c.Double(),
                        MinutesToFallAsleep = c.Double(),
                        MinutesAfterWakeup = c.Double(),
                        SleepEfficiency = c.Double(),
                        CaloriesIn = c.Double(),
                        Water = c.Double(),
                        CaloriesOut = c.Double(),
                        Steps = c.Double(),
                        Distance = c.Double(),
                        MinutesSedentary = c.Double(),
                        MinutesLightlyActive = c.Double(),
                        MinutesFairlyActive = c.Double(),
                        MinutesVeryActive = c.Double(),
                        ActivityCalories = c.Double(),
                        TimeEnteredBed = c.Time(precision: 7),
                        Weight = c.Double(),
                        BMI = c.Double(),
                        Fat = c.Double(),
                        WakeUpFreshness = c.Double(),
                        Mood = c.Double(),
                        Stress = c.Double(),
                        Tiredness = c.Double(),
                        Dream = c.Double(),
                        BodyTemp = c.Double(),
                        Hormone = c.Double(),
                        SchoolStress = c.Double(),
                        CoffeeAmt = c.Double(),
                        CoffeeTime = c.DateTime(),
                        AlcoholAmt = c.Double(),
                        AlcoholTime = c.DateTime(),
                        NapTime = c.DateTime(),
                        NapDuration = c.Double(),
                        SocialFamily = c.Double(),
                        SocialFriend = c.Double(),
                        DigDeviceDuration = c.Double(),
                        GamesDuration = c.Double(),
                        SocialMedia = c.Double(),
                        MusicDuration = c.Double(),
                        TVDuration = c.Double(),
                        WorkTime = c.DateTime(),
                        WorkDuration = c.Double(),
                        ExerciseDuration = c.Double(),
                        ExerciseIntensity = c.Double(),
                        DinnerTime = c.DateTime(),
                        SnackTime = c.DateTime(),
                        AmbientTemp = c.Double(),
                        AmbientHumd = c.Double(),
                        Light = c.Double(),
                        SunRiseTime = c.DateTime(),
                        SunSetTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            /*CreateTable(
                "dbo.AspNetUsers1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);*/
            
            CreateTable(
                "dbo.DiaryDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        DateStamp = c.DateTime(nullable: false),
                        WakeUpFreshness = c.String(),
                        Mood = c.String(),
                        Stress = c.String(),
                        Tiredness = c.String(),
                        Dream = c.String(),
                        BodyTemp = c.String(),
                        Hormone = c.String(),
                        SchoolStress = c.String(),
                        CoffeeAmt = c.String(),
                        CoffeeTime = c.String(),
                        AlcoholAmt = c.String(),
                        AlcoholTime = c.String(),
                        NapTime = c.String(),
                        NapDuration = c.String(),
                        DigDeviceDuration = c.String(),
                        GamesDuration = c.String(),
                        SocialFamily = c.String(),
                        SocialFriend = c.String(),
                        MusicDuration = c.String(),
                        TVDuration = c.String(),
                        WorkTime = c.String(),
                        WorkDuration = c.String(),
                        ExerciseDuration = c.String(),
                        ExerciseIntensity = c.String(),
                        DinnerTime = c.String(),
                        SnackTime = c.String(),
                        AmbientTemp = c.String(),
                        AmbientHumd = c.String(),
                        Light = c.String(),
                        SunRiseTime = c.String(),
                        SunSetTime = c.String(),
                        SocialMedia = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.FitbitDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        DateStamp = c.DateTime(nullable: false),
                        SleepEfficiency = c.String(),
                        TimeEnteredBed = c.String(),
                        MinutesAsleep = c.String(),
                        MinutesAwake = c.String(),
                        TimeInBed = c.String(),
                        AwakeningsCount = c.String(),
                        MinutesToFallAsleep = c.String(),
                        MinutesAfterWakeup = c.String(),
                        Steps = c.String(),
                        Distance = c.String(),
                        MinutesSedentary = c.String(),
                        MinutesLightlyActive = c.String(),
                        MinutesFairlyActive = c.String(),
                        MinutesVeryActive = c.String(),
                        Water = c.String(),
                        CaloriesIn = c.String(),
                        CaloriesOut = c.String(),
                        ActivityCalories = c.String(),
                        Weight = c.String(),
                        BMI = c.String(),
                        Fat = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.TokenManagements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AspNetUserId = c.String(maxLength: 128),
                        Token = c.String(),
                        TokenType = c.String(),
                        ExpiresIn = c.Int(nullable: false),
                        RefreshToken = c.String(),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.UserQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AspNetUserId = c.String(maxLength: 128),
                        WakeUpFreshness = c.Boolean(nullable: false),
                        Mood = c.Boolean(nullable: false),
                        Stress = c.Boolean(nullable: false),
                        Tiredness = c.Boolean(nullable: false),
                        Dream = c.Boolean(nullable: false),
                        SchoolQuestions = c.Boolean(nullable: false),
                        CoffeeQuestions = c.Boolean(nullable: false),
                        AlcoholQuestions = c.Boolean(nullable: false),
                        NapQuestions = c.Boolean(nullable: false),
                        DigDeviceDurationQuestion = c.Boolean(nullable: false),
                        GameDurationQuestion = c.Boolean(nullable: false),
                        SocialMediaDurationQuestion = c.Boolean(nullable: false),
                        SocialActivityDurationQuestion = c.Boolean(nullable: false),
                        MusicDurationQuestion = c.Boolean(nullable: false),
                        TVDurationQuestion = c.Boolean(nullable: false),
                        WorkQuestions = c.Boolean(nullable: false),
                        ExersiseQuestions = c.Boolean(nullable: false),
                        FoodQuestions = c.Boolean(nullable: false),
                        GenderHormoneQuestion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AspNetUserId)
                .Index(t => t.AspNetUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Userdatas", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserQuestions", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TokenManagements", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FitbitDatas", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DiaryDatas", "AspNetUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserQuestions", new[] { "AspNetUserId" });
            DropIndex("dbo.TokenManagements", new[] { "AspNetUserId" });
            DropIndex("dbo.FitbitDatas", new[] { "AspNetUserId" });
            DropIndex("dbo.DiaryDatas", new[] { "AspNetUserId" });
            DropIndex("dbo.Userdatas", new[] { "AspNetUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserQuestions");
            DropTable("dbo.TokenManagements");
            DropTable("dbo.FitbitDatas");
            DropTable("dbo.DiaryDatas");
            //DropTable("dbo.AspNetUsers");
            DropTable("dbo.Userdatas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
