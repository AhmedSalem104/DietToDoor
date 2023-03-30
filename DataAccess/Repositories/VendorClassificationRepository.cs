using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class VendorClassificationRepository
    {
        public List<VendorClassification> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.VendorClassification.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public VendorClassification GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.VendorClassification.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(VendorClassification item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    item.IsDeleted = false;
                    db.VendorClassification.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(VendorClassification item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.VendorClassification.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.Name = item.Name;
                        q.Notes = item.Notes;
                        q.VendorClaasificationNo = item.VendorClaasificationNo;
                        q.IsDeleted = false;
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
                    var q = db.VendorClassification.FirstOrDefault(m => m.Id == id);
                    if (q != null)
                    {
                        q.IsDeleted = true;
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
