using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
   public class StationTrxALLDataIndex_Result
    {
        public int Id { get; set; }
        public int? StationsTrxId_Old { get; set; }
        public int? TrxType { get; set; }
        public int? Year { get; set; }
        public int? Serial { get; set; }
        public int? StationType { get; set; }
        public int? StationId { get; set; }
        public int? CarType { get; set; }
        public int? CarId { get; set; }
        public int? VendorId { get; set; }
        public int? CarKiloMeter { get; set; }
        public decimal? RequestedQuantity { get; set; }
        public decimal? ActualQuantity { get; set; }
        public bool? FuelReceived { get; set; }
        public string AssignmentNo { get; set; }
        public bool? IsDeleted { get; set; }
        public int? InvoiceNo { get; set; }
        public int? Month { get; set; }
        public int? GasolineTypeId { get; set; }
        public int? Week { get; set; }
        public int? EQUType { get; set; }
        public decimal? Value { get; set; }
        public bool? IsPrinted { get; set; }
        public bool? DblQuantity { get; set; }
        public string DblQuantityNo { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateH { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? AssignmentDateH { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? InvoiceDateH { get; set; }


        public string StationName { get; set; }
        public int? DriverID { get; set; }
        public int? CarNo { get; set; }
        public string DriverName { get; set; }
    }
}
