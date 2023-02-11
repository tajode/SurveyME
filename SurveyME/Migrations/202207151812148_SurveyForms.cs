namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyForms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateofCreation = c.DateTime(nullable: false),
                        SurveyTitle = c.String(),
                        SurveyDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SurveyForms");
        }
    }
}
