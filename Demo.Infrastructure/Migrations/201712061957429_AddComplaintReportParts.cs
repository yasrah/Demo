namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComplaintReportParts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintReportParts",
                c => new
                    {
                        ComplaintReportId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ComplaintReportId, t.PartId })
                .ForeignKey("dbo.ComplaintReports", t => t.ComplaintReportId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartId, cascadeDelete: true)
                .Index(t => t.ComplaintReportId)
                .Index(t => t.PartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComplaintReportParts", "PartId", "dbo.Parts");
            DropForeignKey("dbo.ComplaintReportParts", "ComplaintReportId", "dbo.ComplaintReports");
            DropIndex("dbo.ComplaintReportParts", new[] { "PartId" });
            DropIndex("dbo.ComplaintReportParts", new[] { "ComplaintReportId" });
            DropTable("dbo.ComplaintReportParts");
        }
    }
}
