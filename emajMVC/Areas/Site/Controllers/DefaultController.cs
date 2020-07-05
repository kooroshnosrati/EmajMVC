using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using emajMVC.Areas.Site.Models;
using emajMVC.Models;

namespace emajMVC.Areas.Site.Controllers
{
    public class DefaultController : Controller
    {
        private List<Tbl_Banners> GetBanners()
        {
            EmajDBEntities dbe = new EmajDBEntities();
            return dbe.Tbl_Banners.Where(x => x.Visiblity == true).OrderBy(y => y.Priority).ToList<Tbl_Banners>();
        }
        private List<cls_vm_Books> GetBooks()
        {
            int Width = 270, Height = 180;
            List<cls_vm_Books> lstBooks = new List<cls_vm_Books>();
            float Scale,w,h;
            EmajDBEntities dbe = new EmajDBEntities();
            List<Tbl_Books> bks = dbe.Tbl_Books.OrderByDescending(x => x.ReleasedDate).ToList<Tbl_Books>();//.Where(x => x.Visiblity == true).OrderBy(y => y.Priority).ToList<Tbl_Banners>();
            foreach (Tbl_Books item in bks)
            {
                cls_vm_Books vm_books = new cls_vm_Books();
                vm_books.PictureName = item.Image;
                vm_books.Name = item.Name;
                vm_books.Author = item.Tbl_authorsAndTranslators1.FName + " " + item.Tbl_authorsAndTranslators1.LName;

                string filedir = Server.MapPath("~/DataFiles");
                string imgfile = filedir + "\\" + item.Image;
                WebImage img = new WebImage(imgfile);
                vm_books.Width = img.Width;
                vm_books.Height = img.Height;
                if (vm_books.Width > vm_books.Height)
                {
                    if (vm_books.Width != Width)
                    {
                        Scale = (float)Width / (float)vm_books.Width;
                        h = (float)vm_books.Height * Scale;
                        vm_books.Height = (int)h;
                        vm_books.Width = Width;
                        //img.Resize(Width, (int)h, true);
                        if (vm_books.Height > Height)
                        {
                            Scale = (float)Height / (float)vm_books.Height;
                            w = (float)vm_books.Width * Scale;
                            vm_books.Height = Height;
                            vm_books.Width = (int)w;
                            //img.Resize((int)w, Height, true);
                        }
                        //img.Save(imgfile);
                        lstBooks.Add(vm_books);
                    }
                }
                else if (vm_books.Height > vm_books.Width)
                {
                    if (vm_books.Height != Height)
                    {
                        Scale = (float)Height / (float)vm_books.Height;
                        w = (float)vm_books.Width * Scale;
                        vm_books.Width = (int)w;
                        vm_books.Height = Height;
                        //img.Resize((int)w, Height, true);
                        if (vm_books.Width > Width)
                        {
                            Scale = (float)Width / (float)vm_books.Width;
                            h = (float)vm_books.Height * Scale;
                            vm_books.Width = Width;
                            vm_books.Height = (int)h;
                            //img.Resize(Width, (int)h, true);
                        }
                        //img.Save(imgfile);
                        lstBooks.Add(vm_books);
                    }
                }
            }
            return lstBooks;
        }

        // GET: Default
        public ActionResult Index()
        {
            List<Tbl_Banners> banners = GetBanners();
            ViewBag.banners = banners;
            List<cls_vm_Books> books = GetBooks();
            ViewBag.books = books;
            return View();
        }
    }
}