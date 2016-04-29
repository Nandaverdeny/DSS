using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.DSS.App.Entities
{
    public class NonAcademicInformation
    {
        [Key]
        public int ID { get; set; }
        public int? AcademicInformationID { get; set; }
        public int NonAcademicCategoryID { get; set; }
        public int Value { get; set; }
        [ForeignKey("AcademicInformationID")]
        public virtual AcademicInformation AcademicInformation { get; set; }
        [ForeignKey("NonAcademicCategoryID")]
        public virtual NonAcademicCategory NonAcademicCategory { get; set; }
    }
}