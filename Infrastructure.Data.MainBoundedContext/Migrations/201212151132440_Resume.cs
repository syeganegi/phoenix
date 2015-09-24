namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resume : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Resume", c => c.String());
            AddColumn("dbo.Profiles", "Achievements", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Achievements");
            DropColumn("dbo.Profiles", "Resume");
        }
    }
}
