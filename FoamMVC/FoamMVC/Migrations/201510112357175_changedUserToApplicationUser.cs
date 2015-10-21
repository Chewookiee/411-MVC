namespace FoamMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserToApplicationUser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PalletGroupPalletDescriptors", newName: "PalletDescriptorPalletGroups");
            DropForeignKey("dbo.Likes", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserScoreForDescriptors", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Users");
            DropIndex("dbo.Likes", new[] { "UserID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.UserScoreForDescriptors", new[] { "UserID" });
            DropPrimaryKey("dbo.PalletDescriptorPalletGroups");
            AddColumn("dbo.Likes", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Likes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.UserScoreForDescriptors", "ApplicationUserID", c => c.Int(nullable: false));
            AddColumn("dbo.UserScoreForDescriptors", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.PalletDescriptorPalletGroups", new[] { "PalletDescriptor_ID", "PalletGroup_ID" });
            CreateIndex("dbo.Likes", "ApplicationUser_Id");
            CreateIndex("dbo.Reviews", "ApplicationUser_Id");
            CreateIndex("dbo.UserScoreForDescriptors", "ApplicationUser_Id");
            AddForeignKey("dbo.Likes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserScoreForDescriptors", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Likes", "UserID");
            DropColumn("dbo.Reviews", "UserID");
            DropColumn("dbo.UserScoreForDescriptors", "UserID");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.UserScoreForDescriptors", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Likes", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserScoreForDescriptors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserScoreForDescriptors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Likes", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.PalletDescriptorPalletGroups");
            DropColumn("dbo.UserScoreForDescriptors", "ApplicationUser_Id");
            DropColumn("dbo.UserScoreForDescriptors", "ApplicationUserID");
            DropColumn("dbo.Reviews", "ApplicationUser_Id");
            DropColumn("dbo.Reviews", "ApplicationUserID");
            DropColumn("dbo.Likes", "ApplicationUser_Id");
            DropColumn("dbo.Likes", "ApplicationUserID");
            AddPrimaryKey("dbo.PalletDescriptorPalletGroups", new[] { "PalletGroup_ID", "PalletDescriptor_ID" });
            CreateIndex("dbo.UserScoreForDescriptors", "UserID");
            CreateIndex("dbo.Reviews", "UserID");
            CreateIndex("dbo.Likes", "UserID");
            AddForeignKey("dbo.Reviews", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserScoreForDescriptors", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Likes", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            RenameTable(name: "dbo.PalletDescriptorPalletGroups", newName: "PalletGroupPalletDescriptors");
        }
    }
}
