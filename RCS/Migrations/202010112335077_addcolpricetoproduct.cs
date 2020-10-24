namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolpricetoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "price");
        }
    }
}
