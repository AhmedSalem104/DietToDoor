using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories
{
   public class ContactUsRepository
    {
        public List<ContactUs> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ContactUs.ToList();
            }
        }

        public ContactUs GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.ContactUs.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(ContactUs item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.Date = DateTime.Now;
                    db.ContactUs.Add(item);
                    db.SaveChanges();
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
