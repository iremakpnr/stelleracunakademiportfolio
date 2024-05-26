using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            var values = db.tbl_socialmedia.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.tbl_socialmedia.Find(id);
            db.tbl_socialmedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(tbl_socialmedia SocialMedia)
        {

            db.tbl_socialmedia.Add(SocialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.tbl_socialmedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(tbl_socialmedia SocialMedia)
        {
            var value = db.tbl_socialmedia.Find(SocialMedia.SocialMediaID);
            value.SocialMediaLink = SocialMedia.SocialMediaLink;
            value.icon = SocialMedia.icon;
            value.Url = SocialMedia.Url;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}