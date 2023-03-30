using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Entites
{
    [Table("Stations", Schema = "GL")]
    public class Stations
    {
        [Key]
        [Column("StationId", TypeName = "int")]
        public int Id { get; set; }

        [Column("StationId_Old", TypeName = "int")]
        public int StationId_Old { get; set; }

        [Column("StationCode", TypeName = "int")]
        public int StationCode { get; set; }
        [Column("StaionType", TypeName = "int")]
        public int StaionType { get; set; }

        [Column("StationName")]
        public string StationName { get; set; }

        [Column("FuelType")]
        public string FuelType { get; set; }

        [Column("TankCapacity")]
        public decimal? TankCapacity { get; set; }

        [Column("MinCapacity")]
        public decimal? MinCapacity { get; set; }

        [Column("MaxCapacity")]
        public decimal? MaxCapacity { get; set; }
        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
