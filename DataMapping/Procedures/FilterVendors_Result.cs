using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
    public class FilterVendors_Result
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int? VendorClassificationId { get; set; }
        public bool? IsVendorAndCustomer { get; set; }
        public bool? Block { get; set; }
        public int? OpenBalnceDept { get; set; }
        public int? OpenBalnceCridt { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public int? RecordNumber { get; set; }
        public int? TaxRecord { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? VendorNo { get; set; }
        public bool? IsDeleted { get; set; }

        public string VendorClassificationName { get; set; }



        }
    }

