namespace BlazingShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Image", c => c.Binary());
            AddColumn("dbo.Products", "CId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "Id");
            CreateIndex("dbo.Products", "CId");
            AddForeignKey("dbo.Products", "CId", "dbo.Categories", "CId", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "Id", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Id", "dbo.Products");
            DropForeignKey("dbo.Products", "CId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CId" });
            DropIndex("dbo.Appointments", new[] { "Id" });
            DropColumn("dbo.Products", "CId");
            DropColumn("dbo.Products", "Image");
            DropColumn("dbo.Appointments", "Id");
        }
    }
}
