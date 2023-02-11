namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class string_array : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SurveyForms", "ProfessionsofInterest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyForms", "ProfessionsofInterest", c => c.String());
        }
    }
}
