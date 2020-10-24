namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolownerid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "OwnerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Announcements", "OwnerId");
        }
    }
}
