using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using stelleracunakademiportfolio.Models;

namespace stelleracunakademiportfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Tbl_Admin admin)
        {
            var values = db.Tbl_Admin.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(values == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            } 
            else 
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName;
                return RedirectToAction("Index", "About");
            }
        }
    }
}