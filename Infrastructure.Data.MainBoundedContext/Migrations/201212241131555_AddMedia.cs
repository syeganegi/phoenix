namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medias",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        MediaUrl = c.String(nullable: false, maxLength: 256),
                        ProfileId = c.Guid(nullable: false),
                        Title = c.String(maxLength: 256),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Medias", new[] { "ProfileId" });
            DropForeignKey("dbo.Medias", "ProfileId", "dbo.Profiles");
            DropTable("dbo.Medias");
        }
    }
}
