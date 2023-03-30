using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Managments", Schema = "GL")]
    public class Managments
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }
        [Column("ManagmentNo")]
        public int? ManagmentNo { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
