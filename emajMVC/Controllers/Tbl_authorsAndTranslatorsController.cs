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
    public class Tbl_authorsAndTranslatorsController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_authorsAndTranslators
        public ActionResult Index()
        {
            return View(db.Tbl_authorsAndTranslators.ToList());
        }

        // GET: Tbl_authorsAndTranslators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_authorsAndTranslators tbl_authorsAndTranslators = db.Tbl_authorsAndTranslators.Find(id);
            if (tbl_authorsAndTranslators == null)
            {
                return HttpNotFound();
            }
            return View(tbl_authorsAndTranslators);
        }

        // GET: Tbl_authorsAndTranslators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_authorsAndTranslators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FName,LName")] Tbl_authorsAndTranslators tbl_authorsAndTranslators)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_authorsAndTranslators.Add(tbl_authorsAndTranslators);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_authorsAndTranslators);
        }

        // GET: Tbl_authorsAndTranslators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_authorsAndTranslators tbl_authorsAndTranslators = db.Tbl_authorsAndTranslators.Find(id);
            if (tbl_authorsAndTranslators == null)
            {
                return HttpNotFound();
            }
            return View(tbl_authorsAndTranslators);
        }

        // POST: Tbl_authorsAndTranslators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FName,LName")] Tbl_authorsAndTranslators tbl_authorsAndTranslators)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_authorsAndTranslators).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_authorsAndTranslators);
        }

        // GET: Tbl_authorsAndTranslators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_authorsAndTranslators tbl_authorsAndTranslators = db.Tbl_authorsAndTranslators.Find(id);
            if (tbl_authorsAndTranslators == null)
            {
                return HttpNotFound();
            }
            return View(tbl_authorsAndTranslators);
        }

        // POST: Tbl_authorsAndTranslators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_authorsAndTranslators tbl_authorsAndTranslators = db.Tbl_authorsAndTranslators.Find(id);
            db.Tbl_authorsAndTranslators.Remove(tbl_authorsAndTranslators);
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
