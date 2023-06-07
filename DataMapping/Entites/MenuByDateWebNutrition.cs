using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataMapping.Entites
{
    [Table("MenuByDateWebNutrition", Schema = "GL")]
    public class MenuByDateWebNutrition
    {
        [Key]
        [Column("LM_ID", TypeName = "int")]
        public int LM_ID { get; set; }
        [Column("MH_NameAr")]
        public string MH_NameAr { get; set; }
        [Column("MH_NameEng")]
        public string MH_NameEng { get; set; }
        [Column("FromDate")]
        public DateTime FromDate { get; set; }
        [Column("ToDate")]
        public DateTime ToDate { get; set; }
        [Column("DateDay", TypeName = "datetime")]
        public DateTime? DateDay { get; set; }
        [Column("Program")]
        public float? Program { get; set; }
        [Column("ConvertTProgramType")]
        public float? ConvertTProgramType { get; set; }

        [Column("M1ID")]
        public int? M1ID { get; set; }
        [Column("M1NameEng")]
        public string M1NameEng { get; set; }
        [Column("M1NameAr")]
        public string M1NameAr { get; set; }
        [Column("M1Calories")]
        public float? M1Calories { get; set; }
        [Column("MealTime1")]
        public float? MealTime1 { get; set; }
        [Column("CaloriesPr1")]
        public float? CaloriesPr1 { get; set; }
        [Column("WeighM1")]
        public float? WeighM1 { get; set; }
        [Column("ProteinM1")]
        public float? ProteinM1 { get; set; }
        [Column("FatM1")]
        public float? FatM1 { get; set; }
        [Column("CarbohydrateM1")]
        public float? CarbohydrateM1 { get; set; }


        [Column("M2ID")]
        public int? M2ID { get; set; }
        [Column("M2NameEng")]
        public string M2NameEng { get; set; }
        [Column("M2NameAr")]
        public string M2NameAr { get; set; }
        [Column("M2Calories")]
        public float? M2Calories { get; set; }
        [Column("MealTime2")]
        public float? MealTime2 { get; set; }
        [Column("Expr1")]
        public float? Expr1 { get; set; }
        [Column("WeighM2")]
        public float? WeighM2 { get; set; }
        [Column("ProteinM2")]
        public float? ProteinM2 { get; set; }
        [Column("FatM2")]
        public float? FatM2 { get; set; }
        [Column("CarbohydrateM2")]
        public float? CarbohydrateM2 { get; set; }


        [Column("M3ID")]
        public int? M3ID { get; set; }
        [Column("M3NameEng")]
        public string M3NameEng { get; set; }
        [Column("M3NameAr")]
        public string M3NameAr { get; set; }
        [Column("M3Calories")]
        public float? M3Calories { get; set; }
        [Column("MealTime3")]
        public float? MealTime3 { get; set; }
        [Column("Expr2")]
        public float? Expr2 { get; set; }
        [Column("WeighM3")]
        public float? WeighM3 { get; set; }
        [Column("ProteinM3")]
        public float? ProteinM3 { get; set; }
        [Column("FatM3")]
        public float? FatM3 { get; set; }
        [Column("CarbohydrateM3")]
        public float? CarbohydrateM3 { get; set; }


        [Column("M4ID")]
        public int? M4ID { get; set; }
        [Column("M4NameEng")]
        public string M4NameEng { get; set; }
        [Column("M4NameAr")]
        public string M4NameAr { get; set; }
        [Column("M4Calories")]
        public float? M4Calories { get; set; }
        [Column("MealTime4")]
        public float? MealTime4 { get; set; }
        [Column("Expr3")]
        public float? Expr3 { get; set; }
        [Column("WeighM4")]
        public float? WeighM4 { get; set; }
        [Column("ProteinM4")]
        public float? ProteinM4 { get; set; }
        [Column("FatM4")]
        public float? FatM4 { get; set; }
        [Column("CarbohydrateM4")]
        public float? CarbohydrateM4 { get; set; }


        [Column("M5ID")]
        public int? M5ID { get; set; }
        [Column("M5NameEng")]
        public string M5NameEng { get; set; }
        [Column("M5NameAr")]
        public string M5NameAr { get; set; }
        [Column("M5Calories")]
        public float? M5Calories { get; set; }
        [Column("MealTime5")]
        public float? MealTime5 { get; set; }
        [Column("Expr4")]
        public float? Expr4 { get; set; }
        [Column("WeighM5")]
        public float? WeighM5 { get; set; }
        [Column("ProteinM5")]
        public float? ProteinM5 { get; set; }
        [Column("FatM5")]
        public float? FatM5 { get; set; }
        [Column("CarbohydrateM5")]
        public float? CarbohydrateM5 { get; set; }

        [Column("M6ID")]
        public int? M6ID { get; set; }
        [Column("M6NameEng")]
        public string M6NameEng { get; set; }
        [Column("M6NameAr")]
        public string M6NameAr { get; set; }
        [Column("M6Calories")]
        public float? M6Calories { get; set; }
        [Column("MealTime6")]
        public float? MealTime6 { get; set; }
        [Column("Expr5")]
        public float? Expr5 { get; set; }
        [Column("WeighM6")]
        public float? WeighM6 { get; set; }
        [Column("ProteinM6")]
        public float? ProteinM6 { get; set; }
        [Column("FatM6")]
        public float? FatM6 { get; set; }
        [Column("CarbohydrateM6")]
        public float? CarbohydrateM6 { get; set; }


        [Column("M7ID")]
        public int? M7ID { get; set; }
        [Column("M7NameEng")]
        public string M7NameEng { get; set; }
        [Column("M7NameAr")]
        public string M7NameAr { get; set; }
        [Column("M7Calories")]
        public float? M7Calories { get; set; }
        [Column("MealTime7")]
        public float? MealTime7 { get; set; }
        [Column("Expr6")]
        public float? Expr6 { get; set; }
        [Column("WeighM7")]
        public float? WeighM7 { get; set; }
        [Column("ProteinM7")]
        public float? ProteinM7 { get; set; }
        [Column("FatM7")]
        public float? FatM7 { get; set; }
        [Column("CarbohydrateM7")]
        public float? CarbohydrateM7 { get; set; }

        [Column("M8ID")]
        public int? M8ID { get; set; }
        [Column("M8NameEng")]
        public string M8NameEng { get; set; }
        [Column("M8NameAr")]
        public string M8NameAr { get; set; }
        [Column("M8Calories")]
        public float? M8Calories { get; set; }
        [Column("MealTime8")]
        public float? MealTime8 { get; set; }
        [Column("Expr7")]
        public float? Expr7 { get; set; }
        [Column("WeighM8")]
        public float? WeighM8 { get; set; }
        [Column("ProteinM8")]
        public float? ProteinM8 { get; set; }
        [Column("FatM8")]
        public float? FatM8 { get; set; }
        [Column("CarbohydrateM8")]
        public float? CarbohydrateM8 { get; set; }


        [Column("M9ID")]
        public int? M9ID { get; set; }
        [Column("M9NameEng")]
        public string M9NameEng { get; set; }
        [Column("M9NameAr")]
        public string M9NameAr { get; set; }
        [Column("M9Calories")]
        public float? M9Calories { get; set; }
        [Column("MealTime9")]
        public float? MealTime9 { get; set; }
        [Column("Expr8")]
        public float? Expr8 { get; set; }
        [Column("WeighM9")]
        public float? WeighM9 { get; set; }
        [Column("ProteinM9")]
        public float? ProteinM9 { get; set; }
        [Column("FatM9")]
        public float? FatM9 { get; set; }
        [Column("CarbohydrateM9")]
        public float? CarbohydrateM9 { get; set; }

        [Column("M10ID")]
        public int? M10ID { get; set; }
        [Column("M10NameEng")]
        public string M10NameEng { get; set; }
        [Column("M10NameAr")]
        public string M10NameAr { get; set; }
        [Column("M10Calories")]
        public float? M10Calories { get; set; }
        [Column("MealTime10")]
        public float? MealTime10 { get; set; }
        [Column("Expr9")]
        public float? Expr9 { get; set; }
        [Column("WeighM10")]
        public float? WeighM10 { get; set; }
        [Column("ProteinM10")]
        public float? ProteinM10 { get; set; }
        [Column("FatM10")]
        public float? FatM10 { get; set; }
        [Column("CarbohydrateM10")]
        public float? CarbohydrateM10 { get; set; }












    }
}