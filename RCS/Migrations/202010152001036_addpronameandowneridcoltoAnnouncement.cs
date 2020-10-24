namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpronameandowneridcoltoAnnouncement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "productName", c => c.String());
            AddColumn("dbo.Announcements", "OwnerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "OwnerID");
            DropColumn("dbo.Announcements", "productName");
        }
    }
}
