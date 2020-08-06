namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicketClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoldenTicket", "PrizeType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GoldenTicket", "PrizeType");
        }
    }
}
