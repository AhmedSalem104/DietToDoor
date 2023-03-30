using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class SystemFunctionParentRepository
    {
        public List<SystemFunctionParent> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SystemFunctionParent.ToList();
            }
        }

        public SystemFunctionParent GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SystemFunctionParent.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(SystemFunctionParent item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    db.SystemFunctionParent.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(SystemFunctionParent item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.SystemFunctionParent.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.HasParent = item.HasParent;
                        q.Id = item.Id;
                        q.NameInArabic = item.NameInArabic;
                        q.NameInEnglish = item.NameInEnglish;
                        q.SecondLevelInArabic = item.SecondLevelInArabic;
                        q.SecondLevelInEnglish = item.SecondLevelInEnglish;
                        q.MainMenuId = item.MainMenuId;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch(Exception ex)
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
                    var q = db.SystemFunctionParent.FirstOrDefault(m => m.Id == id);
                    if (q != null)
                    {
                        db.SystemFunctionParent.Remove(q);
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
