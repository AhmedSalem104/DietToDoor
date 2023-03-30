namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mo : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.Currencies", "Name", c => c.String(nullable: false));
            DropColumn("GL.Currencies", "Code");
            DropColumn("GL.Currencies", "NameEn");
            DropColumn("GL.Currencies", "NameAr");
            DropColumn("GL.Currencies", "CreatedBy");
            DropColumn("GL.Currencies", "CreatedDate");
            DropColumn("GL.Currencies", "UpdatedBy");
            DropColumn("GL.Currencies", "UpdatedDate");
        }
        
        public override void Down()
        {
            AddColumn("GL.Currencies", "UpdatedDate", c => c.DateTime());
            AddColumn("GL.Currencies", "UpdatedBy", c => c.Int());
            AddColumn("GL.Currencies", "CreatedDate", c => c.DateTime());
            AddColumn("GL.Currencies", "CreatedBy", c => c.Int());
            AddColumn("GL.Currencies", "NameAr", c => c.String(nullable: false));
            AddColumn("GL.Currencies", "NameEn", c => c.String(nullable: false));
            AddColumn("GL.Currencies", "Code", c => c.String());
            DropColumn("GL.Currencies", "Name");
        }
    }
}
