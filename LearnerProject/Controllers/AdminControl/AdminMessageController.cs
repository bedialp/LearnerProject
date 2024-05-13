using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
	public class AdminMessageController : Controller
	{
		// GET: AdminSendMessage
		LearnerContext context = new LearnerContext();
		public ActionResult Index()
		{
			var values = context.Messages.ToList();
			return View(values);
		}

		// OKUNDU - OKUNMADI BILGISI
		public ActionResult IsRead(int id) //makepassive
		{
			var item = context.Messages.Find(id);

			item.IsRead = true;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult IsNotRead(int id) //makeactive
		{
			var item = context.Messages.Find(id);

			item.IsRead = false;
			context.SaveChanges();
			return RedirectToAction("Index");

		}

		public ActionResult DeleteMessage(int id)
		{
			var value = context.Messages.Find(id);
			context.Messages.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult MessageDetail(int id)
		{
			var value = context.Messages.Find(id);
			return View(value);
		}
	}
}