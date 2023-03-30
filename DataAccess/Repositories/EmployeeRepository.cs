using DataMapping.Entites;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Employee.Where(a=>a.IsDeleted==false).ToList();
            }
        }

        public Employee GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Employee.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(Employee item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.IsDeleted = false;
                    db.Employee.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Employee item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Employee.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.CreatedBy = item.CreatedBy;
                        q.CreatedDate = item.CreatedDate;
                        q.UpdatedBy = item.UpdatedBy;
                        q.UpdatedDate = item.UpdatedDate;
                   
                        q.OrganizationId = item.OrganizationId;
                        q.BranchId = item.BranchId;
                     
                        q.EmpCode = item.EmpCode;
                        q.EmployeeNameAr = item.EmployeeNameAr;
                        q.EmpNo = item.EmpNo;
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
                    var q = db.Employee.FirstOrDefault(m => m.Id == id);
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
