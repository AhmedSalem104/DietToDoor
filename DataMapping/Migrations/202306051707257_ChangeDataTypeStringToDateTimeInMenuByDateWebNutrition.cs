namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeStringToDateTimeInMenuByDateWebNutrition : DbMigration
    {
        public override void Up()
        {
            AlterColumn("GL.MenuByDateWebNutrition", "FromDate", c => c.DateTime(nullable: false));
            AlterColumn("GL.MenuByDateWebNutrition", "ToDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("GL.MenuByDateWebNutrition", "ToDate", c => c.String());
            AlterColumn("GL.MenuByDateWebNutrition", "FromDate", c => c.String());
        }
    }
}
