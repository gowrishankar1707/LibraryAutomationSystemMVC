namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class library11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExceptionLoggers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(nullable: false),
                        ExceptionStackTrack = c.String(nullable: false),
                        ControllerName = c.String(nullable: false),
                        ActionName = c.String(nullable: false),
                        ExceptionLogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExceptionLoggers");
        }
    }
}
