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
    public class Tbl_ProductsTypeController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_ProductsType
        public ActionResult Index()
        {
            return View(db.Tbl_ProductsType.ToList());
        }

        // GET: Tbl_ProductsType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ProductsType tbl_ProductsType = db.Tbl_ProductsType.Find(id);
            if (tbl_ProductsType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ProductsType);
        }

        // GET: Tbl_ProductsType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_ProductsType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Tbl_ProductsType tbl_ProductsType)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_ProductsType.Add(tbl_ProductsType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ProductsType);
        }

        // GET: Tbl_ProductsType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ProductsType tbl_ProductsType = db.Tbl_ProductsType.Find(id);
            if (tbl_ProductsType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ProductsType);
        }

        // POST: Tbl_ProductsType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Tbl_ProductsType tbl_ProductsType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ProductsType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ProductsType);
        }

        // GET: Tbl_ProductsType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ProductsType tbl_ProductsType = db.Tbl_ProductsType.Find(id);
            if (tbl_ProductsType == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ProductsType);
        }

        // POST: Tbl_ProductsType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_ProductsType tbl_ProductsType = db.Tbl_ProductsType.Find(id);
            db.Tbl_ProductsType.Remove(tbl_ProductsType);
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
