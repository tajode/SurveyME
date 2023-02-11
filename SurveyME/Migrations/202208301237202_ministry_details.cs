namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ministry_details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MinistryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameofMinistry = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MinistryDetails");
        }
    }
}
