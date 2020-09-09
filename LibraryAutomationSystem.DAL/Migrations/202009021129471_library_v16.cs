namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library_v16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookType", c => c.String(maxLength: 10));
            AlterColumn("dbo.Books", "BookImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookImagePath", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "BookType", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
