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
    public class NonAcademicCategoriesController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: NonAcademicCategories
        public ActionResult Index()
        {
            return View(db.NonAcademicCategories.ToList());
        }

        // GET: NonAcademicCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcademicCategory nonAcademicCategory = db.NonAcademicCategories.Find(id);
            if (nonAcademicCategory == null)
            {
                return HttpNotFound();
            }
            return View(nonAcademicCategory);
        }

        // GET: NonAcademicCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NonAcademicCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,ValueType")] NonAcademicCategory nonAcademicCategory)
        {
            if (ModelState.IsValid)
            {
                db.NonAcademicCategories.Add(nonAcademicCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nonAcademicCategory);
        }

        // GET: NonAcademicCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcademicCategory nonAcademicCategory = db.NonAcademicCategories.Find(id);
            if (nonAcademicCategory == null)
            {
                return HttpNotFound();
            }
            return View(nonAcademicCategory);
        }

        // POST: NonAcademicCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,ValueType")] NonAcademicCategory nonAcademicCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nonAcademicCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nonAcademicCategory);
        }

        // GET: NonAcademicCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcademicCategory nonAcademicCategory = db.NonAcademicCategories.Find(id);
            if (nonAcademicCategory == null)
            {
                return HttpNotFound();
            }
            return View(nonAcademicCategory);
        }

        // POST: NonAcademicCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NonAcademicCategory nonAcademicCategory = db.NonAcademicCategories.Find(id);
            db.NonAcademicCategories.Remove(nonAcademicCategory);
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
