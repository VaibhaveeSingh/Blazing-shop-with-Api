namespace BlazingShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingimagecolumntoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary());
            DropColumn("dbo.Products", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            DropColumn("dbo.Products", "Image");
        }
    }
}
