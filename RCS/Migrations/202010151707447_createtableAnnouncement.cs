namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtableAnnouncement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        announceTitle = c.String(),
                        description = c.String(),
                        Date = c.DateTime(),
                        productid = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productid, cascadeDelete: true)
                .Index(t => t.productid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "productid", "dbo.Products");
            DropIndex("dbo.Announcements", new[] { "productid" });
            DropTable("dbo.Announcements");
        }
    }
}
