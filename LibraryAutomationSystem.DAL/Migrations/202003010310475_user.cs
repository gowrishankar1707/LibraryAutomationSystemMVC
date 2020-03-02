namespace LibraryAutomationSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        memberName = c.String(nullable: false),
                        memberUserName = c.String(nullable: false),
                        memberPassword = c.String(nullable: false),
                        memberDOB = c.DateTime(nullable: false),
                        memberDOJ = c.DateTime(nullable: false),
                        memberSex = c.String(nullable: false),
                        memberPhoneNumber = c.Long(nullable: false),
                        e_Mail = c.String(nullable: false),
                        memberAddress = c.String(nullable: false),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }

       
    }
}
