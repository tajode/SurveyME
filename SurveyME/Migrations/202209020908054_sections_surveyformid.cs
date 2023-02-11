namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sections_surveyformid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "SurveyForm_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "SurveyForm_Id");
        }
    }
}
