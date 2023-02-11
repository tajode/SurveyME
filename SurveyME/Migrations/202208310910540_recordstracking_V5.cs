namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordstracking_V5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professions", "UserName", c => c.String());
            AddColumn("dbo.Professions", "DateofCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Professions", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professions", "IPAddress");
            DropColumn("dbo.Professions", "DateofCreation");
            DropColumn("dbo.Professions", "UserName");
        }
    }
}
