﻿using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    public class AdminLoginController : Controller
    {
		LearnerContext context = new LearnerContext();
		// GET: AdminLogin
		public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(Admin admin
			)
		{
			var values = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
			if (values == null)
			{
				ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
				return View();
			}
			else
			{
				FormsAuthentication.SetAuthCookie(values.UserName, false);
				Session["adminName"] = values.NameSurname;
				return RedirectToAction("Index", "AdminDashboard");
			}
		}
	}
}