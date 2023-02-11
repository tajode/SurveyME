namespace SurveyME.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class binarychoice_newproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BinaryChoices", "Section_Id", c => c.Int(nullable: false));
            AddColumn("dbo.BinaryChoices", "Editor", c => c.String());
            AddColumn("dbo.BinaryChoices", "DateofModification", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BinaryChoices", "DateofModification");
            DropColumn("dbo.BinaryChoices", "Editor");
            DropColumn("dbo.BinaryChoices", "Section_Id");
        }
    }
}
