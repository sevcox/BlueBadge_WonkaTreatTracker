namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrandNew : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GoldenTicket", name: "TicketId", newName: "CandyTicketId");
            RenameIndex(table: "dbo.GoldenTicket", name: "IX_TicketId", newName: "IX_CandyTicketId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GoldenTicket", name: "IX_CandyTicketId", newName: "IX_TicketId");
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyTicketId", newName: "TicketId");
        }
    }
}
