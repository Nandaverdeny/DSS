using PM.DSS.App.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PM.DSS.App.Web.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {
        }

        public DbSet<Criteria> ListCriteria { get; set; }
        public DbSet<CandidateStudent> CandidateStudents { get; set; }
        public DbSet<AcademicInformation> AcademicInformations { get; set; }
        public DbSet<NonAcademicInformation> NonAcademicInformations { get; set; }
        public DbSet<NonAcademicCategory> NonAcademicCategories { get; set; }
    }
}