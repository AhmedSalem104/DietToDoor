using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories
{
   public class UsersRepository
    {
        public List<Users> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users.Include(a=>a.Employee).Where(a => a.IsDeleted== false).ToList();
            }
        }

        public Users GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(Users item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.IsDeleted = false;
                    db.Users.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Users item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Users.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.Date = item.Date;
                        q.Code = item.Code;
                        q.IsActive = item.IsActive;
                        q.AppLanguage = item.AppLanguage;
                        q.ArbDescription = item.ArbDescription;
                        q.EmployeeId = item.EmployeeId;
                        q.EngDescription = item.EngDescription;
                        q.Image = item.Image;
                        q.Password = item.Password;
                        q.IsDeleted = false;
                        q.ToDate = item.ToDate;
                        q.LastLoginDate = item.LastLoginDate;
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
                    var q = db.Users.FirstOrDefault(m => m.Id == id);
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
