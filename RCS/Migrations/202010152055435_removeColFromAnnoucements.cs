namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeColFromAnnoucements : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Announcements", "productName");
            DropColumn("dbo.Announcements", "OwnerID");
            DropColumn("dbo.Announcements", "DateAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Announcements", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Announcements", "OwnerID", c => c.String());
            AddColumn("dbo.Announcements", "productName", c => c.String());
        }
    }
}
