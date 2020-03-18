namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookTittle = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        BookLanguageId = c.Int(nullable: false),
                        AuthorName = c.String(nullable: false, maxLength: 25),
                        BookCount = c.Int(nullable: false),
                        BookType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.BookLanguages", t => t.BookLanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BookLanguageId)
                .Index(t => t.AuthorName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "BookLanguageId", "dbo.BookLanguages");
            DropIndex("dbo.Books", new[] { "AuthorName" });
            DropIndex("dbo.Books", new[] { "BookLanguageId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.Books");
        }
    }
}
