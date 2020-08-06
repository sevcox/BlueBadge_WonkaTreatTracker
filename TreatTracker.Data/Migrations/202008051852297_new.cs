namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoldenTicket", "CandyId", "dbo.Candy");
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyId", newName: "CandyTicketId");
            RenameIndex(table: "dbo.GoldenTicket", name: "IX_CandyId", newName: "IX_CandyTicketId");
            DropPrimaryKey("dbo.GoldenTicket");
            AddColumn("dbo.GoldenTicket", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.GoldenTicket", "UserCreated", c => c.String());
            AddPrimaryKey("dbo.GoldenTicket", "CandyTicketId");
            AddForeignKey("dbo.GoldenTicket", "CandyTicketId", "dbo.Candy", "CandyId");
            DropColumn("dbo.GoldenTicket", "TicketId");
            DropColumn("dbo.GoldenTicket", "CandyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoldenTicket", "CandyName", c => c.String());
            AddColumn("dbo.GoldenTicket", "TicketId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.GoldenTicket", "CandyTicketId", "dbo.Candy");
            DropPrimaryKey("dbo.GoldenTicket");
            DropColumn("dbo.GoldenTicket", "UserCreated");
            DropColumn("dbo.GoldenTicket", "CreatedUtc");
            AddPrimaryKey("dbo.GoldenTicket", "TicketId");
            RenameIndex(table: "dbo.GoldenTicket", name: "IX_CandyTicketId", newName: "IX_CandyId");
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyTicketId", newName: "CandyId");
            AddForeignKey("dbo.GoldenTicket", "CandyId", "dbo.Candy", "CandyId", cascadeDelete: true);
        }
    }
}
