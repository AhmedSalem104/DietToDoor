using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("WeeklyMeals", Schema = "GL")]

    public class WeeklyMeals
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("ClientId", TypeName = "int")]
        public int? ClientId { get; set; }
        [Column("MealId", TypeName = "int")]
        public int? MealId { get; set; }


        [Column("CreatedDate", TypeName = "datetime")]
        public System.DateTime CreatedDate { get; set; }

      

        [Column("MealType", TypeName = "int")]
        public int? MealType { get; set; }

      
    }
}
