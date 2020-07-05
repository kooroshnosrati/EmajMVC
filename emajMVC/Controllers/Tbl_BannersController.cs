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
    public class Tbl_BannersController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_Banners
        public ActionResult Index()
        {
            return View(db.Tbl_Banners.ToList());
        }

        // GET: Tbl_Banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Banners tbl_Banners = db.Tbl_Banners.Find(id);
            if (tbl_Banners == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Banners);
        }

        // GET: Tbl_Banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Banners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Path,Priority,Visiblity")] Tbl_Banners tbl_Banners)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Banners.Add(tbl_Banners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Banners);
        }

        // GET: Tbl_Banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Banners tbl_Banners = db.Tbl_Banners.Find(id);
            if (tbl_Banners == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Banners);
        }

        // POST: Tbl_Banners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Path,Priority,Visiblity")] Tbl_Banners tbl_Banners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Banners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Banners);
        }

        // GET: Tbl_Banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Banners tbl_Banners = db.Tbl_Banners.Find(id);
            if (tbl_Banners == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Banners);
        }

        // POST: Tbl_Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Banners tbl_Banners = db.Tbl_Banners.Find(id);
            db.Tbl_Banners.Remove(tbl_Banners);
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
