using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
  public  class SelectCars_Result
    {

        public int? CarId { get; set; }
        public int CarType { get; set; }

        public  string SelectCar { get; set; }
        public bool IsDeleted { get; set; }

    }
}
