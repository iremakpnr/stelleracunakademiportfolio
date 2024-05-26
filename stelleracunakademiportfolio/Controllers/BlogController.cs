using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stelleracunakademiportfolio.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            var values = db.tbl_Blog.ToList();
            return View(values);
        }

        public ActionResult DeleteBlog(int id)
        {
            var value = db.tbl_Blog.Find(id);
            db.tbl_Blog.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(tbl_Blog Blog)
        {

            db.tbl_Blog.Add(Blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateBlog(int id)
        {
            var value = db.tbl_Blog.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBlog(tbl_Blog Blog)
        {
            var value = db.tbl_Blog.Find(Blog.BlogID);

            value.Title = Blog.Title;
            value.Url = Blog.Url;
            value.Description = Blog.Description;
            value.Writer = Blog.Writer;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}