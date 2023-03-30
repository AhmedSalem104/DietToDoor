using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserBrancheRepository
    {

        public List<Users_Branches> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Users_Branches.ToList();
            }
        }
        public bool Insert(Users_Branches item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    //var Users = db.UserSafe.Where(a=>a.UsersId == item.UsersId).ToList();
                    //if (Users.Count() ==0) {
                    //    item.IsDefault = true;
                    //}
                    //else
                    //{
                    //    item.IsDefault = false;
                    //}
                    
                    db.Users_Branches.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Users_Branches item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Users_Branches.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {


                        q.UsersId = item.UsersId;
                       
                        q.BranchId = item.BranchId;
                        q.IsDefault = item.IsDefault;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdateIsDefault(Users_Branches item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Users_Branches.FirstOrDefault(m => m.IsDefault == true && m.UsersId == item.UsersId && m.IsDeleted == false);
                    if (q != null)
                    {


                        q.IsDefault = false;
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.Users_Branches.FirstOrDefault(m => m.Id == id);
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
