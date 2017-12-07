namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintReports",
                c => new
                    {
                        ComplaintReportId = c.Int(nullable: false, identity: true),
                        MachineNo1 = c.String(),
                        MachineNo2 = c.String(),
                        MemberId = c.Int(nullable: false),
                        CreatedByDealerDate = c.DateTime(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        DamageDate = c.DateTime(nullable: false),
                        RepairDate = c.DateTime(nullable: false),
                        TimeAmount = c.Int(nullable: false),
                        EngineNo = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ProductModelId = c.Int(nullable: false),
                        Status = c.Int(),
                        Closed = c.Boolean(nullable: false),
                        Error = c.String(),
                        ReasonForError = c.String(),
                        LastEditedByDealerId = c.Int(nullable: false),
                        PartsMarked = c.Boolean(nullable: false),
                        PartsReturned = c.Boolean(nullable: false),
                        CreateEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ComplaintReportId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ProductModels", t => t.ProductModelId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductModelId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        CustomerType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductModelId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductModels", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ComplaintReports", "ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.ComplaintReports", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ProductModels", new[] { "ProductId" });
            DropIndex("dbo.ComplaintReports", new[] { "ProductModelId" });
            DropIndex("dbo.ComplaintReports", new[] { "CustomerId" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductModels");
            DropTable("dbo.Customers");
            DropTable("dbo.ComplaintReports");
        }
    }
}
