using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataMapping.Entites
{
    [Table("FoodFrequency", Schema = "GL")]

    public class FoodFrequency
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [Column("RedMeat")]
        public string RedMeat { get; set; }
        [Column("Chicken")]
        public string Chicken { get; set; }
        [Column("SeaFood")]
        public string SeaFood { get; set; }
        [Column("Fruits")]
        public string Fruits { get; set; }

        [Column("Vegetables")]
        public string Vegetables{ get; set; }
    }
}
