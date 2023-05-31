namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAllMealRecipesTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.AllMealRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeRow = c.String(),
                        MMealID = c.Int(),
                        MMealEngName = c.String(),
                        MMealArName = c.String(),
                        MMealTotalWeighing = c.String(),
                        MMealTotalYield = c.String(),
                        MMealCalorie = c.Single(),
                        SMMealID = c.Int(),
                        SMMealEngName = c.String(),
                        SMMealArName = c.String(),
                        SMMealTotalWeighing = c.String(),
                        SMMealTotalYield = c.String(),
                        SMMealCalorie = c.Single(),
                        RmId = c.Int(),
                        RowMEngName = c.String(),
                        RowMArName = c.String(),
                        MRecipeID = c.Int(),
                        MRecipeWeighing = c.Single(),
                        MRecipeYield = c.Single(),
                        RowMCalorie = c.Single(),
                        LM_ClientCount = c.Int(),
                        LM_Calorie = c.Single(),
                        QuaGram = c.Single(),
                        QuaYield = c.Single(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.AllMealRecipes");
        }
    }
}
