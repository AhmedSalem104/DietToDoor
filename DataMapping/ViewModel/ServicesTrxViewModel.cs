using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataMapping.ViewModel
{
    public class ServicesTrxViewModel
    {

        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("TrxType", TypeName = "int")]
        public int? TrxType { get; set; }

        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }

        [Column("Serial", TypeName = "int")]
        public int? Serial { get; set; }

        [Column("Date", TypeName = "date")]
        public DateTime? Date { get; set; }

        [Column("Type", TypeName = "int")]
        public int? Type { get; set; }

        [Column("CarId", TypeName = "int")]
        public int? CarId { get; set; }

        [Column("DriverId", TypeName = "int")]
        public int? DriverId { get; set; }
        [Column("DepartmentId", TypeName = "int")]
        public int? DepartmentId { get; set; }

        [Column("CurrentReading", TypeName = "int")]
        public int? CurrentReading { get; set; }

        [Column("PreviousReading", TypeName = "int")]
        public int? PreviousReading { get; set; }

        [Column("AlertDate", TypeName = "date")]
        public DateTime? AlertDate { get; set; }

        [Column("AlertDays", TypeName = "int")]
        public int? AlertDays { get; set; }

        [Column("ReplaceOil", TypeName = "int")]
        public int? ReplaceOil { get; set; }

        [Column("SMS_Sent", TypeName = "int")]
        public int? SMS_Sent { get; set; }

        public bool IsDeleted { get; set; }

        public List<ServicesTrxD_List> Items { get; set; }
        }


        public class ServicesTrxD_List
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }


        [Column("TrxType", TypeName = "int")]
        public int? TrxType { get; set; }

        [Column("ServiceTrxId", TypeName = "int")]
        public int ServiceTrxId { get; set; }

        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }

        [Column("Serial", TypeName = "int")]
        public int? Serial { get; set; }

        [Column("ServiceId", TypeName = "int")]
        public int ServiceId { get; set; }

        [Column("Quantity", TypeName = "int")]
        public int Quantity { get; set; }



    }
}

