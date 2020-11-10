namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library_v19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookType", c => c.String(maxLength: 10));
            AlterColumn("dbo.Books", "BookImagePath", c => c.String());
            DropColumn("dbo.Users", "BookFine");
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
                        BookImagePath = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Books]([BookTittle], [CategoryId], [BookLanguageId], [AuthorName], [BookCount], [BookType], [BookImagePath])
                      VALUES (@BookTittle, @CategoryId, @BookLanguageId, @AuthorName, @BookCount, @BookType, @BookImagePath)
                      
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
                        BookImagePath = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Books]
                      SET [BookTittle] = @BookTittle, [CategoryId] = @CategoryId, [BookLanguageId] = @BookLanguageId, [AuthorName] = @AuthorName, [BookCount] = @BookCount, [BookType] = @BookType, [BookImagePath] = @BookImagePath
                      WHERE ([BookId] = @BookId)"
            );
            
            DropStoredProcedure("dbo.User_Insert");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Delete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "BookFine", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "BookImagePath", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Books", "BookType", c => c.String(nullable: false, maxLength: 10));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
