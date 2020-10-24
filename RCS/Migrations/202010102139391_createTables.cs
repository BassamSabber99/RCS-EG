namespace RCS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        catName = c.String(),
                        depId = c.Byte(nullable: false),
                        Department_id = c.Byte(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departments", t => t.Department_id)
                .Index(t => t.Department_id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        depName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.images",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        productId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: true)
                .Index(t => t.productId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        ownerId = c.String(maxLength: 128),
                        catid = c.Byte(nullable: false),
                        Category_id = c.Byte(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Category_id)
                .ForeignKey("dbo.AspNetUsers", t => t.ownerId)
                .Index(t => t.ownerId)
                .Index(t => t.Category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.images", "productId", "dbo.Products");
            DropForeignKey("dbo.Products", "ownerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Department_id", "dbo.Departments");
            DropIndex("dbo.Products", new[] { "Category_id" });
            DropIndex("dbo.Products", new[] { "ownerId" });
            DropIndex("dbo.images", new[] { "productId" });
            DropIndex("dbo.Categories", new[] { "Department_id" });
            DropTable("dbo.Products");
            DropTable("dbo.images");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}
