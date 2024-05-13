using LearnerProject.Models;
using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class TeacherReviewController : Controller
	{
		LearnerContext context = new LearnerContext();
		// GET: TeacherReview
		public ActionResult Index()
		{
			string teacherNameSurname = Session["teacherName"].ToString();
			var teacher = context.Teachers.Where(x => x.NameSurname == teacherNameSurname).FirstOrDefault();
			var teacherCourseIDs = context.Courses.Where(x => x.TeacherId == teacher.TeacherId).Select(x => x.CourseId).ToList();
			var teacherReviews = context.Reviews.Where(x => teacherCourseIDs.Contains(x.CourseId) == true).ToList();

			return View(teacherReviews);
		}
		public ActionResult DeleteReview(int id)
		{
			var value = context.Reviews.Find(id);
			context.Reviews.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}