using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("TempGoals", Schema = "GL")]

    public class TempGoals
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

      
        [Column("GoalId")]
        public int GoalId { get; set; }
    }
}
