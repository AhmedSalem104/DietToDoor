using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapping.Procedures
{
    public class FilterEquipments_Result
    {
       

            public int Id { get; set; }
            public int? CarNo { get; set; }
            public string ChassisNo { get; set; }
            public string PanelNo { get; set; }
            public int? DriverID { get; set; }
            public int? GovernatesId { get; set; }
            public int? ModelNo { get; set; }
            public int? CarTypeId { get; set; }
            public int? ColorId { get; set; }
            public int? Horsepower { get; set; }
            public string CarLicenseNo { get; set; }
            public int? SupplierId { get; set; }
            public int? ConditionId { get; set; }
            public bool? Available { get; set; }
            public bool? IsDeleted { get; set; }
            public decimal? MonthlyFuel { get; set; }
            public int? ReplaceOil { get; set; }
            public int? ReplaceOilLimit { get; set; }
            public int? WarrantyPeriod { get; set; }
            public int? PeriodType { get; set; }
            public int? RegisterTypeId { get; set; }
            public string ReleasePlace { get; set; }
            public string L1 { get; set; }
            public string L2 { get; set; }
            public string L3 { get; set; }
            public int? N1 { get; set; }
            public int? N2 { get; set; }
            public int? N3 { get; set; }
            public int? N4 { get; set; }
            public int? VTypeId { get; set; }
            public int? SeatsNo { get; set; }
            public string InsurNo { get; set; }
            public string InsurCompany { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public DateTime? ReleaseDateH { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTime? EndDateH { get; set; }
            public DateTime? PurchaseDate { get; set; }
            public DateTime? PurchaseDateH { get; set; }
            public DateTime? ServiceDate { get; set; }
            public DateTime? ServiceDateH { get; set; }
            public DateTime? ServiceOutDate { get; set; }
            public DateTime? ServiceOutDateH { get; set; }
            public DateTime? InsurIssueDate { get; set; }
            public DateTime? InsurIssueDateH { get; set; }
            public DateTime? InsurEndDate { get; set; }
            public DateTime? InsurEndDateH { get; set; }
            public DateTime? CheckEndDate { get; set; }
            public DateTime? CheckEndDateH { get; set; }


            public string CarTypeName { get; set; }
            public string ColorName { get; set; }
            public string VendorName { get; set; }
            public string DriverName { get; set; }




    }
}

