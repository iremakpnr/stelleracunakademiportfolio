using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stelleracunakademiportfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
           var aboutList = db.tbl_abouti.ToList(); 
            return View(aboutList);
        }

        public ActionResult Deleteabouti(int ID)
        {
            var about = db.tbl_abouti.Find(ID);
            db.tbl_abouti.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(tbl_abouti abouti)
        {
            db.tbl_abouti.Add(abouti);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int ID)
        {
            var about = db.tbl_abouti.Find(ID);
            return View(about);
        }
        [HttpPost]
        public ActionResult  UpdateAbout(tbl_abouti about)
        {

            var value = db.tbl_abouti.FirstOrDefault(x =>x.AboutID == about.AboutID);

            value.AboutID = about.AboutID;
            value.Description = about.Description;
            value.image = about.image;
            value.NameSurname = about.NameSurname;
            value.title = about.title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}