namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldChange1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "ClubTeam", c => c.String());
            AddColumn("dbo.Profiles", "ContractDateFrom", c => c.DateTime());
            AddColumn("dbo.Profiles", "ContractDateTo", c => c.DateTime());
            AddColumn("dbo.Profiles", "ManagementCompany", c => c.String());
            AddColumn("dbo.Profiles", "Nationality", c => c.String());
            AddColumn("dbo.Profiles", "PlayingPosition", c => c.String());
            AddColumn("dbo.Profiles", "SignedBy", c => c.String());
            DropColumn("dbo.Profiles", "CurrentClubTeam");
            DropColumn("dbo.Profiles", "CurrentContractDates");
            DropColumn("dbo.Profiles", "CurrentManagementCompany");
            DropColumn("dbo.Profiles", "CurrentPlayingPosition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "CurrentPlayingPosition", c => c.String());
            AddColumn("dbo.Profiles", "CurrentManagementCompany", c => c.String());
            AddColumn("dbo.Profiles", "CurrentContractDates", c => c.DateTime());
            AddColumn("dbo.Profiles", "CurrentClubTeam", c => c.String());
            DropColumn("dbo.Profiles", "SignedBy");
            DropColumn("dbo.Profiles", "PlayingPosition");
            DropColumn("dbo.Profiles", "Nationality");
            DropColumn("dbo.Profiles", "ManagementCompany");
            DropColumn("dbo.Profiles", "ContractDateTo");
            DropColumn("dbo.Profiles", "ContractDateFrom");
            DropColumn("dbo.Profiles", "ClubTeam");
        }
    }
}
