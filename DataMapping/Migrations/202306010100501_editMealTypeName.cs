namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editMealTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.MealType", "MealName", c => c.String());
            DropColumn("GL.MealType", "UsersId");
        }
        
        public override void Down()
        {
            AddColumn("GL.MealType", "UsersId", c => c.Int());
            DropColumn("GL.MealType", "MealName");
        }
    }
}
