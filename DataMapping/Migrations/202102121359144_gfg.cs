namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfg : DbMigration
    {
        public override void Up()
        {
            AddColumn("GL.Branches", "Name", c => c.String());
            AddColumn("GL.City", "Name", c => c.String(nullable: false));
            AddColumn("GL.Country", "Name", c => c.String(nullable: false));
            AddColumn("Gl.Department", "Name", c => c.String(nullable: false));
            AddColumn("GL.Jobs", "Name", c => c.String(nullable: false));
            AddColumn("GL.StorePlace", "Name", c => c.String(nullable: false));
            AddColumn("GL.Uint", "Name", c => c.String(nullable: false));
            DropColumn("GL.Branches", "NameEn");
            DropColumn("GL.Branches", "NameAr");
            DropColumn("GL.City", "NameEn");
            DropColumn("GL.City", "NameAr");
            DropColumn("GL.Country", "NameAr");
            DropColumn("GL.Country", "NameEn");
            DropColumn("Gl.Department", "NameEn");
            DropColumn("Gl.Department", "NameAr");
            DropColumn("GL.Jobs", "NameEn");
            DropColumn("GL.Jobs", "NameAr");
            DropColumn("GL.StorePlace", "NameEn");
            DropColumn("GL.StorePlace", "NameAr");
            DropColumn("GL.Uint", "NameEn");
            DropColumn("GL.Uint", "NameAr");
        }
        
        public override void Down()
        {
            AddColumn("GL.Uint", "NameAr", c => c.String(nullable: false));
            AddColumn("GL.Uint", "NameEn", c => c.String(nullable: false));
            AddColumn("GL.StorePlace", "NameAr", c => c.String(nullable: false));
            AddColumn("GL.StorePlace", "NameEn", c => c.String(nullable: false));
            AddColumn("GL.Jobs", "NameAr", c => c.String(nullable: false));
            AddColumn("GL.Jobs", "NameEn", c => c.String(nullable: false));
            AddColumn("Gl.Department", "NameAr", c => c.String(nullable: false));
            AddColumn("Gl.Department", "NameEn", c => c.String(nullable: false));
            AddColumn("GL.Country", "NameEn", c => c.String(nullable: false));
            AddColumn("GL.Country", "NameAr", c => c.String(nullable: false));
            AddColumn("GL.City", "NameAr", c => c.String(nullable: false));
            AddColumn("GL.City", "NameEn", c => c.String(nullable: false));
            AddColumn("GL.Branches", "NameAr", c => c.String());
            AddColumn("GL.Branches", "NameEn", c => c.String());
            DropColumn("GL.Uint", "Name");
            DropColumn("GL.StorePlace", "Name");
            DropColumn("GL.Jobs", "Name");
            DropColumn("Gl.Department", "Name");
            DropColumn("GL.Country", "Name");
            DropColumn("GL.City", "Name");
            DropColumn("GL.Branches", "Name");
        }
    }
}
