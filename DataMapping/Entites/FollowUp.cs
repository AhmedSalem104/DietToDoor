using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("FollowUp", Schema = "GL")]

    public class FollowUp
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("ClientId")]
        public int? ClientId { get; set; }

        [Column("CurrentWeight")]
        public decimal? CurrentWeight { get; set; }
        [Column("CurrentCenterOfCircumference")]
        public decimal? CurrentCenterOfCircumference { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }
        [Column("Attachment")]
        public string Attachment { get; set; }

        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }
    }
}
