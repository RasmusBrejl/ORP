namespace ORP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedremainingentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfHits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionId = c.Int(nullable: false, identity: true),
                        ConnectionType = c.Int(nullable: false),
                        CityOne_CityId = c.Int(),
                        CityTwo_CityId = c.Int(),
                        City_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.ConnectionId)
                .ForeignKey("dbo.Cities", t => t.CityOne_CityId)
                .ForeignKey("dbo.Cities", t => t.CityTwo_CityId)
                .ForeignKey("dbo.Cities", t => t.City_CityId)
                .Index(t => t.CityOne_CityId)
                .Index(t => t.CityTwo_CityId)
                .Index(t => t.City_CityId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Duration = c.Single(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        CityFrom_CityId = c.Int(),
                        CityTo_CityId = c.Int(),
                        Parcel_ParcelId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Cities", t => t.CityFrom_CityId)
                .ForeignKey("dbo.Cities", t => t.CityTo_CityId)
                .ForeignKey("dbo.Parcels", t => t.Parcel_ParcelId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.CityFrom_CityId)
                .Index(t => t.CityTo_CityId)
                .Index(t => t.Parcel_ParcelId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        ParcelId = c.Int(nullable: false, identity: true),
                        Weight = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        Depth = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ParcelId);
            
            CreateTable(
                "dbo.ParcelTypes",
                c => new
                    {
                        ParcelCategoryId = c.Int(nullable: false, identity: true),
                        ParcelType = c.Int(nullable: false),
                        PriceModifier = c.Single(nullable: false),
                        Parcel_ParcelId = c.Int(),
                    })
                .PrimaryKey(t => t.ParcelCategoryId)
                .ForeignKey("dbo.Parcels", t => t.Parcel_ParcelId)
                .Index(t => t.Parcel_ParcelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "Parcel_ParcelId", "dbo.Parcels");
            DropForeignKey("dbo.ParcelTypes", "Parcel_ParcelId", "dbo.Parcels");
            DropForeignKey("dbo.Orders", "CityTo_CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "CityFrom_CityId", "dbo.Cities");
            DropForeignKey("dbo.Connections", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.Connections", "CityTwo_CityId", "dbo.Cities");
            DropForeignKey("dbo.Connections", "CityOne_CityId", "dbo.Cities");
            DropIndex("dbo.ParcelTypes", new[] { "Parcel_ParcelId" });
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            DropIndex("dbo.Orders", new[] { "Parcel_ParcelId" });
            DropIndex("dbo.Orders", new[] { "CityTo_CityId" });
            DropIndex("dbo.Orders", new[] { "CityFrom_CityId" });
            DropIndex("dbo.Connections", new[] { "City_CityId" });
            DropIndex("dbo.Connections", new[] { "CityTwo_CityId" });
            DropIndex("dbo.Connections", new[] { "CityOne_CityId" });
            DropTable("dbo.ParcelTypes");
            DropTable("dbo.Parcels");
            DropTable("dbo.Orders");
            DropTable("dbo.Connections");
            DropTable("dbo.Cities");
        }
    }
}
