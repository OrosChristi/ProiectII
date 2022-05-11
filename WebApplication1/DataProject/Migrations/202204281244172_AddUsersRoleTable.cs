namespace DataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersRoleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsersRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersRole", "UserID", "dbo.User");
            DropForeignKey("dbo.UsersRole", "RoleID", "dbo.Role");
            DropIndex("dbo.UsersRole", new[] { "RoleID" });
            DropIndex("dbo.UsersRole", new[] { "UserID" });
            DropTable("dbo.UsersRole");
        }
    }
}
