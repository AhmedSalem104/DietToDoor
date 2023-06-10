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

        public virtual DbSet<ActionLog> ActionLog { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
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
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<VendorClassification> VendorClassification { get; set; }   
        public virtual DbSet<Nationalities_Tbl> Nationalities_Tbl { get; set; }
        public virtual DbSet<Years> Years { get; set; }
        public virtual DbSet<InvoicesSettings> InvoicesSettings { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<SignForm> SignForm { get; set; }
        public virtual DbSet<Goals> Goals { get; set; }
        public virtual DbSet<MyGoals> MyGoals { get; set; }
        public virtual DbSet<FoodFrequency> FoodFrequency { get; set; }
        public virtual DbSet<TempGoals> TempGoals { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }


        public virtual DbSet<FollowUp> FollowUp { get; set; }
        public virtual DbSet<ServiceOpinion> ServiceOpinion { get; set; }

        public virtual DbSet<AllMealRecipes> AllMealRecipes { get; set; }
        public virtual DbSet<WeeklyMeals> WeeklyMeals { get; set; }

        public virtual DbSet<MealType> MealType { get; set; }
        public virtual DbSet<MenuByDateWebNutrition> MenuByDateWebNutrition { get; set; }



        #endregion

        #region Stored Procedure
        

        public virtual IEnumerable<GetClientsInfo_Result> GetClientsInfo()
        {
            return Database.SqlQuery<GetClientsInfo_Result>("GetClientsInfo").ToList();
        }

        public virtual IEnumerable<GetDaysForMenu_Result> GetDaysForMenu()
        {
            return Database.SqlQuery<GetDaysForMenu_Result>("GetDaysForMenu").ToList();
        }

        
        #endregion

    }

}

