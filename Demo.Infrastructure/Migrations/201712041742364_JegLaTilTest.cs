namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JegLaTilTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplaintReports", "Test", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComplaintReports", "Test");
        }
    }
}
