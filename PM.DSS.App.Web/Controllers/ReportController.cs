using PM.DSS.App.Entities;
using PM.DSS.App.Web.Context;
using PM.DSS.App.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.DSS.App.Web.Controllers
{
    public class ReportController : Controller
    {
        private ReportService _service = new ReportService();
        private EntityContext _context;
        // GET: Report
        public ActionResult Index()
        {
            var academicinfo = new List<AcademicInformation>();
            var academicinfoVM = new AcademicInformationViewModel();
            var obj = new AHPViewModel();
            using (_context = new EntityContext())
            {
                academicinfo = _context.AcademicInformations.ToList();
                obj = _service.CalculateAHP(_context.ListCriteria.ToList());


                while (obj.ConsistencyRatio > 0.10)
                {
                    obj = _service.CalculateAHP(obj.listRow);
                }

                //
                foreach (var item in academicinfo)
                {
                    academicinfoVM.listNationalExam.Add(new RowViewModel { Name = item.CandidateStudent.Name, Weight = _service.GetNationalExamPoint(item.AverageofNationalExam) });
                }

                var listNationalExam = _service.CalculateAHP(academicinfoVM.listNationalExam);
                while (listNationalExam.ConsistencyRatio > 0.10)
                {
                    listNationalExam = _service.CalculateAHP(listNationalExam.listRow);
                }
                academicinfoVM.listNationalExam = listNationalExam.listRow;
                //
                foreach (var item in academicinfo)
                {
                    academicinfoVM.listReportCard.Add(new RowViewModel { Name = item.CandidateStudent.Name, Weight = _service.GetReportCardPoint(item.AverageofReportCard) });
                }

                var listReportCard = _service.CalculateAHP(academicinfoVM.listReportCard);
                while (listReportCard.ConsistencyRatio > 0.10)
                {
                    listReportCard = _service.CalculateAHP(listReportCard.listRow);
                }
                academicinfoVM.listReportCard = listReportCard.listRow;
                //
                foreach (var item in academicinfo)
                {
                    academicinfoVM.listNonAcademic.Add(new RowViewModel { Name = item.CandidateStudent.Name, Weight = _service.GetNonAcademicPoint(item.NonAcademicInformation.FirstOrDefault()) });
                }

                var listNonAcademic = _service.CalculateAHP(academicinfoVM.listNonAcademic);
                while (listNonAcademic.ConsistencyRatio > 0.10)
                {
                    listNonAcademic = _service.CalculateAHP(listNonAcademic.listRow);
                }
                academicinfoVM.listNonAcademic = listNonAcademic.listRow;

                return View();
            }
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
