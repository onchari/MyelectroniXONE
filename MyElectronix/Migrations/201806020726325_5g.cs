namespace MyElectronix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5g : DbMigration
    {
        public override void Up()
        {

            DropForeignKey("dbo.Carts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_ProductId" });
            DropPrimaryKey("dbo.Carts");
            DropColumn("dbo.Carts", "ID");
            RenameColumn(table: "dbo.Carts", name: "Product_ProductId", newName: "ProductId");
           
            AddColumn("dbo.Carts", "RecordId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Carts", "RecordId");
            AlterColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
           
            CreateIndex("dbo.Carts", "ProductId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
           
            DropColumn("dbo.Carts", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "ItemId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropPrimaryKey("dbo.Carts");
            AlterColumn("dbo.Carts", "ProductId", c => c.Int());
            DropColumn("dbo.Carts", "RecordId");
            AddPrimaryKey("dbo.Carts", "ID");
            RenameColumn(table: "dbo.Carts", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Carts", "Product_ProductId");
            AddForeignKey("dbo.Carts", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
