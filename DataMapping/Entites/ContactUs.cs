using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataMapping.Entites
{
    [Table("ContactUs", Schema = "GL")]
    public class ContactUs
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("ClientId")]
        public int? ClientId { get; set; }

        public bool Satissfied { get; set; }
      
        public bool NotSatissfied { get; set; }
      
        public int? SubjectId { get; set; }

        public int? ServiceOpinionId { get; set; }

        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }

        public string Comment { get; set; }

        [Column("Attachment")]
        public string Attachment { get; set; }
    }
}