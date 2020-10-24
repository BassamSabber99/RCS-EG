namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delmessage : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Messages", new[] { "user_Id" });
            DropColumn("dbo.Messages", "senderId");
            RenameColumn(table: "dbo.Messages", name: "user_Id", newName: "senderId");
            AlterColumn("dbo.Messages", "senderId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "senderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Messages", new[] { "senderId" });
            AlterColumn("dbo.Messages", "senderId", c => c.String());
            RenameColumn(table: "dbo.Messages", name: "senderId", newName: "user_Id");
            AddColumn("dbo.Messages", "senderId", c => c.String());
            CreateIndex("dbo.Messages", "user_Id");
        }
    }
}
