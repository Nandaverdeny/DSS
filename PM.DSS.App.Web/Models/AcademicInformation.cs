using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DSS.App.Entities
{
    public class AcademicInformation
    {
        [Key]
        public int ID { get; set; }
        public int CandidateStudentID { get; set; }
        [Required]
        public decimal AverageofNationalExam { get; set; }
        [Required]
        public decimal AverageofReportCard { get; set; }
        public virtual ICollection<NonAcademicInformation> NonAcademicInformation { get; set; }
        [ForeignKey("CandidateStudentID")]
        public virtual CandidateStudent CandidateStudent { get; set; }
    }
}