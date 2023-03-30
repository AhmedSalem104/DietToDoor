using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("SignForm", Schema = "GL")]
   public class SignForm
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

       
        [Required(ErrorMessage = "  هذا الحقل مطلوب")]
        [Column("FullName", TypeName = "nvarchar(MAX)")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("Mobile")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("Address")]
        public string Address { get; set; }


        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("Type")]
        public int Type { get; set; }
        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "  هذا الحقل مطلوب")]

        [Column("HowHear")]
        public string HowHear { get; set; }
        [Column("CurrentWeight")]
        public decimal CurrentWeight { get; set; }

        [Column("Height")]
        public decimal Height { get; set; }
        [Column("waistCircumference")]
        public decimal waistCircumference { get; set; }

        [Column("fatPercentage")]
        public decimal fatPercentage { get; set; }

        [Column("muscleMass")]
        public decimal muscleMass { get; set; }

        [Column("waterPercentage")]
        public decimal waterPercentage { get; set; }

        [Column("ActivityLevel")]
        public string ActivityLevel { get; set; }

        [Column("AlcoholConsumes")]
        public bool AlcoholConsumes { get; set; }
        [Column("Smoker")]
        public bool Smoker { get; set; }

        [Column("HealthCondition")]
        public string HealthCondition { get; set; }

          [Column("DoYouHaveAnyFoodAllergy")]
        public bool DoYouHaveAnyFoodAllergy { get; set; }

        [Column("BodyShapeImage")]
        public string BodyShapeImage { get; set; }

        [Column("LabsImage")]
        public string LabsImage { get; set; }

        [Column("ImportantToKnowAboutMe")]
        public string ImportantToKnowAboutMe { get; set; }

        [Column("fullDayExampleFromWakingUpToSleep")]
        public string fullDayExampleFromWakingUpToSleep { get; set; }

        [Column("WakingUpTime")]
        public string WakingUpTime { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }

    
    }
}
