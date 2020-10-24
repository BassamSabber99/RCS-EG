namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createMessageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        sent_date = c.DateTime(),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "productId", "dbo.Products");
            DropIndex("dbo.Messages", new[] { "productId" });
            DropTable("dbo.Messages");
        }
    }
}
