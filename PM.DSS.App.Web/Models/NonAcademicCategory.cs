using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PM.DSS.App.Entities
{
    public class NonAcademicCategory
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string ValueType { get; set; }
        public virtual ICollection<NonAcademicInformation> NonAcademicInformation { get; set; }
    }
}