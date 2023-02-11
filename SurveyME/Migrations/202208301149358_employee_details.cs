namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee_details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployerDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameofEmployer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployerDetails");
        }
    }
}
