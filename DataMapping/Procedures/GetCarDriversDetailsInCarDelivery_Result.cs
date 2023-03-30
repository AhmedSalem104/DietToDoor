using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
    public class GetCarDriversDetailsInCarDelivery_Result
    {
        public int? CarId { get;set;}
        public int? CompanionID { get; set; }
        public int? DriverNo { get; set; }

        public int Id { get; set; }

        public string Phone { get; set; }

        public string DriverName { get; set; }
        public string BranchesName { get; set; }



    }
}
