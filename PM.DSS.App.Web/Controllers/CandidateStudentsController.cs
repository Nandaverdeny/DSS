using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM.DSS.App.Entities;
using PM.DSS.App.Web.Context;

namespace PM.DSS.App.Web.Controllers
{
    public class CandidateStudentsController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: CandidateStudents
        public ActionResult Index()
        {
            return View(db.CandidateStudents.ToList());
        }

        // GET: CandidateStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateStudent candidateStudent = db.CandidateStudents.Find(id);
            if (candidateStudent == null)
            {
                return HttpNotFound();
            }
            return View(candidateStudent);
        }

        // GET: CandidateStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Major,Description,DateofBirth,PlaceofBirth,Address,PhoneNumber,YearsAttend")] CandidateStudent candidateStudent)
        {
            if (ModelState.IsValid)
            {
                db.CandidateStudents.Add(candidateStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidateStudent);
        }

        // GET: CandidateStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateStudent candidateStudent = db.CandidateStudents.Find(id);
            if (candidateStudent == null)
            {
                return HttpNotFound();
            }
            return View(candidateStudent);
        }

        // POST: CandidateStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Major,Description,DateofBirth,PlaceofBirth,Address,PhoneNumber,YearsAttend")] CandidateStudent candidateStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidateStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidateStudent);
        }

        // GET: CandidateStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CandidateStudent candidateStudent = db.CandidateStudents.Find(id);
            if (candidateStudent == null)
            {
                return HttpNotFound();
            }
            return View(candidateStudent);
        }

        // POST: CandidateStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CandidateStudent candidateStudent = db.CandidateStudents.Find(id);
            db.CandidateStudents.Remove(candidateStudent);
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
