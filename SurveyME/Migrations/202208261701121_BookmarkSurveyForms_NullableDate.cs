namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookmarkSurveyForms_NullableDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookmarkedSurveyForms", "DateofStatusChange", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BookmarkedSurveyForms", "DateofStatusChange", c => c.DateTime(nullable: false));
        }
    }
}
