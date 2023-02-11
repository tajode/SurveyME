namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class string_array_undoV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyForms", "ProfessionsofInterest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyForms", "ProfessionsofInterest");
        }
    }
}
