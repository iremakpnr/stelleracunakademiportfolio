using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();

        public ActionResult Index()
        {
            var values = db.tbl_Feature.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(tbl_Feature feature)
        {
            db.tbl_Feature.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.tbl_Feature.Find(id);
            db.tbl_Feature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.tbl_Feature.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(tbl_Feature feature)
        {
            var value = db.tbl_Feature.Find(feature.FeatureID);
            value.NameSurname = feature.NameSurname;
            value.Title = feature.Title;
            value.Job = feature.Job;
            value.ImageUrl = feature.ImageUrl;
            value.CvDownloadUrl = feature.CvDownloadUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
