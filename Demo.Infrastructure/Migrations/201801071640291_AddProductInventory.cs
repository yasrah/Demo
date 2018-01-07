namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductInventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DealerProductInventories",
                c => new
                    {
                        DealerId = c.Int(nullable: false),
                        ProductId = c.String(nullable: false, maxLength: 128),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DealerId, t.ProductId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DealerProductInventories");
        }
    }
}
