namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class binarychoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BinaryChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DateofCreation = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                        HostAddress = c.String(),
                        Question = c.String(),
                        FirstOption = c.String(),
                        SecondOption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BinaryChoices");
        }
    }
}
