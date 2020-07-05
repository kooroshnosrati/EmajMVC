using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emajMVC.Areas.Site.Controllers
{
    public class TestController : Controller
    {
        // GET: Site/Test
        public ActionResult Index()
        {
            return View();
        }
    }
}