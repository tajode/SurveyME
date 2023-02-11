namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profession_register : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Profession", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Profession");
        }
    }
}
