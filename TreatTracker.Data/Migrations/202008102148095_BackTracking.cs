namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackTracking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Store", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Store", "Quantity", c => c.Int(nullable: false));
        }
    }
}
