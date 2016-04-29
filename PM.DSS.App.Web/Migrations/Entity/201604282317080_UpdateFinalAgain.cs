namespace PM.DSS.App.Web.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFinalAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NonAcademicInformations", "AcademicInformation_ID", "dbo.AcademicInformations");
            DropIndex("dbo.NonAcademicInformations", new[] { "AcademicInformation_ID" });
            RenameColumn(table: "dbo.NonAcademicInformations", name: "AcademicInformation_ID", newName: "AcademicInformationID");
            AlterColumn("dbo.NonAcademicInformations", "AcademicInformationID", c => c.Int(nullable: true));
            CreateIndex("dbo.NonAcademicInformations", "AcademicInformationID");
            AddForeignKey("dbo.NonAcademicInformations", "AcademicInformationID", "dbo.AcademicInformations", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NonAcademicInformations", "AcademicInformationID", "dbo.AcademicInformations");
            DropIndex("dbo.NonAcademicInformations", new[] { "AcademicInformationID" });
            AlterColumn("dbo.NonAcademicInformations", "AcademicInformationID", c => c.Int());
            RenameColumn(table: "dbo.NonAcademicInformations", name: "AcademicInformationID", newName: "AcademicInformation_ID");
            CreateIndex("dbo.NonAcademicInformations", "AcademicInformation_ID");
            AddForeignKey("dbo.NonAcademicInformations", "AcademicInformation_ID", "dbo.AcademicInformations", "ID");
        }
    }
}
