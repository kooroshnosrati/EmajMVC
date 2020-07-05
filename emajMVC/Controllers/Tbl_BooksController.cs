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
    public class Tbl_BooksController : Controller
    {
        private EmajDBEntities db = new EmajDBEntities();

        // GET: Tbl_Books
        public ActionResult Index()
        {
            var tbl_Books = db.Tbl_Books.Include(t => t.Tbl_authorsAndTranslators).Include(t => t.Tbl_authorsAndTranslators1).Include(t => t.Tbl_BooksCategories).Include(t => t.Tbl_BooksCoverType).Include(t => t.Tbl_BooksSize);
            return View(tbl_Books.ToList());
        }

        // GET: Tbl_Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Books tbl_Books = db.Tbl_Books.Find(id);
            if (tbl_Books == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Books);
        }

        // GET: Tbl_Books/Create
        public ActionResult Create()
        {
            var AuthorsAndTranslators = db.Tbl_authorsAndTranslators.Select(n => new { ID = n.ID, FullName = n.FName + " " + n.LName });
            var LstAuthorsAndTranslators = AuthorsAndTranslators.ToList();
            LstAuthorsAndTranslators.Insert(0, new { ID = 0, FullName = "" });
            ViewBag.TranslatorID = ViewBag.AuthorID = new SelectList(LstAuthorsAndTranslators, "ID", "FullName");
            //ViewBag.TranslatorID = new SelectList(LstAuthorsAndTranslators, "ID", "FullName"); //new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName");

            ViewBag.SubjectID = new SelectList(db.Tbl_BooksCategories, "ID", "Name");

            var LstCoverType = db.Tbl_BooksCoverType.ToList();
            LstCoverType.Insert(0, new Tbl_BooksCoverType { ID = 0, Name = "" });
            ViewBag.CoverType = new SelectList(LstCoverType, "ID", "Name");


            var LstBooksSize = db.Tbl_BooksSize.ToList();
            LstBooksSize.Insert(0, new Tbl_BooksSize { ID = 0, Name = "" });
            ViewBag.Size = new SelectList(LstBooksSize, "ID", "Name");
            return View();
        }

        // POST: Tbl_Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AuthorID,PagesCount,Size,Fi,SubjectID,TranslatorID,Image,CoverType,ISBN,ReleasedDate,PublishedDate,circulation,IsTranslated")] Tbl_Books tbl_Books)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Books.Add(tbl_Books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName", tbl_Books.AuthorID);
            ViewBag.TranslatorID = new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName", tbl_Books.TranslatorID);
            ViewBag.SubjectID = new SelectList(db.Tbl_BooksCategories, "ID", "Name", tbl_Books.SubjectID);
            ViewBag.CoverType = new SelectList(db.Tbl_BooksCoverType, "ID", "Name", tbl_Books.CoverType);
            ViewBag.Size = new SelectList(db.Tbl_BooksSize, "ID", "Name", tbl_Books.Size);
            return View(tbl_Books);
        }

        // GET: Tbl_Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Books tbl_Books = db.Tbl_Books.Find(id);
            if (tbl_Books == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName", tbl_Books.AuthorID);
            ViewBag.TranslatorID = new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName", tbl_Books.TranslatorID);
            ViewBag.SubjectID = new SelectList(db.Tbl_BooksCategories, "ID", "Name", tbl_Books.SubjectID);
            ViewBag.CoverType = new SelectList(db.Tbl_BooksCoverType, "ID", "Name", tbl_Books.CoverType);
            ViewBag.Size = new SelectList(db.Tbl_BooksSize, "ID", "Name", tbl_Books.Size);
            return View(tbl_Books);
        }

        // POST: Tbl_Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AuthorID,PagesCount,Size,Fi,SubjectID,TranslatorID,Image,CoverType,ISBN,ReleasedDate,PublishedDate,circulation,IsTranslated")] Tbl_Books tbl_Books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName", tbl_Books.AuthorID);
            ViewBag.TranslatorID = new SelectList(db.Tbl_authorsAndTranslators, "ID", "FName", tbl_Books.TranslatorID);
            ViewBag.SubjectID = new SelectList(db.Tbl_BooksCategories, "ID", "Name", tbl_Books.SubjectID);
            ViewBag.CoverType = new SelectList(db.Tbl_BooksCoverType, "ID", "Name", tbl_Books.CoverType);
            ViewBag.Size = new SelectList(db.Tbl_BooksSize, "ID", "Name", tbl_Books.Size);
            return View(tbl_Books);
        }

        // GET: Tbl_Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Books tbl_Books = db.Tbl_Books.Find(id);
            if (tbl_Books == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Books);
        }

        // POST: Tbl_Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Books tbl_Books = db.Tbl_Books.Find(id);
            db.Tbl_Books.Remove(tbl_Books);
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
