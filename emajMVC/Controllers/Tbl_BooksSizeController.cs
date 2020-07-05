using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using emajMVC.Models;

namespace emajMVC.Controllers
{
    [Authorize]
    public class Tbl_BooksSizeController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_BooksSize
        public ActionResult Index()
        {
            return View(db.Tbl_BooksSize.ToList());
        }

        // GET: Tbl_BooksSize/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksSize tbl_BooksSize = db.Tbl_BooksSize.Find(id);
            if (tbl_BooksSize == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksSize);
        }

        // GET: Tbl_BooksSize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_BooksSize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Tbl_BooksSize tbl_BooksSize)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_BooksSize.Add(tbl_BooksSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_BooksSize);
        }

        // GET: Tbl_BooksSize/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksSize tbl_BooksSize = db.Tbl_BooksSize.Find(id);
            if (tbl_BooksSize == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksSize);
        }

        // POST: Tbl_BooksSize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Tbl_BooksSize tbl_BooksSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_BooksSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_BooksSize);
        }

        // GET: Tbl_BooksSize/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksSize tbl_BooksSize = db.Tbl_BooksSize.Find(id);
            if (tbl_BooksSize == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksSize);
        }

        // POST: Tbl_BooksSize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_BooksSize tbl_BooksSize = db.Tbl_BooksSize.Find(id);
            db.Tbl_BooksSize.Remove(tbl_BooksSize);
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
