namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv6 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Book_Insert",
                p => new
                    {
                        BookTittle = p.String(maxLength: 50),
                        CategoryId = p.Int(),
                        BookLanguageId = p.Int(),
                        AuthorName = p.String(maxLength: 25),
                        BookCount = p.Byte(),
                        BookType = p.String(),
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
            
            CreateStoredProcedure(
                "dbo.Book_Update",
                p => new
                    {
                        BookId = p.Int(),
                        BookTittle = p.String(maxLength: 50),
                        CategoryId = p.Int(),
                        BookLanguageId = p.Int(),
                        AuthorName = p.String(maxLength: 25),
                        BookCount = p.Byte(),
                        BookType = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Books]
                      SET [BookTittle] = @BookTittle, [CategoryId] = @CategoryId, [BookLanguageId] = @BookLanguageId, [AuthorName] = @AuthorName, [BookCount] = @BookCount, [BookType] = @BookType
                      WHERE ([BookId] = @BookId)"
            );
            
            CreateStoredProcedure(
                "dbo.Book_Delete",
                p => new
                    {
                        BookId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Books]
                      WHERE ([BookId] = @BookId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Book_Delete");
            DropStoredProcedure("dbo.Book_Update");
            DropStoredProcedure("dbo.Book_Insert");
        }
    }
}
