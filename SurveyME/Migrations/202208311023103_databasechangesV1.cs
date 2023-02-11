namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasechangesV1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BinaryChoices", "SurveyForm_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BinaryChoices", "SurveyForm_Id");
        }
    }
}
