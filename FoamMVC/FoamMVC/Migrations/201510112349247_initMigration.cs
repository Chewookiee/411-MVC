namespace FoamMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PalletGroupID = c.Int(nullable: false),
                        CompanyID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                        UPC = c.String(),
                        IsFeatured = c.Boolean(nullable: false),
                        ImagePath = c.String(),
                        StockCount = c.Int(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.PalletGroups", t => t.PalletGroupID, cascadeDelete: true)
                .Index(t => t.PalletGroupID)
                .Index(t => t.CompanyID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PrimaryLocation = c.String(),
                        SecondaryLocation = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        IsLiked = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ItemID);
            
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
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.ReviewScoreForDescriptors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReviewID = c.Int(nullable: false),
                        PalletDescriptorID = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PalletDescriptors", t => t.PalletDescriptorID, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewID, cascadeDelete: true)
                .Index(t => t.ReviewID)
                .Index(t => t.PalletDescriptorID);
            
            CreateTable(
                "dbo.PalletDescriptors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PalletGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserScoreForDescriptors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PalletDescriptorID = c.Int(nullable: false),
                        UserSelectedScore = c.Int(nullable: false),
                        GeneratedScore = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PalletDescriptors", t => t.PalletDescriptorID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PalletDescriptorID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        DateDeleted = c.DateTime(),
                        DateUpdated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PalletDescriptorCategories",
                c => new
                    {
                        PalletDescriptor_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PalletDescriptor_ID, t.Category_ID })
                .ForeignKey("dbo.PalletDescriptors", t => t.PalletDescriptor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.PalletDescriptor_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.PalletGroupPalletDescriptors",
                c => new
                    {
                        PalletGroup_ID = c.Int(nullable: false),
                        PalletDescriptor_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PalletGroup_ID, t.PalletDescriptor_ID })
                .ForeignKey("dbo.PalletGroups", t => t.PalletGroup_ID, cascadeDelete: true)
                .ForeignKey("dbo.PalletDescriptors", t => t.PalletDescriptor_ID, cascadeDelete: true)
                .Index(t => t.PalletGroup_ID)
                .Index(t => t.PalletDescriptor_ID);
            
            CreateTable(
                "dbo.TagItems",
                c => new
                    {
                        Tag_ID = c.Int(nullable: false),
                        Item_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_ID, t.Item_ID })
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_ID, cascadeDelete: true)
                .Index(t => t.Tag_ID)
                .Index(t => t.Item_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TagItems", "Item_ID", "dbo.Items");
            DropForeignKey("dbo.TagItems", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.Reviews", "UserID", "dbo.Users");
            DropForeignKey("dbo.ReviewScoreForDescriptors", "ReviewID", "dbo.Reviews");
            DropForeignKey("dbo.UserScoreForDescriptors", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserScoreForDescriptors", "PalletDescriptorID", "dbo.PalletDescriptors");
            DropForeignKey("dbo.ReviewScoreForDescriptors", "PalletDescriptorID", "dbo.PalletDescriptors");
            DropForeignKey("dbo.PalletGroupPalletDescriptors", "PalletDescriptor_ID", "dbo.PalletDescriptors");
            DropForeignKey("dbo.PalletGroupPalletDescriptors", "PalletGroup_ID", "dbo.PalletGroups");
            DropForeignKey("dbo.Items", "PalletGroupID", "dbo.PalletGroups");
            DropForeignKey("dbo.PalletDescriptorCategories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.PalletDescriptorCategories", "PalletDescriptor_ID", "dbo.PalletDescriptors");
            DropForeignKey("dbo.Reviews", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Likes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Likes", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Companies", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Items", "CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Items", "CategoryID", "dbo.Categories");
            DropIndex("dbo.TagItems", new[] { "Item_ID" });
            DropIndex("dbo.TagItems", new[] { "Tag_ID" });
            DropIndex("dbo.PalletGroupPalletDescriptors", new[] { "PalletDescriptor_ID" });
            DropIndex("dbo.PalletGroupPalletDescriptors", new[] { "PalletGroup_ID" });
            DropIndex("dbo.PalletDescriptorCategories", new[] { "Category_ID" });
            DropIndex("dbo.PalletDescriptorCategories", new[] { "PalletDescriptor_ID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserScoreForDescriptors", new[] { "PalletDescriptorID" });
            DropIndex("dbo.UserScoreForDescriptors", new[] { "UserID" });
            DropIndex("dbo.ReviewScoreForDescriptors", new[] { "PalletDescriptorID" });
            DropIndex("dbo.ReviewScoreForDescriptors", new[] { "ReviewID" });
            DropIndex("dbo.Reviews", new[] { "ItemID" });
            DropIndex("dbo.Reviews", new[] { "UserID" });
            DropIndex("dbo.Likes", new[] { "ItemID" });
            DropIndex("dbo.Likes", new[] { "UserID" });
            DropIndex("dbo.Companies", new[] { "LocationID" });
            DropIndex("dbo.Items", new[] { "CategoryID" });
            DropIndex("dbo.Items", new[] { "CompanyID" });
            DropIndex("dbo.Items", new[] { "PalletGroupID" });
            DropTable("dbo.TagItems");
            DropTable("dbo.PalletGroupPalletDescriptors");
            DropTable("dbo.PalletDescriptorCategories");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tags");
            DropTable("dbo.UserScoreForDescriptors");
            DropTable("dbo.PalletGroups");
            DropTable("dbo.PalletDescriptors");
            DropTable("dbo.ReviewScoreForDescriptors");
            DropTable("dbo.Reviews");
            DropTable("dbo.Users");
            DropTable("dbo.Likes");
            DropTable("dbo.Locations");
            DropTable("dbo.Companies");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
