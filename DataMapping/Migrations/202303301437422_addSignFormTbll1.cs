namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSignFormTbll1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "GL.Drivers", newName: "SignForm");
        }
        
        public override void Down()
        {
            RenameTable(name: "GL.SignForm", newName: "Drivers");
        }
    }
}
