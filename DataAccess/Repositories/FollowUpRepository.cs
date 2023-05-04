using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories
{
   public class FollowUpRepository
    {
        public List<FollowUp> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.FollowUp.ToList();
            }
        }

        public FollowUp GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.FollowUp.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(FollowUp item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.Date = DateTime.Now;
                    db.FollowUp.Add(item);
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
