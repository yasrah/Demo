namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToComplaintReportModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ComplaintReports", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ComplaintReports", "Status", c => c.Int());
        }
    }
}
