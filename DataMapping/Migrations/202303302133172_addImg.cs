namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.SignForm", "LabsImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("GL.SignForm", "LabsImage");
        }
    }
}
