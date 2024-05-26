
using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();


        public ActionResult Index()
        {
            var values = db.tbl_service.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.tbl_service.Find(id);
            db.tbl_service.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(tbl_service service)
        {
            service.servicestatus = false;
            db.tbl_service.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateService(int id)
        {
            var value = db.tbl_service.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(tbl_service service)
        {
            var value = db.tbl_service.Find(service.serviceID);
            value.servicename = service.servicename;
            value.servicestatus = true;
            value.serviceikon = service.serviceikon;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult MakeActive(int id)
        {
            var value = db.tbl_service.Find(id);
            value.servicestatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakePassive(int id)
        {
            var value = db.tbl_service.Find(id);
            value.servicestatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
