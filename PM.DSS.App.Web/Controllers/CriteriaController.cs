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
    public class CriteriaController : Controller
    {
        private EntityContext db = new EntityContext();

        // GET: Criteria
        public ActionResult Index()
        {
            return View(db.ListCriteria.ToList());
        }

        // GET: Criteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criteria criteria = db.ListCriteria.Find(id);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // GET: Criteria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Criteria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Weight")] Criteria criteria)
        {
            if (ModelState.IsValid)
            {
                db.ListCriteria.Add(criteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criteria);
        }

        // GET: Criteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criteria criteria = db.ListCriteria.Find(id);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // POST: Criteria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Weight")] Criteria criteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criteria);
        }

        // GET: Criteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criteria criteria = db.ListCriteria.Find(id);
            if (criteria == null)
            {
                return HttpNotFound();
            }
            return View(criteria);
        }

        // POST: Criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criteria criteria = db.ListCriteria.Find(id);
            db.ListCriteria.Remove(criteria);
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
