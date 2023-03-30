using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class InvoicesSettingsRepository
    {
        public List<InvoicesSettings> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.InvoicesSettings.ToList();
            }
        }

        public InvoicesSettings GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.InvoicesSettings.FirstOrDefault(m => m.InvoicesSettingId == id);
            }
        }

        public bool Insert(InvoicesSettings item)
        {


            try
            {
                using (var db = new ApplicationDbContext())
                {
                   
                    db.InvoicesSettings.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(InvoicesSettings item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.InvoicesSettings.FirstOrDefault(m => m.InvoicesSettingId == item.InvoicesSettingId);
                    if (q != null)
                    {

                        q.InvoicesSettingId = item.InvoicesSettingId;
                        q.YearId = item.YearId;
                        q.Conditions = item.Conditions;
                        q.Notes = item.Notes;
                       
                       
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
