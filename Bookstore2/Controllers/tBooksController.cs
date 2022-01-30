using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;



namespace Bookstore2.Controllers
{
    [Authorize]
    public class tBooksController : Controller
    {
        
        private BookstoreEntities db = new BookstoreEntities();

        // GET: tBooks
        public ActionResult Index()
        {
            var books = db.tBooks.Select(x => x.Author).ToList();
            TempData["books"] = books;

            return  View(db.tBooks.ToList());
        }


        // GET: tBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBooks tBooks = db.tBooks.Find(id);
            if (tBooks == null)
            {
                return HttpNotFound();
            }
            return View(tBooks);
        }

        // GET: tBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Author,Year")] tBooks tBooks)
        {
            if (ModelState.IsValid)
            {
                db.tBooks.Add(tBooks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBooks);
        }

        // GET: tBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBooks tBooks = db.tBooks.Find(id);
            if (tBooks == null)
            {
                return HttpNotFound();
            }
            return View(tBooks);
        }

        // POST: tBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Author,Year")] tBooks tBooks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBooks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBooks);
        }

        // GET: tBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tBooks tBooks = db.tBooks.Find(id);
            if (tBooks == null)
            {
                return HttpNotFound();
            }
            return View(tBooks);
        }

        // POST: tBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tBooks tBooks = db.tBooks.Find(id);
            db.tBooks.Remove(tBooks);
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
