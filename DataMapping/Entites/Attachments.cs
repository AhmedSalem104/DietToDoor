using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataMapping.Entites
{
    [Table("Attachments", Schema = "GL")]
    public class Attachments
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
       
        [Column("RefName", TypeName = "nvarchar(MAX)")]
        public string RefName { get; set; }


        [Column("AttachmentPath")]
        public string AttachmentPath { get; set; }
        [Column("AttachmentName")]
        public string AttachmentName { get; set; }


        [Column("RefId", TypeName = "int")]
        public int? RefId { get; set; }

        
    }
}
