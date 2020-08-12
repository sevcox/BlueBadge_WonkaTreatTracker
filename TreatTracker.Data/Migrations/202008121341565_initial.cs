namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candy",
                c => new
                    {
                        CandyId = c.Int(nullable: false, identity: true),
                        CandyType = c.Int(nullable: false),
                        FactoryId = c.Int(nullable: false),
                        TreatName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        SecretIngredient = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        UserCreated = c.String(nullable: false),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.CandyId)
                .ForeignKey("dbo.Factory", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.Factory",
                c => new
                    {
                        FactoryId = c.Int(nullable: false, identity: true),
                        Manager = c.String(nullable: false),
                        LocationName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FactoryId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FactoryId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factory", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Weakness = c.String(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Factory_FactoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Factory", t => t.Factory_FactoryId)
                .Index(t => t.RoomId)
                .Index(t => t.Factory_FactoryId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Theme = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        FactoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Factory", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.Drink",
                c => new
                    {
                        DrinkId = c.Int(nullable: false, identity: true),
                        Flavor = c.String(nullable: false),
                        FactoryId = c.Int(nullable: false),
                        TreatName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        SecretIngredient = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        UserCreated = c.String(nullable: false),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.DrinkId)
                .ForeignKey("dbo.Factory", t => t.FactoryId, cascadeDelete: true)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoldenTicket",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        CandyId = c.Int(nullable: false),
                        PrizeType = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        UserCreated = c.String(nullable: false),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Candy", t => t.CandyId, cascadeDelete: true)
                .Index(t => t.CandyId, unique: true);
            
            CreateTable(
                "dbo.StoreCandy",
                c => new
                    {
                        Store_StoreId = c.Int(nullable: false),
                        Candy_CandyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Store_StoreId, t.Candy_CandyId })
                .ForeignKey("dbo.Store", t => t.Store_StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Candy", t => t.Candy_CandyId, cascadeDelete: true)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Candy_CandyId);
            
            CreateTable(
                "dbo.StoreDrink",
                c => new
                    {
                        Store_StoreId = c.Int(nullable: false),
                        Drink_DrinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Store_StoreId, t.Drink_DrinkId })
                .ForeignKey("dbo.Store", t => t.Store_StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Drink", t => t.Drink_DrinkId, cascadeDelete: true)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Drink_DrinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoldenTicket", "CandyId", "dbo.Candy");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.StoreDrink", "Drink_DrinkId", "dbo.Drink");
            DropForeignKey("dbo.StoreDrink", "Store_StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreCandy", "Candy_CandyId", "dbo.Candy");
            DropForeignKey("dbo.StoreCandy", "Store_StoreId", "dbo.Store");
            DropForeignKey("dbo.Drink", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.Character", "Factory_FactoryId", "dbo.Factory");
            DropForeignKey("dbo.Character", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Room", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.Candy", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.StoreDrink", new[] { "Drink_DrinkId" });
            DropIndex("dbo.StoreDrink", new[] { "Store_StoreId" });
            DropIndex("dbo.StoreCandy", new[] { "Candy_CandyId" });
            DropIndex("dbo.StoreCandy", new[] { "Store_StoreId" });
            DropIndex("dbo.GoldenTicket", new[] { "CandyId" });
            DropIndex("dbo.Drink", new[] { "FactoryId" });
            DropIndex("dbo.Room", new[] { "FactoryId" });
            DropIndex("dbo.Character", new[] { "Factory_FactoryId" });
            DropIndex("dbo.Character", new[] { "RoomId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "FactoryId" });
            DropIndex("dbo.Candy", new[] { "FactoryId" });
            DropTable("dbo.StoreDrink");
            DropTable("dbo.StoreCandy");
            DropTable("dbo.GoldenTicket");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Store");
            DropTable("dbo.Drink");
            DropTable("dbo.Room");
            DropTable("dbo.Character");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Factory");
            DropTable("dbo.Candy");
        }
    }
}
