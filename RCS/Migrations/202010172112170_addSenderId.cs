namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSenderId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "senderId", c => c.String());
            AddColumn("dbo.Messages", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "user_Id");
            AddForeignKey("dbo.Messages", "user_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "user_Id" });
            DropColumn("dbo.Messages", "user_Id");
            DropColumn("dbo.Messages", "senderId");
        }
    }
}
