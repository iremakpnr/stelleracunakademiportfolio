using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stelleracunakademiportfolio.Models;

namespace stelleracunakademiportfolio.Controllers
{
    public class TestimonialController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            var value = db.tbl_testimanional.ToList();
            return View(value);
        }

        public ActionResult DeleteTestimonial(int ID)
        {
            var testimonial = db.tbl_testimanional.Find(ID);
            db.tbl_testimanional.Remove(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(tbl_testimanional tetimonial)
        {
            db.tbl_testimanional.Add(tetimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int ID)
        {
            var testimonial = db.tbl_testimanional.Find(ID);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(tbl_testimanional testimonial)
        {
            var value = db.tbl_testimanional.Find(testimonial.TestimanionalID);
            value.Title = testimonial.Title;
            value.Description = testimonial.Description;
            value.NameSurname = testimonial.NameSurname;
            value.image = testimonial.image;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}