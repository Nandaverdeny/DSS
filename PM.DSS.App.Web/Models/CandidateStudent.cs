using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.DSS.App.Entities
{
    public class CandidateStudent
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Major { get; set; }
        public string Description { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string Address { get; set; }
        [MaxLength(14,ErrorMessage ="Phone Number too long"), MinLength(7,ErrorMessage ="Phone Number must valid")]
        public string PhoneNumber { get; set; }
        public int YearsAttend  { get; set; }
        //public int? AcademicInformationId { get; set; }
        //[ForeignKey("AcademicInformationId")]
        public virtual ICollection<AcademicInformation> AcademicInformation { get; set; }
    }
}
