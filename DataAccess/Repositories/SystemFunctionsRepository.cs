using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories
{
   public class SystemFunctionsRepository
    {
        public List<SystemFunction> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SystemFunction.Include(a=>a.SystemFunctionParents).ToList();
            }
        }

        public SystemFunction GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SystemFunction.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(SystemFunction item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    
                    db.SystemFunction.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(SystemFunction item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.SystemFunction.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Action = item.Action;
                        q.Id = item.Id;
                        q.Controller = item.Controller;
                        q.EmployeeSecurityRoles = item.EmployeeSecurityRoles;
                        q.GroupSecurityRoles = item.GroupSecurityRoles;
                        q.NameInArabic = item.NameInArabic;
                        q.NameInEnglish = item.NameInEnglish;
                        q.SystemFunctionParents = item.SystemFunctionParents;
                        q.SystemFunctionParentsId = item.SystemFunctionParentsId;

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
                    var q = db.SystemFunction.FirstOrDefault(m => m.Id == id);
                    if (q != null)
                    {
                        db.SystemFunction.Remove(q);
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
