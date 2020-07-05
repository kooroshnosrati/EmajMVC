using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emajMVC.Areas.ControlPanel.Controllers
{
    public class TestController : Controller
    {
        // GET: ControlPanel/Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(List<HttpPostedFileBase> files)
        {
            var path = "";
            foreach (var item in files)
            {
                if (item != null && item.ContentLength > 0 )
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/DataFiles"), item.FileName);
                    item.SaveAs(path);
                    ViewBag.UploadStatus = "Success";
                }
            }
            return View();
        }

    }
}