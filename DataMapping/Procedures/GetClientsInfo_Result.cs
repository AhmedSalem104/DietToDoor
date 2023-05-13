using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
   public class GetClientsInfo_Result
    {
        public int ClientId { get; set; }

      
        public string CName { get; set; }


        public string CTel1 { get; set; }

        public string CTel2 { get; set; }

        public string CAddres { get; set; }


        public string CNotes { get; set; }
        public int? CProgramID { get; set; }
        public int? CProgramType { get; set; }

    }
}
