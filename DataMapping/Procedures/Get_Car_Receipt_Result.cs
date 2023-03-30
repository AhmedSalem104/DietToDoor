using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    public class Get_Car_Receipt_Result
    {
        public int Id { get; set; }
        public int Serial { get; set; }

        
        public int? TrxType { get; set; }
        public string DriverName { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string PanelNo { get; set; }
        public int? ModelNo { get; set; }
        public int? CarNo { get; set; }
        public string CarTypeName { get; set; }
        public bool? DeliverTime { get; set; }
        public string ManageName { get; set; }
        
        public DateTime? Date { get; set; }
       

    }
}
