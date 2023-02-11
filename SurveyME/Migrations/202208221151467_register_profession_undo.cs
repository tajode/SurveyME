namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class register_profession_undo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Profession");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Profession", c => c.String(nullable: false));
        }
    }
}
