namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library_v23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookOrders", "BookReceivedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.BookOrders", "BookGetDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookOrders", "BookGetDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.BookOrders", "BookReceivedDate");
        }
    }
}
