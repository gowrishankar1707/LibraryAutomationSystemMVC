namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gs : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Categories", new[] { "CategoryName" });
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Categories", "CategoryName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "CategoryName" });
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 50));
            CreateIndex("dbo.Categories", "CategoryName", unique: true);
        }
    }
}
