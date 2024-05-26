using stelleracunakademiportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stelleracunakademiportfolio.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        stelleracunmedyaDBEntities db = new stelleracunmedyaDBEntities();
        public ActionResult Index()
        {
            return View();
        }



    }
}