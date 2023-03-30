using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Accounts", Schema = "GL")]
    public class Accounts
    {
        //رقم السطر
        [Key]
        [Column("Id", TypeName = "int")]
        public int AccountId { get; set; }

        // عمود الاب 
        [Column("ParentAccountId", TypeName = "int")]
        [ForeignKey(nameof(ParentAccount))]
        public int? ParentAccountId { get; set; }

        // اسم الحساب
        [Required]
        [Column("AccountName")]
        public string AccountName { get; set; }

        //رقم الحساب
        [Required]
        [Column("AccountNo")]
        public string AccountNo { get; set; }

        // طبيعة الحساب
        [Required]
        [Column("AccountType", TypeName = "int")]
        public int? AccountType { get; set; }
        //// نوع الحساب
        //[Required]
        //[Column("AccountsType", TypeName = "int")]
        //public string AccountsType { get; set; }

        // مستوى الحساب
        [Required]
        [Column("AccountLevel")]
        public int? AccountLevel { get; set; }

        // الترحيل 
        [Column("PostTo", TypeName = "int")]
        public int? PostTo { get; set; }


        // نشط ام غير نشط
        [Column("NotActive")]
        public bool? NotActive { get; set; }
        //له فروع ام لا
        [Column("IsLeaf")]
        public bool? IsLeaf { get; set; }

        // نشط ام غير نشط
        [Column("CurrencyId", TypeName = "int")]
        [ForeignKey(nameof(Currencies))]
        public int? CurrencyId { get; set; }

        [Column("Accounts_TypesId", TypeName = "int")]
        [ForeignKey(nameof(Accounts_Types))]
        public int? Accounts_TypesId { get; set; }

        // الحذف
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }

        // إمكانية الدفع أو التحصيل
        [Column("PaymentOrCollection")]
        public bool? PaymentOrCollection { get; set; }

        
        public virtual Accounts ParentAccount { get; set; }
        public virtual Currencies Currencies { get; set; }
        public virtual Accounts_Types Accounts_Types { get; set; }

    }
}
