using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
   public class FilterExpiredDiversLicenses_Result
    {
        public int Id { get; set; }
        public int? DriverNo { get; set; }
        public string DriverName { get; set; }
        public int? NatId { get; set; }
        public int? BranchId { get; set; }
        public int? LicenseTypeId { get; set; }
        public string Phone { get; set; }
        public string LicenseNo { get; set; }
        public string LicensePlace { get; set; }
        public string Notes { get; set; }
        public string MobileCode { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LicenseReleaseDate { get; set; }
        public DateTime? LicenseReleaseDateH { get; set; }
        public DateTime? LicenseEndDate { get; set; }
        public DateTime? LicenseEndDateH { get; set; }

        public string ManagmentName { get; set; }
        public string LicenseTypeName { get; set; }
        public string NationalName { get; set; }


    }
}
