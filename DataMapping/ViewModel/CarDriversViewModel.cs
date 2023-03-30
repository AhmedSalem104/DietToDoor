using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.ViewModel
{
   public class CarDriversViewModel
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

        [Column("DriverID", TypeName = "int")]
        public int? DriverID { get; set; }

        [Column("DaysCount", TypeName = "int")]
        public int? DaysCount { get; set; }
        [Column("Time", TypeName = "time")]
        public TimeSpan? Time { get; set; }
        [Column("SideName")]
        public string SideName { get; set; }
        [Column("Notes")]
        public string Notes { get; set; }

        [Column("DeliverTime")]
        public bool DeliverTime { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }

        [Column("TextTime")]
        public string TextTime { get; set; }


        [Column("Date", TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Column("DateH", TypeName = "datetime")]
        public DateTime? DateH { get; set; }
        [Column("ToDate", TypeName = "datetime")]
        public DateTime? ToDate { get; set; }

        [Column("ToDateH", TypeName = "datetime")]
        public DateTime? ToDateH { get; set; }
        public List<CarDriversCompanionsList> Items { get; set; }
    }
    public class CarDriversCompanionsList
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("TrxType", TypeName = "int")]
        public int? TrxType { get; set; }


        [Column("Year", TypeName = "int")]
        public int? Year { get; set; }

        [Column("Serial", TypeName = "int")]
        public int? Serial { get; set; }
        [Column("CompanionID", TypeName = "int")]
        public int? CompanionID { get; set; }

        [Column("CarDriversId", TypeName = "int")]
        public int? CarDriversId { get; set; }

    }
}
