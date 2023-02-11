namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordstracking_V1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyQuestionTypes", "DateofCreation", c => c.DateTime(nullable: false));
            DropColumn("dbo.BinaryChoices", "HostAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BinaryChoices", "HostAddress", c => c.String());
            DropColumn("dbo.SurveyQuestionTypes", "DateofCreation");
        }
    }
}
