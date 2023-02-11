namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Surveyquestion_type : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyQuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        IPAddress = c.String(),
                        QuestionType_Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SurveyQuestionTypes");
        }
    }
}
