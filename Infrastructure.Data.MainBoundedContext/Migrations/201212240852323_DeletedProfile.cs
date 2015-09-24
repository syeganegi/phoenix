namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeletedProfiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        About = c.String(),
                        Achievements = c.String(),
                        Address_AddressLine1 = c.String(),
                        Address_AddressLine2 = c.String(),
                        Address_City = c.String(),
                        Address_ZipCode = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        ClubTeam = c.String(),
                        CollegeUniversity = c.String(),
                        ContractDateFrom = c.DateTime(),
                        ContractDateTo = c.DateTime(),
                        CurrentCity = c.String(),
                        DateDeleted = c.DateTime(nullable: false),
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
                        ManagementCompany = c.String(),
                        MobilePhone = c.String(),
                        Nationality = c.String(),
                        OverseasOpportunities = c.String(),
                        PlayingPosition = c.String(),
                        PoliticalViews = c.String(),
                        RelationshipStatus = c.Int(nullable: false),
                        Religion = c.String(),
                        Results = c.String(),
                        Resume = c.String(),
                        SchoolAchievements = c.String(),
                        SecondarySchool = c.String(),
                        Sex = c.Int(nullable: false),
                        SignedBy = c.String(),
                        Sport = c.String(),
                        SportAchievements = c.String(),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ViewCounter = c.Long(nullable: false),
                        Website = c.String(),
                        Weight = c.String(),
                        WorkPhone = c.String(),
                        Picture_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Picture_Id)
                .Index(t => t.Picture_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.DeletedProfiles", new[] { "Picture_Id" });
            DropForeignKey("dbo.DeletedProfiles", "Picture_Id", "dbo.Profiles");
            DropTable("dbo.DeletedProfiles");
        }
    }
}
