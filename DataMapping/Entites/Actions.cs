using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Actions", Schema = "GL")]
    public class Actions
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("ActionNameAr")]
        public string ActionNameAr { get; set; }

        [Column("ActionNameEn")]
        public string ActionNameEn { get; set; }
    }
}
