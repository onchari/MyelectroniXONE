namespace MyElectronix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00001224 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.SubTests", "TestModelId", "dbo.TestModels");
            DropIndex("dbo.Items", new[] { "Category_CategoryID" });
            DropIndex("dbo.SubTests", new[] { "TestModelId" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        ProductsName = c.String(),
                        ProductsDescription = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "CategoryIconId");
            DropColumn("dbo.Categories", "CategoryIconData");
            DropColumn("dbo.Categories", "DateCreated");
            DropColumn("dbo.Categories", "Description");
            DropTable("dbo.Items");
            DropTable("dbo.SubTests");
            DropTable("dbo.TestModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestModels",
                c => new
                    {
                        TestModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestModelId);
            
            CreateTable(
                "dbo.SubTests",
                c => new
                    {
                        SubTestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TestModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubTestId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Categories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "CategoryIconData", c => c.Binary());
            AddColumn("dbo.Categories", "CategoryIconId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 30));
            DropTable("dbo.Products");
            CreateIndex("dbo.SubTests", "TestModelId");
            CreateIndex("dbo.Items", "Category_CategoryID");
            AddForeignKey("dbo.SubTests", "TestModelId", "dbo.TestModels", "TestModelId", cascadeDelete: true);
            AddForeignKey("dbo.Items", "Category_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
