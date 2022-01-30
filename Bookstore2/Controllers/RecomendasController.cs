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
    public class RecomendasController : Controller
     
    {

        private RecomenEntities db = new RecomenEntities();
        private BookstoreEntities db2 = new BookstoreEntities();

 
        // GET: Recomendas
        public ActionResult Index()
        {
            var res = new List<Recomenda>();
            var recom = db.Recomenda.Select(x => x.author).ToList();
            var datea = db.Recomenda.Select(x => x.published).ToList();
            var booksr = db2.tBooks.Select(x => x.Author).ToList();
           


            tBooks books = TempData["books"] as tBooks;

            foreach(var v in booksr)
            {
                var entities = db.Recomenda.Where(i => i.author.Contains(v)).ToList();
                res.AddRange(entities);
            }

            return View(res);
            

            //db.Recomenda.ToList()
        }

        [HttpPost]
        public ActionResult Index(DateTime fecha)
        {
            return View(db.Recomenda.Where(i => i.published >= fecha).ToList());
        }


        // GET: Recomendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomenda recomenda = db.Recomenda.Find(id);
            if (recomenda == null)
            {
                return HttpNotFound();
            }
            return View(recomenda);
        }

        // GET: Recomendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recomendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,author,published")] Recomenda recomenda)
        {
            if (ModelState.IsValid)
            {
                db.Recomenda.Add(recomenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recomenda);
        }

        // GET: Recomendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomenda recomenda = db.Recomenda.Find(id);
            if (recomenda == null)
            {
                return HttpNotFound();
            }
            return View(recomenda);
        }

        // POST: Recomendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,author,published")] Recomenda recomenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recomenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recomenda);
        }

        // GET: Recomendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomenda recomenda = db.Recomenda.Find(id);
            if (recomenda == null)
            {
                return HttpNotFound();
            }
            return View(recomenda);
        }

        // POST: Recomendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recomenda recomenda = db.Recomenda.Find(id);
            db.Recomenda.Remove(recomenda);
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
