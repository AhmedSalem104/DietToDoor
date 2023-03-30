using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class VendorRepository
    {
        public List<Vendor> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Vendor.Where(a => a.IsDeleted == false&&a.Block==false).ToList();
            }
        }

        public Vendor GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Vendor.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(Vendor item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    item.IsDeleted = false;
                    db.Vendor.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Vendor item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Vendor.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.SupplierName = item.SupplierName;
                        q.Notes = item.Notes;
                        q.Address = item.Address;
                        q.Block = item.Block;
                        q.Email = item.Email;
                        q.Fax = item.Fax;
                        q.IsVendorAndCustomer = item.IsVendorAndCustomer;
                        q.Mobile = item.Mobile;
                        q.OpenBalnceCridt = item.OpenBalnceCridt;
                        q.OpenBalnceDept = item.OpenBalnceDept;
                        q.Phone = item.Phone;
                        q.RecordNumber = item.RecordNumber;
                        q.TaxRecord = item.TaxRecord;
                        q.VendorClassificationId = item.VendorClassificationId;
                        q.VendorNo = item.VendorNo;
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
                    var q = db.Vendor.FirstOrDefault(m => m.Id == id);
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
