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
    public class NonAcademicInformationsController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: NonAcademicInformations
        public ActionResult Index()
        {
            var nonAcademicInformations = db.NonAcademicInformations.Include(n => n.AcademicInformation).Include(n => n.NonAcademicCategory);
            return View(nonAcademicInformations.ToList());
        }

        // GET: NonAcademicInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcademicInformation nonAcademicInformation = db.NonAcademicInformations.Find(id);
            if (nonAcademicInformation == null)
            {
                return HttpNotFound();
            }
            return View(nonAcademicInformation);
        }

        // GET: NonAcademicInformations/Create
        public ActionResult Create()
        {
            ViewBag.AcademicInformationID = new SelectList(db.AcademicInformations, "ID", "ID");
            ViewBag.NonAcademicCategoryID = new SelectList(db.NonAcademicCategories, "ID", "Code");
            return View();
        }

        // POST: NonAcademicInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AcademicInformationID,NonAcademicCategoryID,Value")] NonAcademicInformation nonAcademicInformation)
        {
            if (ModelState.IsValid)
            {
                db.NonAcademicInformations.Add(nonAcademicInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicInformationID = new SelectList(db.AcademicInformations, "ID", "ID", nonAcademicInformation.AcademicInformationID);
            ViewBag.NonAcademicCategoryID = new SelectList(db.NonAcademicCategories, "ID", "Code", nonAcademicInformation.NonAcademicCategoryID);
            return View(nonAcademicInformation);
        }

        // GET: NonAcademicInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcademicInformation nonAcademicInformation = db.NonAcademicInformations.Find(id);
            if (nonAcademicInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicInformationID = new SelectList(db.AcademicInformations, "ID", "ID", nonAcademicInformation.AcademicInformationID);
            ViewBag.NonAcademicCategoryID = new SelectList(db.NonAcademicCategories, "ID", "Code", nonAcademicInformation.NonAcademicCategoryID);
            return View(nonAcademicInformation);
        }

        // POST: NonAcademicInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AcademicInformationID,NonAcademicCategoryID,Value")] NonAcademicInformation nonAcademicInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nonAcademicInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicInformationID = new SelectList(db.AcademicInformations, "ID", "ID", nonAcademicInformation.AcademicInformationID);
            ViewBag.NonAcademicCategoryID = new SelectList(db.NonAcademicCategories, "ID", "Code", nonAcademicInformation.NonAcademicCategoryID);
            return View(nonAcademicInformation);
        }

        // GET: NonAcademicInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcademicInformation nonAcademicInformation = db.NonAcademicInformations.Find(id);
            if (nonAcademicInformation == null)
            {
                return HttpNotFound();
            }
            return View(nonAcademicInformation);
        }

        // POST: NonAcademicInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NonAcademicInformation nonAcademicInformation = db.NonAcademicInformations.Find(id);
            db.NonAcademicInformations.Remove(nonAcademicInformation);
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
