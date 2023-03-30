namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGoalsAndFoodFreqTbl1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.FoodFrequency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RedMeat = c.String(),
                        Chicken = c.String(),
                        SeaFood = c.String(),
                        Fruits = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.MyGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GoalId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.MyGoals");
            DropTable("GL.Goals");
            DropTable("GL.FoodFrequency");
        }
    }
}
