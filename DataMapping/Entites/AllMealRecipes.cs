using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("AllMealRecipes", Schema = "GL")]

    public class AllMealRecipes
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("TypeRow")]
        public string TypeRow { get; set; }

        [Column("MMealID")]
        public int? MMealID { get; set; }

        [Column("MMealEngName")]
        public string MMealEngName { get; set; }

        [Column("MMealArName")]
        public string MMealArName { get; set; }
        [Column("MMealTotalWeighing")]
        public string MMealTotalWeighing { get; set; }

        [Column("MMealTotalYield")]
        public string MMealTotalYield { get; set; }
        [Column("MMealCalorie")]
        public float? MMealCalorie { get; set; }

        [Column("SMMealID")]
        public int? SMMealID { get; set; }
        [Column("SMMealEngName")]
        public string SMMealEngName { get; set; }

        [Column("SMMealArName")]
        public string SMMealArName { get; set; }
        [Column("SMMealTotalWeighing")]
        public string SMMealTotalWeighing { get; set; }

        [Column("SMMealTotalYield")]
        public string SMMealTotalYield { get; set; }
        [Column("SMMealCalorie")]
        public float? SMMealCalorie { get; set; }
        [Column("RmId")]
        public int? RmId { get; set; }

        [Column("RowMEngName")]
        public string RowMEngName { get; set; }
        [Column("RowMArName")]
        public string RowMArName { get; set; }

        [Column("MRecipeID")]
        public int? MRecipeID { get; set; }
        [Column("MRecipeWeighing")]
        public float? MRecipeWeighing { get; set; }

        [Column("MRecipeYield")]
        public float? MRecipeYield { get; set; }

        [Column("RowMCalorie")]
        public float? RowMCalorie { get; set; }
        [Column("LM_ClientCount")]
        public int? LM_ClientCount { get; set; }

        [Column("LM_Calorie")]
        public float? LM_Calorie { get; set; }
        [Column("QuaGram")]
        public float? QuaGram { get; set; }

        [Column("QuaYield")]
        public float? QuaYield { get; set; }
    }
}
