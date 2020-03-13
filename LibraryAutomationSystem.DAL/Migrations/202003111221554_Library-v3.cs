namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Libraryv3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Categories", "CategoryName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Categories", new[] { "CategoryName" });
        }
    }
}
