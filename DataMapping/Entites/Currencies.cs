using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataMapping.Entites
{
    [Table("Currencies", Schema = "GL")]
    public class Currencies
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Required]
        [Column("Name")]
        public string CurrenciesName { get; set; }
        [Column("ConversionRate")]
        public Nullable<decimal> ConversionRate { get; set; }

        [Column("CurrencyNo")]
        public int? CurrencyNo { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }


    }
}
