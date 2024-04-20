namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_coursevideo_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        VideoNumber = c.Int(nullable: false),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseVideoId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        NameSurname = c.Int(nullable: false),
                        UserName = c.Int(nullable: false),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            AddColumn("dbo.Courses", "TeacherId", c => c.Int());
            AddColumn("dbo.Reviews", "Comment", c => c.String());
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseVideos", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseVideos", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropColumn("dbo.Reviews", "Comment");
            DropColumn("dbo.Courses", "TeacherId");
            DropTable("dbo.Teachers");
            DropTable("dbo.CourseVideos");
        }
    }
}
