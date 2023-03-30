using DataMapping.Entites;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class NationalitiesRepository
    {
        public List<Nationalities_Tbl> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Nationalities_Tbl.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public Nationalities_Tbl GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Nationalities_Tbl.FirstOrDefault(m => m.NationalId == id);
            }
        }

        public bool Insert(Nationalities_Tbl item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.IsDeleted = false;
                    db.Nationalities_Tbl.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Nationalities_Tbl item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Nationalities_Tbl.FirstOrDefault(m => m.NationalId == item.NationalId);
                    if (q != null)
                    {
                        q.NationalId = item.NationalId;
                        q.NatCode = item.NatCode;
                        q.NatName = item.NatName;
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
                    var q = db.Nationalities_Tbl.FirstOrDefault(m => m.NationalId == id);
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
