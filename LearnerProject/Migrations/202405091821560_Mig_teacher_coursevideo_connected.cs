namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_teacher_coursevideo_connected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseVideos", "Teacher_TeacherId", c => c.Int());
            CreateIndex("dbo.CourseVideos", "Teacher_TeacherId");
            AddForeignKey("dbo.CourseVideos", "Teacher_TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "Teacher_TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseVideos", new[] { "Teacher_TeacherId" });
            DropColumn("dbo.CourseVideos", "Teacher_TeacherId");
        }
    }
}
