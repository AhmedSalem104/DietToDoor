using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace DataMapping.Entites
{
    [Table("CurrencyExchangeRates", Schema = "GL")]
  public  class CurrencyExchangeRates
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("CompanyId", TypeName = "int")]
        public int? CompanyId { get; set; }
        [Column("BranchesId", TypeName = "int")]
        public int? BranchesId { get; set; }
        //[Required]
        [Column("CurrencyExchangeRatesNo", TypeName = "int")]
        public int? CurrencyExchangeRatesNo { get; set; }
        [Required(ErrorMessage = " ادخل التاريخ  ")]

        [DataType(DataType.Date)]
        [Column("TransformDate")]
        public DateTime TransformDate { get; set; }
        [Required(ErrorMessage = " ادخل المبلغ")]
        [Column("TransformPrice")]
        public decimal? TransformPrice { get; set; }
        [BindRequired]
        [Required(ErrorMessage = " اختر كود العملة")]
        [Column("CurrencyNo", TypeName = "int")]
        public int CurrencyNo { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        //[Column("CreatedBy", TypeName = "int")]
        //public int? CreatedBy { get; set; }

        //[Column("CreatedDate", TypeName = "datetime")]
        //public DateTime? CreatedDate { get; set; }

        //[Column("UpdatedBy", TypeName = "int")]
        //public int? UpdatedBy { get; set; }

        //[Column("UpdatedDate", TypeName = "datetime")]
        //public DateTime? UpdatedDate { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
