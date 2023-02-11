namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class general_properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployerDetails", "Editor", c => c.String());
            AddColumn("dbo.EmployerDetails", "DateofModification", c => c.DateTime());
            AddColumn("dbo.MinistryDetails", "Editor", c => c.String());
            AddColumn("dbo.MinistryDetails", "DateofModification", c => c.DateTime());
            AddColumn("dbo.Professions", "Editor", c => c.String());
            AddColumn("dbo.Professions", "DateofModification", c => c.DateTime());
            AddColumn("dbo.Profiles", "Editor", c => c.String());
            AddColumn("dbo.Profiles", "DateofModification", c => c.DateTime());
            AddColumn("dbo.ResearchAreas", "Editor", c => c.String());
            AddColumn("dbo.ResearchAreas", "DateofModification", c => c.DateTime());
            AddColumn("dbo.Sections", "Editor", c => c.String());
            AddColumn("dbo.Sections", "DateofModification", c => c.DateTime());
            AddColumn("dbo.SurveyForms", "Editor", c => c.String());
            AddColumn("dbo.SurveyForms", "DateofModification", c => c.DateTime());
            AddColumn("dbo.SurveyQuestionTypes", "Editor", c => c.String());
            AddColumn("dbo.SurveyQuestionTypes", "DateofModification", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyQuestionTypes", "DateofModification");
            DropColumn("dbo.SurveyQuestionTypes", "Editor");
            DropColumn("dbo.SurveyForms", "DateofModification");
            DropColumn("dbo.SurveyForms", "Editor");
            DropColumn("dbo.Sections", "DateofModification");
            DropColumn("dbo.Sections", "Editor");
            DropColumn("dbo.ResearchAreas", "DateofModification");
            DropColumn("dbo.ResearchAreas", "Editor");
            DropColumn("dbo.Profiles", "DateofModification");
            DropColumn("dbo.Profiles", "Editor");
            DropColumn("dbo.Professions", "DateofModification");
            DropColumn("dbo.Professions", "Editor");
            DropColumn("dbo.MinistryDetails", "DateofModification");
            DropColumn("dbo.MinistryDetails", "Editor");
            DropColumn("dbo.EmployerDetails", "DateofModification");
            DropColumn("dbo.EmployerDetails", "Editor");
        }
    }
}
