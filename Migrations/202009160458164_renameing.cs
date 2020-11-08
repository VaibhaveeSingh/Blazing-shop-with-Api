namespace BlazingShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CId" });
            DropPrimaryKey("dbo.Categories");
            AddColumn("dbo.Products", "Category_Id", c => c.Int());
            AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Categories", "CId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropPrimaryKey("dbo.Categories");
            DropColumn("dbo.Categories", "Id");
            DropColumn("dbo.Products", "Category_Id");
            AddPrimaryKey("dbo.Categories", "CId");
            CreateIndex("dbo.Products", "CId");
            AddForeignKey("dbo.Products", "CId", "dbo.Categories", "CId", cascadeDelete: true);
        }
    }
}
