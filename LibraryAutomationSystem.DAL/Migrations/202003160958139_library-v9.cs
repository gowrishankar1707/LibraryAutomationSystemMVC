namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookType", c => c.String(nullable: false, maxLength: 10));
            AlterStoredProcedure(
                "dbo.Book_Insert",
                p => new
                    {
                        BookTittle = p.String(maxLength: 50),
                        CategoryId = p.Int(),
                        BookLanguageId = p.Int(),
                        AuthorName = p.String(maxLength: 25),
                        BookCount = p.Byte(),
                        BookType = p.String(maxLength: 10),
                    },
                body:
                    @"INSERT [dbo].[Books]([BookTittle], [CategoryId], [BookLanguageId], [AuthorName], [BookCount], [BookType])
                      VALUES (@BookTittle, @CategoryId, @BookLanguageId, @AuthorName, @BookCount, @BookType)
                      
                      DECLARE @BookId int
                      SELECT @BookId = [BookId]
                      FROM [dbo].[Books]
                      WHERE @@ROWCOUNT > 0 AND [BookId] = scope_identity()
                      
                      SELECT t0.[BookId]
                      FROM [dbo].[Books] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[BookId] = @BookId"
            );
            
            AlterStoredProcedure(
                "dbo.Book_Update",
                p => new
                    {
                        BookId = p.Int(),
                        BookTittle = p.String(maxLength: 50),
                        CategoryId = p.Int(),
                        BookLanguageId = p.Int(),
                        AuthorName = p.String(maxLength: 25),
                        BookCount = p.Byte(),
                        BookType = p.String(maxLength: 10),
                    },
                body:
                    @"UPDATE [dbo].[Books]
                      SET [BookTittle] = @BookTittle, [CategoryId] = @CategoryId, [BookLanguageId] = @BookLanguageId, [AuthorName] = @AuthorName, [BookCount] = @BookCount, [BookType] = @BookType
                      WHERE ([BookId] = @BookId)"
            );
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookType", c => c.String(nullable: false));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
