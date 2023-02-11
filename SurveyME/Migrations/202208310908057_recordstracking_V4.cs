namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordstracking_V4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "IPAddress");
        }
    }
}
