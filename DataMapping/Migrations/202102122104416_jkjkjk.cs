namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jkjkjk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.CustomerPrice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.CustomerPrice");
        }
    }
}
