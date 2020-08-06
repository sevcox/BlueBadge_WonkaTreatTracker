namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToTicketId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyTicketId", newName: "CandyId");
            RenameIndex(table: "dbo.GoldenTicket", name: "IX_CandyTicketId", newName: "IX_CandyId");
            DropColumn("dbo.GoldenTicket", "CreatedUtc");
            DropColumn("dbo.GoldenTicket", "UserCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoldenTicket", "UserCreated", c => c.String(nullable: false));
            AddColumn("dbo.GoldenTicket", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            RenameIndex(table: "dbo.GoldenTicket", name: "IX_CandyId", newName: "IX_CandyTicketId");
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyId", newName: "CandyTicketId");
        }
    }
}
