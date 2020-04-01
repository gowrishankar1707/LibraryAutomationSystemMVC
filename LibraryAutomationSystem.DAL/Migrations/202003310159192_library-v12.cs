namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv12 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropColumn("dbo.Users", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.Long(nullable: false));
            CreateIndex("dbo.Users", "PhoneNumber", unique: true);
        }
    }
}
