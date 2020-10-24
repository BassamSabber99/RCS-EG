namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecolproductid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Announcements", "productid", "dbo.Products");
            DropIndex("dbo.Announcements", new[] { "productid" });
            AlterColumn("dbo.Announcements", "productid", c => c.Int());
            CreateIndex("dbo.Announcements", "productid");
            AddForeignKey("dbo.Announcements", "productid", "dbo.Products", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "productid", "dbo.Products");
            DropIndex("dbo.Announcements", new[] { "productid" });
            AlterColumn("dbo.Announcements", "productid", c => c.Int(nullable: false));
            CreateIndex("dbo.Announcements", "productid");
            AddForeignKey("dbo.Announcements", "productid", "dbo.Products", "id", cascadeDelete: true);
        }
    }
}
