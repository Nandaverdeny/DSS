namespace PM.DSS.App.Web.Migrations.Entity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Criteria");
        }
    }
}
