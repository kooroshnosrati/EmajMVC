using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emajMVC.Models;

namespace emajMVC.Areas.Site.Controllers
{
    public class _MenuBooksCategoriesController : Controller
    {
        EmajDBEntities db = new EmajDBEntities();        

        private string GenerateBooksCategoriesMenu(Tbl_BooksCategories rootNode)
        {
            string LiStr = "<li>";
            LiStr += "<a href=\"#\" >" + rootNode.Name + "</a>";
            if (rootNode.Tbl_BooksCategories1.Where(m => m.ParentID == rootNode.ID && m.IsChild == true).Count() > 0)
            {
                LiStr += "<ul>";
                foreach (Tbl_BooksCategories item in rootNode.Tbl_BooksCategories1.Where(m => m.ParentID == rootNode.ID && m.IsChild == true))
                {
                    LiStr += GenerateBooksCategoriesMenu(item);
                }
                LiStr += "</ul>";
            }
            LiStr += "</li>";
            return LiStr;
        }
        // GET: _MenuBooksCategories
        public string Index()
        {
            Tbl_BooksCategories rootNode = db.Tbl_BooksCategories.Single(m => m.ID == -1 && m.IsChild == false && m.ParentID == -1);
            string BooksCategoriesStr = GenerateBooksCategoriesMenu(rootNode);
            //ViewBag.BooksCategoriesBlock = BooksCategoriesStr;
            return BooksCategoriesStr;// "<li><a href=\"features.htm\">کتاب ها</a></li>";
        }
    }
}