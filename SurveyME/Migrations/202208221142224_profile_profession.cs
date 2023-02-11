namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profile_profession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Profession", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Profession");
        }
    }
}
