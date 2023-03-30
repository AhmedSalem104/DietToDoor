using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class GroupRepository
    {
        public List<Group> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Group.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public Group GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Group.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(Group item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    item.IsDeleted = false;
                    db.Group.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Group item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Group.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.NameInArabic = item.NameInArabic;
                        q.NameInEnglish = item.NameInEnglish;
                        q.GroupNo = item.GroupNo;
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
                    var q = db.Group.FirstOrDefault(m => m.Id == id);
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
