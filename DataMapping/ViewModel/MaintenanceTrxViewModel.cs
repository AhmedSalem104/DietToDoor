using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.ViewModel
{
    public class MaintenanceTrxViewModel
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("TrxType", TypeName = "int")]
        public int? TrxType { get; set; }

        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }


        [Column("Serial", TypeName = "int")]
        public int? Serial { get; set; }

        [Column("Type", TypeName = "int")]
        public int? Type { get; set; }

        [Column("CarId", TypeName = "int")]
        public int? CarId { get; set; }

        [Column("CheckTypeId", TypeName = "int")]
        public int? CheckTypeId { get; set; }

        [Column("CheckResult")]
        public string CheckResult { get; set; }
        [Column("Reason")]
        public string Reason { get; set; }
        [Column("OrderYear")]
        public int? OrderYear { get; set; }
        [Column("OrderSerial")]
        public int? OrderSerial { get; set; }
        [Column("DeliveredFrom")]
        public string DeliveredFrom { get; set; }

        [Column("AssignmentNo")]
        public string AssignmentNo { get; set; }
        [Column("DeliveredTo")]
        public string DeliveredTo { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }
        [Column("InvoiceNo")]
        public string InvoiceNo { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }


        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Column("DateH", TypeName = "datetime")]
        public DateTime? DateH { get; set; }
        [Column("ExpectedDate", TypeName = "datetime")]
        public DateTime? ExpectedDate { get; set; }

        [Column("ExpectedDateH", TypeName = "datetime")]
        public DateTime? ExpectedDateH { get; set; }

        [Column("OrderDate", TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        [Column("OrderDateH", TypeName = "datetime")]
        public DateTime? OrderDateH { get; set; }
        public List<MaintenanceTrxList> Items { get; set; }

    }
    public class MaintenanceTrxList
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("TrxType")]
        public int? TrxType { get; set; }

        [Column("Year")]
        public int? Year { get; set; }

        [Column("Serial")]
        public int? Serial { get; set; }

        [Column("LineNo")]
        public int? LineNo { get; set; }
        [Column("ItemId")]
        public int? ItemId { get; set; }

        [Column("Quantity")]
        public int? Quantity { get; set; }

    }
}
