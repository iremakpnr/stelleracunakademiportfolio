using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stelleracunakademiportfolio.Models;

namespace stelleracunakademiportfolio.Controllers
{
    public class ContactController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            var values = db.tbl_contact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int ID)
        {
            var value = db.tbl_contact.Find(ID);
            db.tbl_contact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(tbl_contact contact)
        {
            db.tbl_contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int ID)
        {
            var value = db.tbl_contact.Find(ID);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(tbl_contact contact)
        {
            var value = db.tbl_contact.Find(contact.contactID);
            value.phone = contact.phone;
            value.adress = contact.adress;
            value.Email = contact.Email;
            value.MapUrl = contact.MapUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}