﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emajMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Default", new { area = "Site" });

            //asas
        }
    }
}