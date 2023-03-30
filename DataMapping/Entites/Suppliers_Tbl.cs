using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
   public class Suppliers_Tbl
    {
        [Key]
        [Column("SupplierId", TypeName = "int")]
        public int SupplierId { get; set; }

        [Column("SupplierName")]
        public string SupplierName { get; set; }

        [Column("SupplierCode")]
        public int? SupplierCode { get; set; }

        [Column("Fax")]
        public string Fax { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("Mobile")]
        public string Mobile { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Mobile2")]
        public string Mobile2 { get; set; }



        [Column("VendorId", TypeName = "int")]
        public int? VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
