namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddateaddedcoltoAnnouncement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "DateAdded");
        }
    }
}
