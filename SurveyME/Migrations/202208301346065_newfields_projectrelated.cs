namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfields_projectrelated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "NameofEmployer", c => c.String());
            AddColumn("dbo.SurveyForms", "ProjectName", c => c.String());
            AddColumn("dbo.SurveyForms", "MinistryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyForms", "MinistryName");
            DropColumn("dbo.SurveyForms", "ProjectName");
            DropColumn("dbo.Profiles", "NameofEmployer");
        }
    }
}
