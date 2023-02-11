namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class main_research_area : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyForms", "MainResearchArea", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyForms", "MainResearchArea");
        }
    }
}
