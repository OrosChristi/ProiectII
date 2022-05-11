namespace DataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(),
                        UserID = c.Int(nullable: false),
                        AutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Auto", t => t.AutoID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.AutoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Order", "AutoID", "dbo.Auto");
            DropIndex("dbo.Order", new[] { "AutoID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropTable("dbo.Order");
        }
    }
}
