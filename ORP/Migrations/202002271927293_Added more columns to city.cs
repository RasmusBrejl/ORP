namespace ORP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmorecolumnstocity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "Valid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cities", "PricePenalty", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "PricePenalty");
            DropColumn("dbo.Cities", "Valid");
        }
    }
}
