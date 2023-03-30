namespace DataMapping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSignFormTbll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GL.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        HowHear = c.String(nullable: false),
                        CurrentWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        waistCircumference = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fatPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        muscleMass = c.Decimal(nullable: false, precision: 18, scale: 2),
                        waterPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivityLevel = c.String(),
                        AlcoholConsumes = c.Boolean(nullable: false),
                        Smoker = c.Boolean(nullable: false),
                        HealthCondition = c.String(),
                        DoYouHaveAnyFoodAllergy = c.Boolean(nullable: false),
                        BodyShapeImage = c.String(),
                        ImportantToKnowAboutMe = c.String(),
                        fullDayExampleFromWakingUpToSleep = c.String(),
                        WakingUpTime = c.String(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("GL.Drivers");
        }
    }
}
