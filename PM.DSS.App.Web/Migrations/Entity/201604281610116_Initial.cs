namespace PM.DSS.App.Web.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CandidateStudentID = c.Int(nullable: false),
                        AverageofNationalExam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AverageofReportCard = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CandidateStudents", t => t.CandidateStudentID, cascadeDelete: true)
                .Index(t => t.CandidateStudentID);
            
            CreateTable(
                "dbo.CandidateStudents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Major = c.String(nullable: false),
                        Description = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        PlaceofBirth = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(maxLength: 14),
                        YearsAttend = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NonAcademicInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NonAcademicCategoryID = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        AcademicInformation_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.NonAcademicCategories", t => t.NonAcademicCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.AcademicInformations", t => t.AcademicInformation_ID)
                .Index(t => t.NonAcademicCategoryID)
                .Index(t => t.AcademicInformation_ID);
            
            CreateTable(
                "dbo.NonAcademicCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NonAcademicInformations", "AcademicInformation_ID", "dbo.AcademicInformations");
            DropForeignKey("dbo.NonAcademicInformations", "NonAcademicCategoryID", "dbo.NonAcademicCategories");
            DropForeignKey("dbo.AcademicInformations", "CandidateStudentID", "dbo.CandidateStudents");
            DropIndex("dbo.NonAcademicInformations", new[] { "AcademicInformation_ID" });
            DropIndex("dbo.NonAcademicInformations", new[] { "NonAcademicCategoryID" });
            DropIndex("dbo.AcademicInformations", new[] { "CandidateStudentID" });
            DropTable("dbo.NonAcademicCategories");
            DropTable("dbo.NonAcademicInformations");
            DropTable("dbo.CandidateStudents");
            DropTable("dbo.AcademicInformations");
        }
    }
}
