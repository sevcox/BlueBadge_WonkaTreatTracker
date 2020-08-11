namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantityMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factory", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Store", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store", "Quantity");
            DropColumn("dbo.Factory", "Quantity");
        }
    }
}
