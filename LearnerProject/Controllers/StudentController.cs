using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class StudentController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Students.ToList();
            return View(values);
        }

        // OGRENCI SILME ISLEMI
        public ActionResult DeleteStudent(int id)
        {
            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // OGRENCI EKLEME ISLEMI
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // OGRENCI GUNCELLEME ISLEMI
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var value = context.Students.Find(student.StudentId);
            value.NameSurname = student.NameSurname;
            value.UserName = student.UserName;
            value.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        //// OGRENCI LOGIN ISLEMI
        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult StudentLogin()
        //{
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult StudentLogin(Student student)
        //{
        //    var value = context.Students.FirstOrDefault(x => x.UserName == student.UserName && x.Password == student.Password);
        //    if (value != null)
        //    {
        //        FormsAuthentication.SetAuthCookie(value.UserName, false);
        //        Session["student"] = value.UserName;
        //        return RedirectToAction("Index", "StudentDashboard");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
        //        return View();
        //    }
        //}
        //// OGRENCI LOGOUT SISTEMI
        //[AllowAnonymous]
        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon();
        //    return RedirectToAction("Index", "Default");
        //}
    }
}