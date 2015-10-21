namespace FoamMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StagedItemsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StagedItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UPC = c.String(),
                        StockCount = c.Int(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StagedItems");
        }
    }
}
