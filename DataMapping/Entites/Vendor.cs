using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Suppliers", Schema = "GL")]
    public class Vendor
    {
        [Key]
        [Column("SupplierId", TypeName = "int")]
        public int Id { get; set; }

        [Column("SupplierId_Old", TypeName = "int")]
        public int SupplierId_Old { get; set; }


        [Required(ErrorMessage = " الاسم مطلوب")]
        [Column("SupplierName")]
        public string SupplierName { get; set; }

        [Column("Notes")]
        public  string  Notes { get; set; }
        [Required(ErrorMessage = " اختر تصنيف المورد")]
        [Column("VendorClassificationId", TypeName = "int")]
        public int? VendorClassificationId { get; set; }
        [Column("IsVendorAndCustomer")]
        public bool? IsVendorAndCustomer { get; set; }
        [Column("Block")]
        public bool? Block { get; set; }
        [Column("OpenBalnceDept")]
        public int? OpenBalnceDept { get; set; }
        [Column("OpenBalnceCridt")]
        public int? OpenBalnceCridt { get; set; }
        [Column("Address")]
        public string Address { get; set; }

        [Column("Mobile")]
        public string Mobile { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("RecordNumber", TypeName = "int")]
        public int? RecordNumber { get; set; }
        [Column("TaxRecord", TypeName = "int")]
        public int? TaxRecord { get; set; }

        [Column("Fax")]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column("Email")]
        public string Email { get; set; }
        [Column("VendorNo")]
        public int? VendorNo { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }

    }
}
