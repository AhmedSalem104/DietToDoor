using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataMapping.Entites
{
    [Table("StationsTrx", Schema = "GL")]
    public  class StationsTrx
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("StationsTrxId_Old", TypeName = "int")]
        public int? StationsTrxId_Old { get; set; }


        [Column("TrxType", TypeName = "int")]
        public int? TrxType { get; set; }

        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }


        [Column("Serial")]
        public int? Serial { get; set; }

        [Column("StationType", TypeName = "int")]
        public int? StationType { get; set; }

        [Column("StationId", TypeName = "int")]
        public int? StationId { get; set; }

        [Column("CarType", TypeName = "int")]
        public int? CarType { get; set; }

        [Column("CarId", TypeName = "int")]
        public int? CarId { get; set; }

        [Column("VendorId", TypeName = "int")]
        public int? VendorId { get; set; }

        [Column("DriverID", TypeName = "int")]
        public int? DriverID { get; set; }
        
        [Column("CarKiloMeter")]
        public int? CarKiloMeter { get; set; }
        [Column("RequestedQuantity")]
        public decimal? RequestedQuantity { get; set; }
        [Column("ActualQuantity")]
        public decimal? ActualQuantity { get; set; }
        [Column("FuelReceived")]
        public bool? FuelReceived { get; set; }

        [Column("AssignmentNo")]
        public string AssignmentNo { get; set; }

       
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
      

        [Column("InvoiceNo")]
        public int? InvoiceNo { get; set; }
        [Column("Month")]
        public int? Month { get; set; }
        [Column("GasolineTypeId", TypeName = "int")]
        public int? GasolineTypeId { get; set; }

        [Column("Week", TypeName = "int")]
        public int? Week { get; set; }
        [Column("EQUType", TypeName = "int")]
        public int? EQUType { get; set; }
        
        [Column("Value")]
        public decimal? Value { get; set; }
        [Column("IsPrinted")]
        public bool? IsPrinted { get; set; }
      

        [Column("DblQuantity")]
        public bool? DblQuantity { get; set; }
        [Column("DblQuantityNo")]
        public string DblQuantityNo { get; set; }
      
        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Column("DateH", TypeName = "datetime")]
        public DateTime? DateH { get; set; }
        [Column("AssignmentDate", TypeName = "datetime")]
        public DateTime? AssignmentDate { get; set; }

        [Column("AssignmentDateH", TypeName = "datetime")]
        public DateTime? AssignmentDateH { get; set; }
        [Column("InvoiceDate", TypeName = "datetime")]
        public DateTime? InvoiceDate { get; set; }

        [Column("InvoiceDateH", TypeName = "datetime")]
        public DateTime? InvoiceDateH { get; set; }

   
    }
}
