using System.Collections.Generic;

namespace PM.DSS.App.Web.Services
{
    public class AcademicInformationViewModel
    {
        public AcademicInformationViewModel()
        {
            this.listNationalExam = new List<RowViewModel>();
            this.listReportCard = new List<RowViewModel>();
            this.listNonAcademic = new List<RowViewModel>();
        }
        public List<RowViewModel> listNationalExam { get; set; }
        public List<RowViewModel> listReportCard { get; set; }
        public List<RowViewModel> listNonAcademic { get; set; }
    }
}