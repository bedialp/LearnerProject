using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class TeacherCourseController : Controller
	{
		LearnerContext context = new LearnerContext();

		public ActionResult Index()
		{
			string name = Session["teacherName"].ToString();
			var values = context.Courses.Where(x => x.Teacher.NameSurname == name).ToList();
			return View(values);
		}

		public ActionResult DeleteCourse(int id)
		{
			var values = context.Courses.Find(id);
			context.Courses.Remove(values);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult AddCourse()
		{
			List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
											 select new SelectListItem
											 {
												 Text = x.CategoryName,
												 Value = x.CategoryId.ToString()
											 }).ToList();

			ViewBag.category = category;
			return View();
		}

		[HttpPost]
		public ActionResult AddCourse(Course course)
		{
			string name = Session["teacherName"].ToString();

			course.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();
			context.Courses.Add(course);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult UpdateCourse(int id)
		{
			List<SelectListItem> category = (from x in context.Categories.Where(x => x.Status == true).ToList()
											 select new SelectListItem
											 {
												 Text = x.CategoryName,
												 Value = x.CategoryId.ToString()
											 }).ToList();

			ViewBag.category = category;
			var values = context.Courses.Find(id);
			return View(values);
		}

		[HttpPost]
		public ActionResult UpdateCourse(Course course)
		{
			var values = context.Courses.Find(course.CourseId);
			string name = Session["teacherName"].ToString();

			values.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();

			values.CourseName = course.CourseName;
			values.CategoryId = course.CategoryId;
			values.Price = course.Price;
			values.Description = course.Description;
			values.ImageUrl = course.ImageUrl;
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult CourseVideo(Teacher teacher)
		{

			string name = Session["teacherName"].ToString();
			var values = context.CourseVideos.Where(x => x.Teacher.NameSurname == name).ToList();

			return View(values);
		}


		[HttpGet]
		public ActionResult AddCourseVideo()
		{
			string name = Session["teacherName"].ToString();
			var courses = context.Courses.Where(x => x.Teacher.NameSurname == name).ToList();


			List<SelectListItem> coursesList = (from x in courses
												select new SelectListItem
												{
													Text = x.CourseName,
													Value = x.CourseId.ToString()
												}).ToList();

			ViewBag.course = coursesList;
			return View();

		}

		[HttpPost]
		public ActionResult AddCourseVideo(CourseVideo courseVideo)
		{
			string name = Session["teacherName"].ToString();
			courseVideo.TeacherId = context.Teachers.Where(x => x.NameSurname == name).Select(x => x.TeacherId).FirstOrDefault();
			context.CourseVideos.Add(courseVideo);
			context.SaveChanges();
			return RedirectToAction("CourseVideo", "TeacherCourse");
		}

		public ActionResult DeleteCourseVideo(int id)
		{
			var values = context.CourseVideos.Find(id);
			context.CourseVideos.Remove(values);
			context.SaveChanges();
			return RedirectToAction("CourseVideo", "TeacherCourse");
		}

		[HttpGet]
		public ActionResult UpdateCourseVideo(int id)
		{
			string name = Session["teacherName"].ToString();
			var value = context.CourseVideos.FirstOrDefault(x => x.CourseVideoId == id && x.Teacher.NameSurname == name);

			return View(value);
		}


		[HttpPost]
		public ActionResult UpdateCourseVideo(CourseVideo courseVideo)
		{
			var existingVideo = context.CourseVideos.Find(courseVideo.CourseVideoId);

			existingVideo.VideoNumber = courseVideo.VideoNumber;
			existingVideo.VideoUrl = courseVideo.VideoUrl;

			context.SaveChanges();
			return RedirectToAction("CourseVideo", "TeacherCourse");
		}

	}
}