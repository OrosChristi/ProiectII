namespace DataProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAutoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Km = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Auto");
        }
    }
}
