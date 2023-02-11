namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordstracking_V3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResearchAreas", "UserName", c => c.String());
            AddColumn("dbo.ResearchAreas", "DateofCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.ResearchAreas", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResearchAreas", "IPAddress");
            DropColumn("dbo.ResearchAreas", "DateofCreation");
            DropColumn("dbo.ResearchAreas", "UserName");
        }
    }
}
