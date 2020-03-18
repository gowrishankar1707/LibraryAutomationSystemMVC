namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BookRequest", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "BookRequest");
        }
    }
}
