using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("InvoicesSettings", Schema = "Gl")]
    public class InvoicesSettings
    {
        [Key]
        [Column("InvoicesSettingId", TypeName = "int")]
        public int InvoicesSettingId { get; set; }

        [Column("YearId", TypeName = "int")]
        public int? YearId { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("Conditions", TypeName = "nvarchar(MAX)")]
        public string Conditions { get; set; }

        //[Required(ErrorMessage = "  الأسم مطلوب")]
        [Column("Notes", TypeName = "nvarchar(MAX)")]
        public string Notes { get; set; }
    }
}
