using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("ServiceOpinion", Schema = "Gl")]

    public class ServiceOpinion
    {
        [Key]
        [Column("ServiceOpinionId", TypeName = "int")]
        public int ServiceOpinionId { get; set; }

        [Column("ServiceOpinionCode")]
        public int? ServiceOpinionCode { get; set; }

        [Column("ServiceOpinionName")]
        public string ServiceOpinionName { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
