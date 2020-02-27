namespace ORP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedParcelCategoryfromsolution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParcelCategories", "Parcel_ParcelId", "dbo.Parcels");
            DropIndex("dbo.ParcelCategories", new[] { "Parcel_ParcelId" });
            AddColumn("dbo.Parcels", "length", c => c.Single(nullable: false));
            DropColumn("dbo.Parcels", "Depth");
            DropTable("dbo.ParcelCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParcelCategories",
                c => new
                    {
                        ParcelCategoryId = c.Int(nullable: false, identity: true),
                        ParcelType = c.Int(nullable: false),
                        PriceModifier = c.Single(nullable: false),
                        Parcel_ParcelId = c.Int(),
                    })
                .PrimaryKey(t => t.ParcelCategoryId);
            
            AddColumn("dbo.Parcels", "Depth", c => c.Single(nullable: false));
            DropColumn("dbo.Parcels", "length");
            CreateIndex("dbo.ParcelCategories", "Parcel_ParcelId");
            AddForeignKey("dbo.ParcelCategories", "Parcel_ParcelId", "dbo.Parcels", "ParcelId");
        }
    }
}
