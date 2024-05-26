using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stelleracunakademiportfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial() {
            ViewBag.project = db.tbl_project.Count();
            ViewBag.testimonial = db.tbl_testimanional.Count();
            ViewBag.skill = db.tbl_skill.Count();
            var values = db.tbl_Feature.ToList();
            return PartialView(values);
            }

        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.tbl_abouti.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(tbl_message message)
        {
            message.IsRead = false;
            db.tbl_message.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultServicePartial()
        {
            var values = db.tbl_service.Where(x => x.servicestatus == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.tbl_skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjectPartial()
        {
            var values = db.tbl_project.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.tbl_testimanional.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultContactInfoPartial()
        {
            var values = db.tbl_contact.ToList();
            return PartialView(values);
        }

        public PartialViewResult UILayoutFooterPartial()
        {
            var values = db.tbl_socialmedia.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSocialMediaPartial()
        {
            var values = db.tbl_socialmedia.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultBlogPartial()
        {
            var values = db.tbl_Blog.ToList();
            return PartialView(values);
        }
    }
}
