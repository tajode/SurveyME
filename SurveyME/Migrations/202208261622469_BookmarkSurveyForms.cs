namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookmarkSurveyForms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookmarkedSurveyForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyFormID = c.String(),
                        UserName = c.String(),
                        BookmarkStatus = c.String(),
                        DateofCreation = c.DateTime(nullable: false),
                        DateofStatusChange = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookmarkedSurveyForms");
        }
    }
}
