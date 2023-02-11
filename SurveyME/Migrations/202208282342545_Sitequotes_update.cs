namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sitequotes_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteQuotes", "QuoteTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteQuotes", "QuoteTitle");
        }
    }
}
