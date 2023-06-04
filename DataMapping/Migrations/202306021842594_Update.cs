namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropTable("GL.ListMeals");
        }
        
        public override void Down()
        {
            CreateTable(
                "GL.ListMeals",
                c => new
                    {
                        LM_ID = c.Int(nullable: false, identity: true),
                        LM_M_ID = c.Int(),
                        LM_P_ID = c.Int(),
                        LM_PT_ID = c.Int(),
                        LM_C_ID = c.Int(),
                        LM_ClientCount = c.Int(),
                        LM_Calorie = c.Single(),
                        LM_SDate = c.DateTime(),
                        LM_EDate = c.DateTime(),
                        TF1 = c.Single(),
                        TF2 = c.Single(),
                        TF3 = c.Single(),
                        TF4 = c.Single(),
                        TF5 = c.Single(),
                        TF6 = c.Single(),
                        TF7 = c.Single(),
                        TF8 = c.Single(),
                        TF9 = c.Single(),
                        TF10 = c.Single(),
                        TF11 = c.Single(),
                        TF12 = c.Single(),
                        TF13 = c.Single(),
                        TF14 = c.Single(),
                        TF15 = c.Single(),
                        TF16 = c.Single(),
                        TF17 = c.Single(),
                        TF18 = c.Single(),
                        TF19 = c.Single(),
                        TF20 = c.Single(),
                        TVChar1 = c.String(),
                        TVChar2 = c.DateTime(),
                        TVChar3 = c.String(),
                        TVChar4 = c.String(),
                        TVChar5 = c.String(),
                        TVChar6 = c.String(),
                        TVChar7 = c.String(),
                        TVChar8 = c.String(),
                        TVChar9 = c.String(),
                        TVChar10 = c.String(),
                        TVChar11 = c.String(),
                        TVChar12 = c.String(),
                        TVChar13 = c.String(),
                        TVChar14 = c.String(),
                        TVChar15 = c.String(),
                        TVChar16 = c.String(),
                        TVChar17 = c.String(),
                        TVChar18 = c.String(),
                        TVChar19 = c.String(),
                        TVChar20 = c.String(),
                    })
                .PrimaryKey(t => t.LM_ID);
            
        }
    }
}
