namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplaintReports", "SentToApproval", c => c.Boolean(nullable: false));
            DropColumn("dbo.ComplaintReports", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ComplaintReports", "Test", c => c.Int(nullable: false));
            DropColumn("dbo.ComplaintReports", "SentToApproval");
        }
    }
}
