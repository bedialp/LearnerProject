using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnerProject.Models.Entities;

namespace LearnerProject.Controllers
{
    public class AdminContactController : Controller
    {
        LearnerContext context = new LearnerContext();


        // GET: AdminContact
        public ActionResult Index()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        // ILETISIM BILGISI SILME ISLEMI
        public ActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // ILETISIM BILGISI EKLEME ISLEMI
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // ILETISIM BILGISI GUNCELLEME ISLEMI
        public ActionResult UpdateContact(int id)
        {
            var value = context.Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var value = context.Contacts.Find(contact.ContactId);
            value.Address = contact.Address;
            value.OpenHours = contact.OpenHours;
            value.Email = contact.Email;
            value.Phone = contact.Phone;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}