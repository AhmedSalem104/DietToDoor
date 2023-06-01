using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.ViewModel
{
   public class WeeklyMealsViewModel
    {
        public int? ClientId { get; set; }
        public DateTime CreateDate { get; set; }

        public List<WeeklyMeals_List> Items { get; set; }
    }
    public class WeeklyMeals_List
    {


        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("ClientId", TypeName = "int")]
        public int? ClientId { get; set; }
        [Column("MealId", TypeName = "int")]
        public int? MealId { get; set; }
        [Column("Amount", TypeName = "int")]
        public int? Amount { get; set; }

        [Column("CreatedDate", TypeName = "datetime")]
        public System.DateTime CreatedDate { get; set; }
        [Column("DateDay", TypeName = "datetime")]
        public System.DateTime DateDay { get; set; }


        [Column("MealType", TypeName = "int")]
        public int? MealType { get; set; }

    }

}
