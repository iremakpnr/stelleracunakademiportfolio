using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SkillController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();

        public ActionResult Index()
        {
            var values = db.tbl_skill.ToList();
            return View(values);
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.tbl_skill.Find(id);
            db.tbl_skill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(tbl_skill skill)
        {

            db.tbl_skill.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSkill(int id)
        {
            var value = db.tbl_skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(tbl_skill skill)
        {
            var value = db.tbl_skill.Find(skill.skillID);

            value.skillname = skill.skillname;
            value.title = skill.title;
            value.value = skill.value;
            value.description = skill.description;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}