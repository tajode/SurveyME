namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sections_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DateofCreation = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                        SectionTitle = c.String(),
                        SectionDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sections");
        }
    }
}
