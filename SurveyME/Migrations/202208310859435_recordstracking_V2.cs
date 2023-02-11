namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordstracking_V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyForms", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyForms", "IPAddress");
        }
    }
}
