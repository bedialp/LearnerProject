﻿using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminCourse
        public ActionResult Index()
        {
            var values = context.Courses.ToList();
            return View(values);
        }

        // KURS SILME ISLEMI
        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // KURS EKLEME ISLEMI
        [HttpGet]
        public ActionResult AddCourse()
        {
            List<SelectListItem> category = (from x in context.Categories.Where(x=>x.Status == true).ToList()
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
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // KURS GUNCELLEME ISLEMI
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
            var value = context.Courses.Find(id);
            return View(value);
        } 

        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var value = context.Courses.Find(course.CourseId);
            value.CourseName = course.CourseName;
            value.CourseId = course.CourseId;
            value.ImageUrl  = course.ImageUrl;
            value.Price = course.Price;
            value.Description = course.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}