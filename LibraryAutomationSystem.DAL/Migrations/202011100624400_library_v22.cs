namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library_v22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookOrders", "RequestedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BookOrders", "BookGetDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BookOrders", "ExpectedReturnDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BookOrders", "ReturnDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookOrders", "ReturnDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookOrders", "ExpectedReturnDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookOrders", "BookGetDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BookOrders", "RequestedDate", c => c.DateTime(nullable: false));
        }
    }
}
