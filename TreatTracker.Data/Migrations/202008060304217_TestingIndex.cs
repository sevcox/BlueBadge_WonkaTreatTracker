namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingIndex : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoldenTicket", "CandyTicketId", "dbo.Candy");
            DropIndex("dbo.GoldenTicket", new[] { "CandyTicketId" });
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyTicketId", newName: "CandyId");
            DropPrimaryKey("dbo.GoldenTicket");
            AddColumn("dbo.GoldenTicket", "GoldenTicketId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GoldenTicket", "GoldenTicketId");
            CreateIndex("dbo.GoldenTicket", "CandyId", unique: true);
            AddForeignKey("dbo.GoldenTicket", "CandyId", "dbo.Candy", "CandyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoldenTicket", "CandyId", "dbo.Candy");
            DropIndex("dbo.GoldenTicket", new[] { "CandyId" });
            DropPrimaryKey("dbo.GoldenTicket");
            DropColumn("dbo.GoldenTicket", "GoldenTicketId");
            AddPrimaryKey("dbo.GoldenTicket", "CandyTicketId");
            RenameColumn(table: "dbo.GoldenTicket", name: "CandyId", newName: "CandyTicketId");
            CreateIndex("dbo.GoldenTicket", "CandyTicketId");
            AddForeignKey("dbo.GoldenTicket", "CandyTicketId", "dbo.Candy", "CandyId");
        }
    }
}
