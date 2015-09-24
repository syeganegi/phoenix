namespace Phoenix.PhoenixApp.Infrastructure.Data.MainBoundedContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedProfilePicture : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeletedProfiles", "Picture_Id", "dbo.Profiles");
            DropIndex("dbo.DeletedProfiles", new[] { "Picture_Id" });
            AddColumn("dbo.DeletedProfiles", "Picture", c => c.Binary());
            DropColumn("dbo.DeletedProfiles", "Picture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeletedProfiles", "Picture_Id", c => c.Guid());
            DropColumn("dbo.DeletedProfiles", "Picture");
            CreateIndex("dbo.DeletedProfiles", "Picture_Id");
            AddForeignKey("dbo.DeletedProfiles", "Picture_Id", "dbo.Profiles", "Id");
        }
    }
}
