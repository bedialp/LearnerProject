using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class StudentCourseController : Controller
	{
		LearnerContext context = new LearnerContext();
		public ActionResult Index(int pageNumber = 1)
		{
			string studentName = Session["studentName"].ToString();
			var student = context.Students.Where(x => x.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault();
			var values = context.CourseRegisters.Where(x => x.StudentId == student).ToList();
			return View(values);
		}

		public ActionResult MyCourseList(int id, int pageNumber = 1)
		{
			var values = context.CourseVideos.Where(x => x.CourseId == id).ToList().ToPagedList(pageNumber, 1);
			return View(values);
		}

		public ActionResult DeleteMyCourse()
		{
			string studentName = Session["studentName"].ToString();
			var student = context.Students.Where(x => x.NameSurname == studentName).Select(x => x.StudentId).FirstOrDefault();
			var values = context.CourseRegisters.Where(x => x.StudentId == student).FirstOrDefault();

			context.CourseRegisters.Remove(values);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}