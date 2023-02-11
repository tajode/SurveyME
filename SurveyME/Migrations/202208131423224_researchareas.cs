namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class researchareas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResearchAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainArea = c.String(),
                        SubArea = c.String(),
                        Actual_ResearchArea = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResearchAreas");
        }
    }
}
