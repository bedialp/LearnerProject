using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class AdminCategoryController : Controller
	{
		LearnerContext context = new LearnerContext();
		// GET: Category
		public ActionResult Index()
		{
			var values = context.Categories.ToList();
			return View(values);
		}

		public ActionResult DeleteCategory(int id)
		{
			var value = context.Categories.Find(id);
			context.Categories.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		// KATEGORI EKLEME ISLEMI
		[HttpGet]
		public ActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCategory(Category category)
		{
			category.Status = true;
			context.Categories.Add(category);
			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		// KATEGORI GUNCELLEME ISLEMI
		public ActionResult UpdateCategory(int id)
		{
			var value = context.Categories.Find(id);
			return View(value);
		}

		[HttpPost]
		public ActionResult UpdateCategory(Category category)
		{
			var value = context.Categories.Find(category.CategoryId);
			value.CategoryName = category.CategoryName;
			value.Icon = category.Icon;
			value.Status = true;
			context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		// AKTİF - PASİF BUTONU İŞLEMLERİ
		public ActionResult MakeActive(int id)
		{
			var value = context.Categories.Find(id);
			value.Status = true;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult MakePassive(int id)
		{
			var value = context.Categories.Find(id);
			value.Status = false;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}