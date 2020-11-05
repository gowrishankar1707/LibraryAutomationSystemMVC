namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library_v18 : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 30),
                        UserName = p.String(maxLength: 25),
                        Password = p.String(maxLength: 25),
                        DOB = p.DateTime(),
                        DOJ = p.DateTime(),
                        Gender = p.String(),
                        PhoneNumber = p.String(maxLength: 15),
                        Email = p.String(maxLength: 250),
                        Address = p.String(maxLength: 50),
                        Role = p.String(),
                        BookRequest = p.Byte(),
                        BookFine = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Users]([Name], [UserName], [Password], [DOB], [DOJ], [Gender], [PhoneNumber], [Email], [Address], [Role], [BookRequest], [BookFine])
                      VALUES (@Name, @UserName, @Password, @DOB, @DOJ, @Gender, @PhoneNumber, @Email, @Address, @Role, @BookRequest, @BookFine)
                      
                      DECLARE @ID int
                      SELECT @ID = [ID]
                      FROM [dbo].[Users]
                      WHERE @@ROWCOUNT > 0 AND [ID] = scope_identity()
                      
                      SELECT t0.[ID]
                      FROM [dbo].[Users] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ID] = @ID"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        ID = p.Int(),
                        Name = p.String(maxLength: 30),
                        UserName = p.String(maxLength: 25),
                        Password = p.String(maxLength: 25),
                        DOB = p.DateTime(),
                        DOJ = p.DateTime(),
                        Gender = p.String(),
                        PhoneNumber = p.String(maxLength: 15),
                        Email = p.String(maxLength: 250),
                        Address = p.String(maxLength: 50),
                        Role = p.String(),
                        BookRequest = p.Byte(),
                        BookFine = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Users]
                      SET [Name] = @Name, [UserName] = @UserName, [Password] = @Password, [DOB] = @DOB, [DOJ] = @DOJ, [Gender] = @Gender, [PhoneNumber] = @PhoneNumber, [Email] = @Email, [Address] = @Address, [Role] = @Role, [BookRequest] = @BookRequest, [BookFine] = @BookFine
                      WHERE ([ID] = @ID)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        ID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Users]
                      WHERE ([ID] = @ID)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
        }
    }
}
