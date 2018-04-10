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
    public class StudentsController : Controller
    {
        private StudentDbContext db = new StudentDbContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AkademskaGodina,Rok,StudijskiProgram,PodrucjeStudija,PunoImeStudenta,DatumRodenja,Spol,MjestoRodenja,ZemljaRodenja,Nacionalnost,OIB,SveucilisteInstitucija,SkolaOdjel,GradStudija,ZemljaStudija,Datum")] Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                // provjera je li slika učitanja, te ako je - treba procitati byteove 
                if (image != null)
                {
                    student.MimeTypeSlika = image.ContentType;
                    student.SlikaDatoteka = new byte[image.ContentLength];
                    image.InputStream.Read(student.SlikaDatoteka, 0, image.ContentLength);
                }

                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }


        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AkademskaGodina,Rok,StudijskiProgram,PodrucjeStudija,PunoImeStudenta,DatumRodenja,Spol,MjestoRodenja,ZemljaRodenja,Nacionalnost,OIB,SveucilisteInstitucija,SkolaOdjel,GradStudija,ZemljaStudija,Datum")] Student student, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    student.MimeTypeSlika = image.ContentType;
                    student.SlikaDatoteka = new byte[image.ContentLength];
                    image.InputStream.Read(student.SlikaDatoteka, 0, image.ContentLength);
                }

                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileContentResult DohvatiSliku(int slikaId)
        {
            // Dohvati sliku gdje odgovara Id s Idem u bazi / Get the right photo
            Student slika = db.Students.FirstOrDefault(p => p.ID == slikaId);
            if (slika != null)
            {
                return File(slika.SlikaDatoteka, slika.MimeTypeSlika);
            }
            else
            {
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult SearchIndex(string searchProgram, string searchString)
        {


            var programList = new List<string>();

            var programUpit = from p in db.Students
                           orderby p.StudijskiProgram
                           select p.StudijskiProgram;
            programList.AddRange(programUpit.Distinct());
            ViewBag.searchProgram = new SelectList(programList);

            var students = from s in db.Students
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.PunoImeStudenta.Contains(searchString));
            }

            if (string.IsNullOrEmpty(searchProgram))
                return View(students);
            else
            {
                return View(students.Where(x => x.StudijskiProgram == searchProgram));
            }

        }// GET: Kolegij/Details/5
        public ActionResult Kolegijs(int? StudentID)
        {
            if (StudentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Kolegij> kolegijs = db.Kolegijs.Where(x => x.StudentID == StudentID);

            return PartialView(kolegijs);
        }

    }
}
    
