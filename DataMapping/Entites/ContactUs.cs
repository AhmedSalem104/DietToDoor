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
        
        public bool Satissfied { get; set; }
      
        public bool NotSatissfied { get; set; }
      
        public int? SubjectId { get; set; }

        public string Comment { get; set; }

        public string Attachment { get; set; }
    }
}