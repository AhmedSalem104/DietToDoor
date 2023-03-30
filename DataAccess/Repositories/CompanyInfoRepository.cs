using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class CompanyInfoRepository
    {
        public List<CompanyInfo> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.CompanyInfo.ToList();
            }
        }

        public CompanyInfo GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.CompanyInfo.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(CompanyInfo item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                   
                    db.CompanyInfo.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(CompanyInfo item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.CompanyInfo.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {

                        q.Id = item.Id;
                        q.Email = item.Email;
                        q.CompanyAddress = item.CompanyAddress;
                        q.CountryId = item.CountryId;
                        q.GovernatesId = item.GovernatesId;
                        q.MaintananceManager = item.MaintananceManager;
                        q.CompanyManager = item.CompanyManager;
                        q.MovementManager = item.MovementManager;
                        q.Employee1 = item.Employee1;
                        q.Employee2 = item.Employee2;
                        q.Mobile = item.Mobile;
                        q.CityId = item.CityId;
                        q.CurrenciesId = item.CurrenciesId;
                        q.Phone = item.Phone;
                        q.Email = item.Email;
                        q.PostalCode = item.PostalCode;
                        q.Phone = item.Phone;
                        q.TaxNumber = item.TaxNumber;
                        q.Image = item.Image;
                        //q.YearId - item.YearId;
                        q.FiscalYearStartDate = item.FiscalYearStartDate;
                        q.FiscalYearEndDate = item.FiscalYearEndDate;
                       
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public bool Remove(int id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    //var q = db.Customers.FirstOrDefault(m => m.Id == id);
                    //if (q != null)
                    //{
                    //    q.IsDeleted = true;
                    //    db.SaveChanges();
                    //}
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
