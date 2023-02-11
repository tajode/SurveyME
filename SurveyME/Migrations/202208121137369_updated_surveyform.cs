namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_surveyform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyForms", "ResearchArea", c => c.String());
            AddColumn("dbo.SurveyForms", "ProfessionsofInterest", c => c.String());
            AddColumn("dbo.SurveyForms", "GendersofInterest", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetAgeGroups", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetMaritialStatus", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetDisabilityStatus", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetCitiesofResidence", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyForms", "TargetCitiesofResidence");
            DropColumn("dbo.SurveyForms", "TargetDisabilityStatus");
            DropColumn("dbo.SurveyForms", "TargetMaritialStatus");
            DropColumn("dbo.SurveyForms", "TargetAgeGroups");
            DropColumn("dbo.SurveyForms", "GendersofInterest");
            DropColumn("dbo.SurveyForms", "ProfessionsofInterest");
            DropColumn("dbo.SurveyForms", "ResearchArea");
        }
    }
}
