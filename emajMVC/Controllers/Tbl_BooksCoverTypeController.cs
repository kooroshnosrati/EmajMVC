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
    public class Tbl_BooksCoverTypeController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_BooksCoverType
        public ActionResult Index()
        {
            return View(db.Tbl_BooksCoverType.ToList());
        }

        // GET: Tbl_BooksCoverType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksCoverType tbl_BooksCoverType = db.Tbl_BooksCoverType.Find(id);
            if (tbl_BooksCoverType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksCoverType);
        }

        // GET: Tbl_BooksCoverType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_BooksCoverType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Tbl_BooksCoverType tbl_BooksCoverType)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_BooksCoverType.Add(tbl_BooksCoverType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_BooksCoverType);
        }

        // GET: Tbl_BooksCoverType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksCoverType tbl_BooksCoverType = db.Tbl_BooksCoverType.Find(id);
            if (tbl_BooksCoverType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksCoverType);
        }

        // POST: Tbl_BooksCoverType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Tbl_BooksCoverType tbl_BooksCoverType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_BooksCoverType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_BooksCoverType);
        }

        // GET: Tbl_BooksCoverType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_BooksCoverType tbl_BooksCoverType = db.Tbl_BooksCoverType.Find(id);
            if (tbl_BooksCoverType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_BooksCoverType);
        }

        // POST: Tbl_BooksCoverType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_BooksCoverType tbl_BooksCoverType = db.Tbl_BooksCoverType.Find(id);
            db.Tbl_BooksCoverType.Remove(tbl_BooksCoverType);
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
