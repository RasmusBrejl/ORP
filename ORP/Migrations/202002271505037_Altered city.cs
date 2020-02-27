namespace ORP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteredcity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Connections", "City_CityId", "dbo.Cities");
            DropIndex("dbo.Connections", new[] { "City_CityId" });
            DropColumn("dbo.Connections", "City_CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Connections", "City_CityId", c => c.Int());
            CreateIndex("dbo.Connections", "City_CityId");
            AddForeignKey("dbo.Connections", "City_CityId", "dbo.Cities", "CityId");
        }
    }
}
