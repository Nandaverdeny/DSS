using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.DSS.App.Entities;

namespace PM.DSS.App.Web.Services
{
    public interface IReportService
    {
        List<NonAcademicCategory> GetNonAcademicCategories();
        List<CandidateStudent> GetCandidateStudents();
        //Normalisation
        double[][] CalculateConsistencyRatio();
        List<CriteriaViewModel> CalculateEigenVector(List<CriteriaViewModel> list);
    }
}
