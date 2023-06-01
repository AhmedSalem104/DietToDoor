namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editWeeklyMeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.WeeklyMeals", "Amount", c => c.Int());
            AddColumn("GL.WeeklyMeals", "DateDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("GL.WeeklyMeals", "DateDay");
            DropColumn("GL.WeeklyMeals", "Amount");
        }
    }
}
