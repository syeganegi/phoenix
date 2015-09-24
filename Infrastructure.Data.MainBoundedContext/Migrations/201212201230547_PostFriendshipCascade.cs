namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostFriendshipCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friendships", "InitiatorId", "dbo.Profiles");
            DropForeignKey("dbo.Posts", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Friendships", new[] { "InitiatorId" });
            DropIndex("dbo.Posts", new[] { "ProfileId" });
            AddForeignKey("dbo.Friendships", "InitiatorId", "dbo.Profiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
            CreateIndex("dbo.Friendships", "InitiatorId");
            CreateIndex("dbo.Posts", "ProfileId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "ProfileId" });
            DropIndex("dbo.Friendships", new[] { "InitiatorId" });
            DropForeignKey("dbo.Posts", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Friendships", "InitiatorId", "dbo.Profiles");
            CreateIndex("dbo.Posts", "ProfileId");
            CreateIndex("dbo.Friendships", "InitiatorId");
            AddForeignKey("dbo.Posts", "ProfileId", "dbo.Profiles", "Id");
            AddForeignKey("dbo.Friendships", "InitiatorId", "dbo.Profiles", "Id");
        }
    }
}
