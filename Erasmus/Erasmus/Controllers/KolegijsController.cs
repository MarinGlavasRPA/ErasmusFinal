using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Erasmus.Models;

namespace Erasmus.Controllers
{
    public class KolegijsController : Controller
    {
        private KolegijDbContext db = new KolegijDbContext();

        // GET: Kolegijs
        public ActionResult Index()
        {
            var kolegijs = db.Kolegijs.Include(k => k.Students);
            return View(kolegijs.ToList());
        }

        // GET: Kolegijs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegijs.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // GET: Kolegijs/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(new StudentDbContext().Students, "ID", "PunoImeStudenta"); return View();
        }

        // POST: Kolegijs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NazivKolegija,NositeljKolegija,StudentID,RBrRoka,DatumRoka,Ocjena")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Kolegijs.Add(kolegij);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(new StudentDbContext().Students, "ID", "PunoImeStudenta", kolegij.StudentID); return View(kolegij);
        }

        // GET: Kolegijs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegijs.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "PunoImeStudenta", kolegij.StudentID);
            return View(kolegij);
        }

        // POST: Kolegijs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NazivKolegija,NositeljKolegija,StudentID,RBrRoka,DatumRoka,Ocjena")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolegij).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "PunoImeStudenta", kolegij.StudentID);
            return View(kolegij);
        }

        // GET: Kolegijs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegijs.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij kolegij = db.Kolegijs.Find(id);
            db.Kolegijs.Remove(kolegij);
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
        public ActionResult SearchIndex(string searchNositelj, string searchString)
        {


            var nositeljList = new List<string>();

            var nositeljUpit = from n in db.Kolegijs
                               orderby n.NositeljKolegija
                               select n.NositeljKolegija;
            nositeljList.AddRange(nositeljUpit.Distinct());
            ViewBag.searchNositelj = new SelectList(nositeljList);

            var kolegijs = from k in db.Kolegijs
                           select k;

            if (!String.IsNullOrEmpty(searchString))
            {
                kolegijs = kolegijs.Where(s => s.NazivKolegija.Contains(searchString));
            }

            if (string.IsNullOrEmpty(searchNositelj))
                return View(kolegijs);
            else
            {
                return View(kolegijs.Where(x => x.NositeljKolegija == searchNositelj));
            }
        }
    }
}
    
