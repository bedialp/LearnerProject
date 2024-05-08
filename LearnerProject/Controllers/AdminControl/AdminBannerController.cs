using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminBannerController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Banners.ToList();
            return View(values);
        }

        // BANNER SILME ISLEMI
        public ActionResult DeleteBanner(int id)
        {
            var value = context.Banners.Find(id);
            context.Banners.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // BANNER EKLEME ISLEMI
        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Banner banner)
        {
            context.Banners.Add(banner);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // BANNER GUNCELLEME ISLEMI
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = context.Banners.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var value = context.Banners.Find(banner.BannerId);
            value.Title = banner.Title;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}