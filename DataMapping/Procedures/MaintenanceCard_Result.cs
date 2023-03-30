using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
   public class MaintenanceCard_Result
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public int? TrxType { get; set; }

        public int? CarId { get; set; }
        public int? CheckTypeId { get; set; }
        public string Reason { get; set; }
        public bool? IsDeleted { get; set; }
        public string ChassisNo { get; set; }
        public string Name { get; set; }
        public string CarTypeName { get; set; }
        public string PanelNo { get; set; }
        public string Notes { get; set; }
        public int? ModelNo { get; set; }
        public int? CarTypeId { get; set; }
        public int? ItemId { get; set; }
        public int? Quantity { get; set; }
        public int? Serial { get; set; }
        public string SparePartName { get; set; }
        public string CheckTypeName { get; set; }

        
        public DateTime? Date { get; set; }

    }
}
