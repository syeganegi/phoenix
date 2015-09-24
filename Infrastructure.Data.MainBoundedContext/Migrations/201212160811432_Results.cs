namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Results : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Results", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Results");
        }
    }
}
