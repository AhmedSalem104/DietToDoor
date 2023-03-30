namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class osama : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.Country", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("GL.Country", "Notes");
        }
    }
}
