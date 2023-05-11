namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateServiceOpinionEntity1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Gl.ServiceOpinion",
                c => new
                    {
                        ServiceOpinionId = c.Int(nullable: false, identity: true),
                        ServiceOpinionCode = c.Int(),
                        ServiceOpinionName = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.ServiceOpinionId);
            
        }
        
        public override void Down()
        {
            DropTable("Gl.ServiceOpinion");
        }
    }
}
