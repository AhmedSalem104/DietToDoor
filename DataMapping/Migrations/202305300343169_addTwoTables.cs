namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTwoTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.MealType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.WeeklyMeals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(),
                        MealId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        MealType = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.WeeklyMeals");
            DropTable("GL.MealType");
        }
    }
}
