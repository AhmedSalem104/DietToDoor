using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Core.Objects;
//using DataMapping.Procedures;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using DataMapping.Procedures;

namespace DataMapping.Entites
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
   

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        #region Table
        //public virtual DbSet<Accounts> Accounts { get; set; }
        ////public virtual DbSet<test> test { get; set; }
        //public virtual DbSet<Accounts_Types> Accounts_Types { get; set; }
        public virtual DbSet<ActionLog> ActionLog { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        //public virtual DbSet<AssetClassifcation> AssetClassifcation { get; set; }
        //public virtual DbSet<Attachments> Attachments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeGroups> EmployeeGroups { get; set; }
        public virtual DbSet<EmployeeSecurityRoles> EmployeeSecurityRoles { get; set; }
        public virtual DbSet<ActivationTbl> ActivationTbl { get; set; }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupSecurityRole> GroupSecurityRole { get; set; }
        public virtual DbSet<MainMenu> MainMenu { get; set; }
        public virtual DbSet<SystemFunction> SystemFunction { get; set; }
        public virtual DbSet<SystemFunctionParent> SystemFunctionParent { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<Users_Branches> Users_Branches { get; set; }
        public virtual DbSet<Users_Groups> Users_Groups { get; set; }
        //public virtual DbSet<Branches> Branches { get; set; }
        //public virtual DbSet<Currencies> Currencies { get; set; }
        //public virtual DbSet<CurrencyExchangeRates> CurrencyExchangeRates { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        //public virtual DbSet<Stations> Stations { get; set; }
        //public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorClassification> VendorClassification { get; set; }
        //public virtual DbSet<Service_Tbl> Service_Tbl { get; set; }
        ////public virtual DbSet<CarsTypes_Tbl> CarsTypes_Tbl { get; set; }
        //public virtual DbSet<Color_Tbl> Color_Tbl { get; set; }
        //public virtual DbSet<Suppliers_Tbl> Suppliers_Tbl { get; set; }
        //public virtual DbSet<Equipments> Equipments { get; set; }
        //public virtual DbSet<Managments> Managments { get; set; }
        //public virtual DbSet<SpareParts_Tbl> SpareParts_Tbl { get; set; }
        public virtual DbSet<Nationalities_Tbl> Nationalities_Tbl { get; set; }
        //public virtual DbSet<Drivers> Drivers { get; set; }
        //public virtual DbSet<LicenseTypes_Tbl> LicenseTypes { get; set; }
        //public virtual DbSet<StoreTRXTypes> StoreTRXTypes { get; set; }
        //public virtual DbSet<GasolineTypes> GasolineTypes { get; set; }
        //public virtual DbSet<StationsTrx> StationsTrx { get; set; }
        //public virtual DbSet<MachineType> MachineType { get; set; }
        //public virtual DbSet<CarDrivers> CarDrivers { get; set; }
        ////public virtual DbSet<CarDriversCompanions> CarDriversCompanions { get; set; }
        //public virtual DbSet<Days> Days { get; set; }
        //public virtual DbSet<MaintenanceTrx> MaintenanceTrx { get; set; }
        //public virtual DbSet<MaintenanceTrxD> MaintenanceTrxD { get; set; }
        ////public virtual DbSet<CheckTypes> CheckTypes { get; set; }
        //public virtual DbSet<ServicesTrx> ServicesTrx { get; set; }
        //public virtual DbSet<ServicesTrxD> ServicesTrxD { get; set; }
        public virtual DbSet<Years> Years { get; set; }
        public virtual DbSet<InvoicesSettings> InvoicesSettings { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<SignForm> SignForm { get; set; }

        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<MyGoals> MyGoals { get; set; }
        public virtual DbSet<FoodFrequency> FoodFrequency { get; set; }
        public virtual DbSet<TempGoals> TempGoals { get; set; }



        #endregion

        #region Stored Procedure
        //public virtual IEnumerable<Get_Tank_Statment_Result> Get_Tank_Statment()
        //{
        //    return Database.SqlQuery<Get_Tank_Statment_Result>("Get_Tank_Statment").ToList();
        //}
        //public virtual IEnumerable<Get_Car_Receipt_Result> Get_Car_Receipt()
        //{
        //    return Database.SqlQuery<Get_Car_Receipt_Result>("Get_Car_Receipt").ToList();
        //}
        //public virtual IEnumerable<FilterCars_Result> FilterCars()
        //{
        //    return Database.SqlQuery<FilterCars_Result>("FilterCars").ToList();
        //}
        //public virtual IEnumerable<FilterEquipments_Result> FilterEquipments()
        //{
        //    return Database.SqlQuery<FilterEquipments_Result>("FilterEquipments").ToList();
        //}

        //public virtual IEnumerable<FilterExpiredDiversLicenses_Result> FilterExpiredDiversLicenses()
        //{
        //    return Database.SqlQuery<FilterExpiredDiversLicenses_Result>("FilterExpiredDiversLicenses").ToList();
        //}
        //public virtual IEnumerable<FilterUser_Result> FilterUser()
        //{
        //    return Database.SqlQuery<FilterUser_Result>("FilterUser").ToList();
        //} 
        //public virtual IEnumerable<FilterVendors_Result> FilterVendors()
        //{
        //    return Database.SqlQuery<FilterVendors_Result>("FilterVendors").ToList();
        //}
        //public virtual IEnumerable<MaintenanceCard_Result> MaintenanceCard()
        //{
        //    return Database.SqlQuery<MaintenanceCard_Result>("MaintenanceCard").ToList();
        //}
        //public virtual IEnumerable<PrintChangeOli_Result> PrintChangeOli()
        //{
        //    return Database.SqlQuery<PrintChangeOli_Result>("PrintChangeOli").ToList();
        //}
        //public virtual IEnumerable<PrintStationsTrxInAndOut_Result> PrintStationsTrxInAndOut()
        //{
        //    return Database.SqlQuery<PrintStationsTrxInAndOut_Result>("PrintStationsTrxInAndOut").ToList();
        //}


        //public virtual IEnumerable<GetCarsAndEquipments_Result> GetCarsAndEquipments()
        //{
        //    return Database.SqlQuery<GetCarsAndEquipments_Result>("GetCarsAndEquipments").ToList();
        //}

        //public virtual IEnumerable<GetStationsTRXAndTRXOut_Result> GetStationsTRXAndTRXOut()
        //{
        //    return Database.SqlQuery<GetStationsTRXAndTRXOut_Result>("GetStationsTRXAndTRXOut").ToList();
        //}

        //public virtual IEnumerable<CarStatus_Result>CarStatus()
        //{
        //    return Database.SqlQuery<CarStatus_Result>("CarStatus").ToList();
        //}

        //public virtual IEnumerable<GetDrivers_Result> GetDrivers()
        //{
        //    return Database.SqlQuery<GetDrivers_Result>("GetDrivers").ToList();
        //}

        //public virtual IEnumerable<GetCarDriversDetailsInCarDelivery_Result> GetCarDriversDetailsInCarDelivery()
        //{
        //    return Database.SqlQuery<GetCarDriversDetailsInCarDelivery_Result>("GetCarDriversDetailsInCarDelivery").ToList();

        //}

        // public virtual IEnumerable<SelectCars_Result> SelectCars()
        //{
        //    return Database.SqlQuery<SelectCars_Result>("SelectCars").ToList();
        //}
        //public virtual IEnumerable<GetVendorPrint_Result> GetVendorPrint()
        //{
        //    return Database.SqlQuery<GetVendorPrint_Result>("GetVendorPrint").ToList();

        //}
        //public virtual IEnumerable<CarDriverPrint_Result> CarDriverPrint()
        //{
        //    return Database.SqlQuery<CarDriverPrint_Result>("CarDriverPrint").ToList();

        //}

        //public virtual IEnumerable<StationsTrxPrint_Result> StationsTrxPrint()
        //{
        //    return Database.SqlQuery<StationsTrxPrint_Result>("StationsTrxPrint").ToList();

        //}
        //public virtual IEnumerable<StationTrxALLDataIndex_Result> StationTrxALLDataIndex()
        //{
        //    return Database.SqlQuery<StationTrxALLDataIndex_Result>("StationTrxALLDataIndex").ToList();

        //}
        //public virtual IEnumerable<ServicesTrxPrint_Result> ServicesTrxPrint()
        //{
        //    return Database.SqlQuery<ServicesTrxPrint_Result>("ServicesTrxPrint").ToList();
        //}
        //public virtual IEnumerable<CarModelNo_Result> CarModelNo()
        //{
        //    return Database.SqlQuery<CarModelNo_Result>("CarModelNo").ToList();
        //}

        //public virtual IEnumerable<StationTrxDESC_Result> StationTrxDESC()
        //{
        //    return Database.SqlQuery<StationTrxDESC_Result>("StationTrxDESC").ToList();
        //}


        //public virtual IEnumerable<GetAllCarsAndEquipmentsCarStatus_Result>GetAllCarsAndEquipmentsCarStatus()
        //{
        //    return Database.SqlQuery<GetAllCarsAndEquipmentsCarStatus_Result>("GetAllCarsAndEquipmentsCarStatus").ToList();
        //}


        #endregion

    }

}

