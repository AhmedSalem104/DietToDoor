using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class EmployeeGroupsRepository
    {
        public List<EmployeeGroups> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.EmployeeGroups.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public EmployeeGroups GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.EmployeeGroups.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(EmployeeGroups item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                   
                    item.IsDeleted = false;
                    db.EmployeeGroups.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(EmployeeGroups item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.EmployeeGroups.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.Employee = item.Employee;
                        q.EmployeeId = item.EmployeeId;
                        q.Group = item.Group;
                        q.GroupId = item.GroupId;
                        q.IsDeleted = false;
                        q.UsersId = item.UsersId;
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
                    var q = db.EmployeeGroups.FirstOrDefault(m => m.Id == id);
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
