namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class libraryv13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Users", "PhoneNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "PhoneNumber" });
            DropColumn("dbo.Users", "PhoneNumber");
        }
    }
}
