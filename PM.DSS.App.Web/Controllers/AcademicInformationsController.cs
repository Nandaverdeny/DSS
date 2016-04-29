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
    public class AcademicInformationsController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: AcademicInformations
        public ActionResult Index()
        {
            var academicInformations = db.AcademicInformations.Include(a => a.CandidateStudent);
            return View(academicInformations.ToList());
        }

        // GET: AcademicInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicInformation academicInformation = db.AcademicInformations.Find(id);
            if (academicInformation == null)
            {
                return HttpNotFound();
            }
            return View(academicInformation);
        }

        // GET: AcademicInformations/Create
        public ActionResult Create()
        {
            ViewBag.CandidateStudentID = new SelectList(db.CandidateStudents, "ID", "Name");
            return View();
        }

        // POST: AcademicInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CandidateStudentID,AverageofNationalExam,AverageofReportCard")] AcademicInformation academicInformation)
        {
            if (ModelState.IsValid)
            {
                db.AcademicInformations.Add(academicInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateStudentID = new SelectList(db.CandidateStudents, "ID", "Name", academicInformation.CandidateStudentID);
            return View(academicInformation);
        }

        // GET: AcademicInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicInformation academicInformation = db.AcademicInformations.Find(id);
            if (academicInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateStudentID = new SelectList(db.CandidateStudents, "ID", "Name", academicInformation.CandidateStudentID);
            return View(academicInformation);
        }

        // POST: AcademicInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CandidateStudentID,AverageofNationalExam,AverageofReportCard")] AcademicInformation academicInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateStudentID = new SelectList(db.CandidateStudents, "ID", "Name", academicInformation.CandidateStudentID);
            return View(academicInformation);
        }

        // GET: AcademicInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicInformation academicInformation = db.AcademicInformations.Find(id);
            if (academicInformation == null)
            {
                return HttpNotFound();
            }
            return View(academicInformation);
        }

        // POST: AcademicInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicInformation academicInformation = db.AcademicInformations.Find(id);
            db.AcademicInformations.Remove(academicInformation);
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
