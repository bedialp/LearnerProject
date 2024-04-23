// using LearnerProject.Models.Class;
using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CourseRegisterController : Controller
    {
        LearnerContext context = new LearnerContext();
        //  IEClass ie = new IEClass();

        public ActionResult Index()
        {
            var values = context.CourseRegisters.ToList();
            return View(values);
        }

        // KURS KAYDI SILME ISLEMI
        public ActionResult DeleteCourseRegister(int id)
        {
            var value = context.CourseRegisters.Find(id);
            context.CourseRegisters.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // KURS KAYDI EKLEME ISLEMI
        [HttpGet]
        public ActionResult AddCourseRegister()
        {
            var courses = context.Courses.ToList();
            List<SelectListItem> courseList = (from y in courses
                                               select new SelectListItem
                                               {
                                                   Text = y.CourseName,
                                                   Value = y.CourseId.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            var students = context.Students.ToList();
            List<SelectListItem> studentList = (from x in students
                                                select new SelectListItem
                                                {
                                                    Text = x.UserName,
                                                    Value = x.StudentId.ToString()
                                                }).ToList();
            ViewBag.student = studentList;
            return View();
        }

        [HttpPost]
        public ActionResult AddCourseRegister(CourseRegister courseRegister)
        {
            context.CourseRegisters.Add(courseRegister);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // KURS KAYDI GUNCELLEME ISLEMI
        [HttpGet]
        public ActionResult UpdateCourseRegister(int id)
        {
            var courses = context.Courses.ToList();
            List<SelectListItem> courseList = (from y in courses
                                               select new SelectListItem
                                               {
                                                   Text = y.CourseName,
                                                   Value = y.CourseId.ToString()
                                               }).ToList();
            ViewBag.course = courseList;

            var students = context.Students.ToList();
            List<SelectListItem> studentList = (from x in students
                                                select new SelectListItem
                                                {
                                                    Text = x.UserName,
                                                    Value = x.StudentId.ToString()
                                                }).ToList();
            ViewBag.student = studentList;

            var value = context.CourseRegisters.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCourseRegister(CourseRegister courseRegister)
        {
            var value = context.CourseRegisters.Find(courseRegister.CourseRegisterId);
            value.StudentId = courseRegister.StudentId;
            value.CourseId = courseRegister.CourseId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}