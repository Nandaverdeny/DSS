namespace PM.DSS.App.Web.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NonAcademicCategories", "ValueType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NonAcademicCategories", "ValueType");
        }
    }
}
