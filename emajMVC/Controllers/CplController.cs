using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emajMVC.Controllers
{
    public class CplController : Controller
    {
        // GET: Cpl
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}