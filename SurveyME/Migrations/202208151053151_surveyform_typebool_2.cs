namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveyform_typebool_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SurveyForms", "GendersofInterest", c => c.String());
            AlterColumn("dbo.SurveyForms", "TargetAgeGroups", c => c.String());
            AlterColumn("dbo.SurveyForms", "TargetMaritialStatus", c => c.String());
            AlterColumn("dbo.SurveyForms", "TargetDisabilityStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurveyForms", "TargetDisabilityStatus", c => c.Boolean());
            AlterColumn("dbo.SurveyForms", "TargetMaritialStatus", c => c.Boolean());
            AlterColumn("dbo.SurveyForms", "TargetAgeGroups", c => c.Boolean());
            AlterColumn("dbo.SurveyForms", "GendersofInterest", c => c.Boolean());
        }
    }
}
