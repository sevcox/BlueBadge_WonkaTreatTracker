namespace TreatTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
                        Store_StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.CandyId)
                .ForeignKey("dbo.Factory", t => t.FactoryId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.Store_StoreId)
                .Index(t => t.FactoryId)
                .Index(t => t.Store_StoreId);
            
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
                        Store_StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.DrinkId)
                .ForeignKey("dbo.Factory", t => t.FactoryId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.Store_StoreId)
                .Index(t => t.FactoryId)
                .Index(t => t.Store_StoreId);
            
            CreateTable(
                "dbo.StoreDink",
                c => new
                    {
                        StoreDrink = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        DrinkId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreDrink)
                .ForeignKey("dbo.Drink", t => t.DrinkId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.DrinkId);
            
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
                "dbo.StoreCandy",
                c => new
                    {
                        StoreCandyId = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        CandyId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreCandyId)
                .ForeignKey("dbo.Candy", t => t.CandyId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.CandyId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoldenTicket", "CandyId", "dbo.Candy");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.StoreDink", "StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreCandy", "StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreCandy", "CandyId", "dbo.Candy");
            DropForeignKey("dbo.Drink", "Store_StoreId", "dbo.Store");
            DropForeignKey("dbo.Candy", "Store_StoreId", "dbo.Store");
            DropForeignKey("dbo.StoreDink", "DrinkId", "dbo.Drink");
            DropForeignKey("dbo.Drink", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.Character", "Factory_FactoryId", "dbo.Factory");
            DropForeignKey("dbo.Character", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Room", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.Candy", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "FactoryId", "dbo.Factory");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.GoldenTicket", new[] { "CandyId" });
            DropIndex("dbo.StoreCandy", new[] { "CandyId" });
            DropIndex("dbo.StoreCandy", new[] { "StoreId" });
            DropIndex("dbo.StoreDink", new[] { "DrinkId" });
            DropIndex("dbo.StoreDink", new[] { "StoreId" });
            DropIndex("dbo.Drink", new[] { "Store_StoreId" });
            DropIndex("dbo.Drink", new[] { "FactoryId" });
            DropIndex("dbo.Room", new[] { "FactoryId" });
            DropIndex("dbo.Character", new[] { "Factory_FactoryId" });
            DropIndex("dbo.Character", new[] { "RoomId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "FactoryId" });
            DropIndex("dbo.Candy", new[] { "Store_StoreId" });
            DropIndex("dbo.Candy", new[] { "FactoryId" });
            DropTable("dbo.GoldenTicket");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.StoreCandy");
            DropTable("dbo.Store");
            DropTable("dbo.StoreDink");
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
