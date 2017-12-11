namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YaserAddedNyPropTpPart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "MyProperty2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "MyProperty2");
        }
    }
}
