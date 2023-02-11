namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_sitequotes : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SiteQuotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SiteQuotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteTitle = c.String(),
                        QuoteContent = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
