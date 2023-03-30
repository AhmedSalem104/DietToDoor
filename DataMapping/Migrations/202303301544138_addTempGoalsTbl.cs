namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTempGoalsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.TempGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.TempGoals");
        }
    }
}
