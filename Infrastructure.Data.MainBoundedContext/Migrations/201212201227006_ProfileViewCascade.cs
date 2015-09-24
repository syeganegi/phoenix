namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileViewCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfileViews", "ViewedId", "dbo.Profiles");
            DropIndex("dbo.ProfileViews", new[] { "ViewedId" });
            AddForeignKey("dbo.ProfileViews", "ViewedId", "dbo.Profiles", "Id", cascadeDelete: true);
            CreateIndex("dbo.ProfileViews", "ViewedId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProfileViews", new[] { "ViewedId" });
            DropForeignKey("dbo.ProfileViews", "ViewedId", "dbo.Profiles");
            CreateIndex("dbo.ProfileViews", "ViewedId");
            AddForeignKey("dbo.ProfileViews", "ViewedId", "dbo.Profiles", "Id");
        }
    }
}
