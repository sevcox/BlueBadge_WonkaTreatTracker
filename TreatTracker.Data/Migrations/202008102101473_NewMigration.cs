namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Factory", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Factory", "Quantity", c => c.Int(nullable: false));
        }
    }
}
