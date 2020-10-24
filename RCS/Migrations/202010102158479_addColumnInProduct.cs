namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnInProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "status");
        }
    }
}
