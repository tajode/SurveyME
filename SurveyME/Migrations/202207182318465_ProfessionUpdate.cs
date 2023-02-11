namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfessionUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professions", "ProfessionName", c => c.String());
            DropColumn("dbo.Professions", "ProfessionsList");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Professions", "ProfessionsList", c => c.String());
            DropColumn("dbo.Professions", "ProfessionName");
        }
    }
}
