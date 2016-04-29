namespace PM.DSS.App.Web.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFinalAgain2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NonAcademicInformations", "AcademicInformationID", "dbo.AcademicInformations");
            DropIndex("dbo.NonAcademicInformations", new[] { "AcademicInformationID" });
            AlterColumn("dbo.NonAcademicInformations", "AcademicInformationID", c => c.Int());
            CreateIndex("dbo.NonAcademicInformations", "AcademicInformationID");
            AddForeignKey("dbo.NonAcademicInformations", "AcademicInformationID", "dbo.AcademicInformations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NonAcademicInformations", "AcademicInformationID", "dbo.AcademicInformations");
            DropIndex("dbo.NonAcademicInformations", new[] { "AcademicInformationID" });
            AlterColumn("dbo.NonAcademicInformations", "AcademicInformationID", c => c.Int(nullable: false));
            CreateIndex("dbo.NonAcademicInformations", "AcademicInformationID");
            AddForeignKey("dbo.NonAcademicInformations", "AcademicInformationID", "dbo.AcademicInformations", "ID", cascadeDelete: true);
        }
    }
}
