namespace ORP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clearances",
                c => new
                    {
                        ClearanceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClearanceId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Clearance_ClearanceId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Clearances", t => t.Clearance_ClearanceId)
                .Index(t => t.Clearance_ClearanceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Clearance_ClearanceId", "dbo.Clearances");
            DropIndex("dbo.Users", new[] { "Clearance_ClearanceId" });
            DropTable("dbo.Users");
            DropTable("dbo.Clearances");
        }
    }
}
