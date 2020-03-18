namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookCount", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookCount", c => c.Int(nullable: false));
        }
    }
}
