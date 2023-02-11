namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordstracking_V6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookmarkedSurveyForms", "IPAddress", c => c.String());
            AddColumn("dbo.EmployerDetails", "UserName", c => c.String());
            AddColumn("dbo.EmployerDetails", "DateofCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployerDetails", "IPAddress", c => c.String());
            AddColumn("dbo.MinistryDetails", "UserName", c => c.String());
            AddColumn("dbo.MinistryDetails", "DateofCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.MinistryDetails", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MinistryDetails", "IPAddress");
            DropColumn("dbo.MinistryDetails", "DateofCreation");
            DropColumn("dbo.MinistryDetails", "UserName");
            DropColumn("dbo.EmployerDetails", "IPAddress");
            DropColumn("dbo.EmployerDetails", "DateofCreation");
            DropColumn("dbo.EmployerDetails", "UserName");
            DropColumn("dbo.BookmarkedSurveyForms", "IPAddress");
        }
    }
}
