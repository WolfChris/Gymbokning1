namespace GymBooker1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GymClassControllerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserGymClasses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        GymClass_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.GymClass_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.GymClasses", t => t.GymClass_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.GymClass_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserGymClasses", "GymClass_Id", "dbo.GymClasses");
            DropForeignKey("dbo.ApplicationUserGymClasses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserGymClasses", new[] { "GymClass_Id" });
            DropIndex("dbo.ApplicationUserGymClasses", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserGymClasses");
        }
    }
}
