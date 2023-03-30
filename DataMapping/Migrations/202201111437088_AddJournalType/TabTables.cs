namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJournalTypeTabTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.JournalTab",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalTabName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GL.JournalType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.JournalType");
            DropTable("GL.JournalTab");
        }
    }
}
