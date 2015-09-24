namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AcceptorId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateStatusChanged = c.DateTime(nullable: false),
                        InitiatorId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.AcceptorId)
                .ForeignKey("dbo.Profiles", t => t.InitiatorId)
                .Index(t => t.AcceptorId)
                .Index(t => t.InitiatorId);
            
            CreateTable(
                "dbo.InstanceMessages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InstanceMessageType = c.Int(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        ScreenName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RawPhoto = c.Binary(),
                        About = c.String(),
                        Address_AddressLine1 = c.String(),
                        Address_AddressLine2 = c.String(),
                        Address_City = c.String(),
                        Address_ZipCode = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        CollegeUniversity = c.String(),
                        CurrentCity = c.String(),
                        CurrentClubTeam = c.String(),
                        CurrentContractDates = c.DateTime(),
                        CurrentManagementCompany = c.String(),
                        CurrentPlayingPosition = c.String(),
                        Email = c.String(),
                        FavoriteSportingIdol = c.String(),
                        FavouriteOtherSport = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(),
                        Height = c.String(),
                        HomePhone = c.String(),
                        Hometown = c.String(),
                        InterestedIn = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Job = c.String(),
                        Languages = c.String(),
                        LastName = c.String(nullable: false, maxLength: 100),
                        MobilePhone = c.String(),
                        OverseasOpportunities = c.String(),
                        PoliticalViews = c.String(),
                        RelationshipStatus = c.Int(nullable: false),
                        Religion = c.String(),
                        SchoolAchievements = c.String(),
                        SecondarySchool = c.String(),
                        Sex = c.Int(nullable: false),
                        Sport = c.String(),
                        SportAchievements = c.String(),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ViewCounter = c.Long(nullable: false),
                        Website = c.String(),
                        Weight = c.String(),
                        WorkPhone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileViews",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateViewed = c.DateTime(nullable: false),
                        ViewedId = c.Guid(nullable: false),
                        ViewerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ViewedId)
                .ForeignKey("dbo.Profiles", t => t.ViewerId)
                .Index(t => t.ViewedId)
                .Index(t => t.ViewerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProfileViews", new[] { "ViewerId" });
            DropIndex("dbo.ProfileViews", new[] { "ViewedId" });
            DropIndex("dbo.InstanceMessages", new[] { "ProfileId" });
            DropIndex("dbo.Friendships", new[] { "InitiatorId" });
            DropIndex("dbo.Friendships", new[] { "AcceptorId" });
            DropForeignKey("dbo.ProfileViews", "ViewerId", "dbo.Profiles");
            DropForeignKey("dbo.ProfileViews", "ViewedId", "dbo.Profiles");
            DropForeignKey("dbo.InstanceMessages", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Friendships", "InitiatorId", "dbo.Profiles");
            DropForeignKey("dbo.Friendships", "AcceptorId", "dbo.Profiles");
            DropTable("dbo.ProfileViews");
            DropTable("dbo.Profiles");
            DropTable("dbo.InstanceMessages");
            DropTable("dbo.Friendships");
        }
    }
}
