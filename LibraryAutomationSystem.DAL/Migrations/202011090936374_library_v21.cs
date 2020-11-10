namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library_v21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookOrders",
                c => new
                    {
                        BookOrderId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        BookTittle = c.String(nullable: false, maxLength: 50),
                        AuthorName = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(nullable: false, maxLength: 100),
                        RequestedDate = c.DateTime(nullable: false),
                        BookGetDate = c.DateTime(nullable: false),
                        ExpectedReturnDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookOrderId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookOrders", "Id", "dbo.Users");
            DropForeignKey("dbo.BookOrders", "BookId", "dbo.Books");
            DropIndex("dbo.BookOrders", new[] { "BookId" });
            DropIndex("dbo.BookOrders", new[] { "Id" });
            DropTable("dbo.BookOrders");
        }
    }
}
