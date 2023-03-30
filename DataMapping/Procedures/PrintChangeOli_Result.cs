using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
    public class PrintChangeOli_Result
    {


        public int TrxType { get; set; }
        public int Year { get; set; }
        public int Serial { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public int CarId { get; set; }
        public int CurrentReading { get; set; }
        public int PreviousReading { get; set; }
        public DateTime AlertDate { get; set; }
        public int AlertDays { get; set; }
        public int ReplaceOil { get; set; }
        public int SMS_Sent { get; set; }

        public int ServicesTrxDTrxType { get; set; }
        public int ServicesTrxDYear { get; set; }
        public int ServicesTrxDSerial { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }

        public string ServiceName { get; set; }

        public string Name { get; set; }

        public string PanelNo { get; set; }
        public int CarTypeId { get; set; }

        public string CarTypeName { get; set; }


       







    }
}

