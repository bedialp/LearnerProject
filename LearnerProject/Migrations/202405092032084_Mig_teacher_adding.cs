namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_teacher_adding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseVideos", "Teacher_TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseVideos", new[] { "Teacher_TeacherId" });
            RenameColumn(table: "dbo.CourseVideos", name: "Teacher_TeacherId", newName: "TeacherId");
            AlterColumn("dbo.CourseVideos", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseVideos", "TeacherId");
            AddForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseVideos", new[] { "TeacherId" });
            AlterColumn("dbo.CourseVideos", "TeacherId", c => c.Int());
            RenameColumn(table: "dbo.CourseVideos", name: "TeacherId", newName: "Teacher_TeacherId");
            CreateIndex("dbo.CourseVideos", "Teacher_TeacherId");
            AddForeignKey("dbo.CourseVideos", "Teacher_TeacherId", "dbo.Teachers", "TeacherId");
        }
    }
}
