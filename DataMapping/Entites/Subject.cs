using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Subject", Schema = "Gl")]

    public class Subject
    {
        [Key]
        [Column("SubjectId", TypeName = "int")]
        public int SubjectId { get; set; }

        [Column("SubjectCode")]
        public int? SubjectCode { get; set; }

        [Column("SubjectName")]
        public string SubjectName { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
