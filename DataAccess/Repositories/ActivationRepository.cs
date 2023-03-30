using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ActivationRepository
    {
        public List<ActivationTbl> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ActivationTbl.ToList();
            }
        }

        public ActivationTbl GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ActivationTbl.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(ActivationTbl item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                   
                    db.ActivationTbl.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ActivationTbl item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.ActivationTbl.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.productMac = item.productMac;
                        q.licenceType = item.licenceType;
                        q.LoginCount = item.LoginCount;
                        q.serialKey = item.serialKey;
                       
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

        //public static void Update(Country item)
        //{

        //    using (var db = new ApplicationDbContext())
        //    {

        //        Country Old = db.Country.FirstOrDefault(d => d.Id == item.Id);
        //        if (Old != null)
        //        {
        //            var propInfo = item.GetType().GetProperties();
        //            foreach (var p in propInfo)
        //            {
        //                Old.GetType().GetProperty(p.Name).SetValue(Old, p.GetValue(item, null), null);
        //            }

        //            db.SaveChanges();
        //        }
        //    }

        //}
        public bool Remove(int id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.ActivationTbl.FirstOrDefault(m => m.Id == id);
                    if (q != null)
                    {
                        
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
    }
}
