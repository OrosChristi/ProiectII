namespace DataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Role");
        }
    }
}
