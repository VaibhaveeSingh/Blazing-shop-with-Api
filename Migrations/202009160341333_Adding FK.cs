namespace BlazingShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "Product_Id", c => c.Int());
            AddColumn("dbo.Products", "CId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Product_Id");
            CreateIndex("dbo.Products", "CId");
            AddForeignKey("dbo.Products", "CId", "dbo.Categories", "CId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "CId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CId" });
            DropIndex("dbo.Appointments", new[] { "Product_Id" });
            DropColumn("dbo.Products", "CId");
            DropColumn("dbo.Appointments", "Product_Id");
            DropColumn("dbo.Appointments", "PId");
        }
    }
}
