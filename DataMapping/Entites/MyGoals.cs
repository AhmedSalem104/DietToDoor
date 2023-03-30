using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataMapping.Entites
{
    [Table("MyGoals", Schema = "GL")]
    public class MyGoals
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("UserId", TypeName = "int")]
        public int UserId { get; set; }
       
        [Column("GoalId")]
        public int GoalId { get; set; }

      

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
