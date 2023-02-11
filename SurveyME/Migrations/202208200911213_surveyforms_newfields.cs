namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveyforms_newfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyForms", "Male_gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Female_gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Non_binary_gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Age_group_A", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Age_group_B", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Age_group_C", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Age_group_D", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Age_group_E", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Target_PWDs", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Status_Single", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Status_Married", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Academic_Level_Primary", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Academic_Level_Secondary", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Academic_Level_Diploma", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Academic_Level_Degree", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Academic_Level_Masters", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyForms", "Academic_Level_PhD", c => c.Boolean(nullable: false));
            DropColumn("dbo.SurveyForms", "GendersofInterest");
            DropColumn("dbo.SurveyForms", "TargetAgeGroups");
            DropColumn("dbo.SurveyForms", "TargetMaritialStatus");
            DropColumn("dbo.SurveyForms", "TargetAcademicLevels");
            DropColumn("dbo.SurveyForms", "TargetDisabilityStatus");
            DropColumn("dbo.SurveyForms", "TargetCitiesofResidence");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyForms", "TargetCitiesofResidence", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetDisabilityStatus", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetAcademicLevels", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetMaritialStatus", c => c.String());
            AddColumn("dbo.SurveyForms", "TargetAgeGroups", c => c.String());
            AddColumn("dbo.SurveyForms", "GendersofInterest", c => c.String());
            DropColumn("dbo.SurveyForms", "Academic_Level_PhD");
            DropColumn("dbo.SurveyForms", "Academic_Level_Masters");
            DropColumn("dbo.SurveyForms", "Academic_Level_Degree");
            DropColumn("dbo.SurveyForms", "Academic_Level_Diploma");
            DropColumn("dbo.SurveyForms", "Academic_Level_Secondary");
            DropColumn("dbo.SurveyForms", "Academic_Level_Primary");
            DropColumn("dbo.SurveyForms", "Status_Married");
            DropColumn("dbo.SurveyForms", "Status_Single");
            DropColumn("dbo.SurveyForms", "Target_PWDs");
            DropColumn("dbo.SurveyForms", "Age_group_E");
            DropColumn("dbo.SurveyForms", "Age_group_D");
            DropColumn("dbo.SurveyForms", "Age_group_C");
            DropColumn("dbo.SurveyForms", "Age_group_B");
            DropColumn("dbo.SurveyForms", "Age_group_A");
            DropColumn("dbo.SurveyForms", "Non_binary_gender");
            DropColumn("dbo.SurveyForms", "Female_gender");
            DropColumn("dbo.SurveyForms", "Male_gender");
        }
    }
}
