namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class academiclevels_surveyforms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyForms", "TargetAcademicLevels", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyForms", "TargetAcademicLevels");
        }
    }
}
