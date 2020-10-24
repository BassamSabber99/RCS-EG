namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolinadv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Announcements", "productid", "dbo.Products");
            DropIndex("dbo.Announcements", new[] { "productid" });
            AddColumn("dbo.Announcements", "advId", c => c.Int(nullable: false));
            AddColumn("dbo.Announcements", "advertiseName", c => c.String());
            AddColumn("dbo.Announcements", "dateAdded", c => c.DateTime());
            DropColumn("dbo.Announcements", "productid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Announcements", "productid", c => c.Int());
            DropColumn("dbo.Announcements", "dateAdded");
            DropColumn("dbo.Announcements", "advertiseName");
            DropColumn("dbo.Announcements", "advId");
            CreateIndex("dbo.Announcements", "productid");
            AddForeignKey("dbo.Announcements", "productid", "dbo.Products", "id");
        }
    }
}
