namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Posts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ProfileId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Posts", new[] { "ProfileId" });
            DropForeignKey("dbo.Posts", "ProfileId", "dbo.Profiles");
            DropTable("dbo.Posts");
        }
    }
}
