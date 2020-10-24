namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addseencoltoAnnouncement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "seen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "seen");
        }
    }
}
