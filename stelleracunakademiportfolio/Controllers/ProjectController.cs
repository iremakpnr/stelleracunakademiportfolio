using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stelleracunakademiportfolio.Models;


namespace stelleracunakademiportfolio.Controllers
{
    public class ProjectController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            var value = db.tbl_project.ToList();
            return View(value);
        }

        public ActionResult DeleteProject(int ID)
        {
            var project = db.tbl_project.Find(ID);
            db.tbl_project.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(tbl_project project)
        {
            db.tbl_project.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int ID)
        {
            var project = db.tbl_project.Find(ID);
            return View(project);
        }

        [HttpPost]
        public ActionResult UpdateProject(tbl_project project)
        {
            var value = db.tbl_project.Find(project.projectID);
            value.description = project.description;
            value.imageUrl = project.imageUrl;
            value.title = project.title;
            value.GitHubUrl = project.GitHubUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}