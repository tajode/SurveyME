namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sitequotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteQuotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteContent = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteQuotes");
        }
    }
}
