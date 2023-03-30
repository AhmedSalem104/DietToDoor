using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
   public class CarDriverPrint_Result
    {
        public int Id { get; set; }
        public int? TrxType { get; set; }
        public int? Year { get; set; }
        public int? Serial { get; set; }
        public int? Type { get; set; }
        public int? CarId { get; set; }
        public int? DriverID { get; set; }
        public int? DaysCount { get; set; }
        public TimeSpan? Time { get; set; }
        public string SideName { get; set; }
        public string Notes { get; set; }
        public string DayName { get; set; }
        public string TextTime { get; set; }
        public bool DeliverTime { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateH { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ToDateH { get; set; }


        public string DriverName { get; set; }

        public int? BranchId { get; set; }

        public string BranchesName { get; set; }

        public string CarTypeName { get; set; }

        public string ChassisNo { get; set; }

        public int? CarTypeId { get; set; }

        public string PanelNo { get; set; }
        public int? CarNo { get; set; }
        public int? ModelNo { get; set; }

        public string MachineTypeName { get; set; }
        public string NameAr { get; set; }

    }
}
