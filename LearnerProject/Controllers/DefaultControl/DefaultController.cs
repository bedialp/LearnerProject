using LearnerProject.Models;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBannerPartial()
        {
            ViewBag.LatestCourse = context.Courses.OrderByDescending(x => x.CourseId).Select(x => x.CourseId).FirstOrDefault();
            var values = context.Banners.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultCategoryPartial()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTeacherPartial()
        {
            var values = context.Teachers/*.Where(x => x.Status == true).OrderByDescending(x => x.TeacherId).Take(6)*/.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultClassroomPartial()
        {
            var values = context.Classrooms.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultCoursePartial()
        {

            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Take(3).ToList();

            return PartialView(values);
        }

        public ActionResult CourseDetail(int id)
        {
            var values = context.Courses.Find(id); // Veritabanından belirtilen ID'ye sahip kurs bilgileri alınır
            var reviewList = context.Reviews.Where(x => x.CourseId == id).ToList(); // Belirtilen kursa ait incelemeler alınır
            ViewBag.review = reviewList; // Incelemeleri ViewBag aracılığıyla View'a gönderilir
            return View(values);
        }

        public PartialViewResult DefaultAboutPartial()
        {
			ViewBag.studentCount = context.Students.Count();
			ViewBag.teacherCount = context.Teachers.Count();
			var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultFAQPartial()
        {
            var values = context.FAQs.ToList();
            return PartialView(values);
        }
    }
}