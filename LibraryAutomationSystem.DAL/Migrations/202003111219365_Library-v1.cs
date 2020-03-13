namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Libraryv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookLanguages",
                c => new
                    {
                        Language_Id = c.Int(nullable: false, identity: true),
                        Language_Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Language_Id)
                .Index(t => t.Language_Name, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        UserName = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 25),
                        DOB = c.DateTime(nullable: false),
                        DOJ = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        PhoneNumber = c.Long(nullable: false),
                        Email = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false, maxLength: 50),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.PhoneNumber, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateStoredProcedure(
                "dbo.BookLanguage_Insert",
                p => new
                    {
                        Language_Name = p.String(maxLength: 15),
                    },
                body:
                    @"INSERT [dbo].[BookLanguages]([Language_Name])
                      VALUES (@Language_Name)
                      
                      DECLARE @Language_Id int
                      SELECT @Language_Id = [Language_Id]
                      FROM [dbo].[BookLanguages]
                      WHERE @@ROWCOUNT > 0 AND [Language_Id] = scope_identity()
                      
                      SELECT t0.[Language_Id]
                      FROM [dbo].[BookLanguages] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Language_Id] = @Language_Id"
            );
            
            CreateStoredProcedure(
                "dbo.BookLanguage_Update",
                p => new
                    {
                        Language_Id = p.Int(),
                        Language_Name = p.String(maxLength: 15),
                    },
                body:
                    @"UPDATE [dbo].[BookLanguages]
                      SET [Language_Name] = @Language_Name
                      WHERE ([Language_Id] = @Language_Id)"
            );
            
            CreateStoredProcedure(
                "dbo.BookLanguage_Delete",
                p => new
                    {
                        Language_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[BookLanguages]
                      WHERE ([Language_Id] = @Language_Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.BookLanguage_Delete");
            DropStoredProcedure("dbo.BookLanguage_Update");
            DropStoredProcedure("dbo.BookLanguage_Insert");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.BookLanguages", new[] { "Language_Name" });
            DropTable("dbo.Users");
            DropTable("dbo.BookLanguages");
        }
    }
}
