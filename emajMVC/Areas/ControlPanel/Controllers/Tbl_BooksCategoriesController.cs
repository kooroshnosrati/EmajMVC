using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using emajMVC.Models;

namespace emajMVC.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class Tbl_BooksCategoriesController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_BooksCategories
        public ActionResult Index()
        {
            var tbl_BooksCategories = db.Tbl_BooksCategories.Where(m => m.ID != -1).Include(t => t.Tbl_BooksCategories2); 
            return View(tbl_BooksCategories.ToList());
        }

        // GET: Tbl_BooksCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == -1)
                return RedirectToAction("Index");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksCategories tbl_BooksCategories = db.Tbl_BooksCategories.Find(id);
            if (tbl_BooksCategories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksCategories);
        }

        // GET: Tbl_BooksCategories/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.Tbl_BooksCategories, "ID", "Name");
            return View();
        }

        // POST: Tbl_BooksCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,IsChild,ParentID")] Tbl_BooksCategories tbl_BooksCategories)
        {
            if (ModelState.IsValid)
            {
                if (!tbl_BooksCategories.IsChild)
                {
                    tbl_BooksCategories.ParentID = -1;
                    tbl_BooksCategories.IsChild = true;
                }
                    
                db.Tbl_BooksCategories.Add(tbl_BooksCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.Tbl_BooksCategories, "ID", "Name", tbl_BooksCategories.ParentID);
            return View(tbl_BooksCategories);
        }

        // GET: Tbl_BooksCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == -1)
                return RedirectToAction("Index");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksCategories tbl_BooksCategories = db.Tbl_BooksCategories.Find(id);
            if (tbl_BooksCategories == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.Tbl_BooksCategories, "ID", "Name", tbl_BooksCategories.ParentID);
            return View(tbl_BooksCategories);
        }

        // POST: Tbl_BooksCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IsChild,ParentID")] Tbl_BooksCategories tbl_BooksCategories)
        {
            if (tbl_BooksCategories.ID == -1)
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                db.Entry(tbl_BooksCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.Tbl_BooksCategories, "ID", "Name", tbl_BooksCategories.ParentID);
            return View(tbl_BooksCategories);
        }

        // GET: Tbl_BooksCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == -1)
                return RedirectToAction("Index");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksCategories tbl_BooksCategories = db.Tbl_BooksCategories.Find(id);


            if (tbl_BooksCategories == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksCategories);
        }

        // POST: Tbl_BooksCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == -1)
                return RedirectToAction("Index");

            Tbl_BooksCategories tbl_BooksCategories = db.Tbl_BooksCategories.Find(id);
            db.Tbl_BooksCategories.Remove(tbl_BooksCategories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
