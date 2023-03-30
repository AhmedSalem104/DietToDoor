using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class MainMenuRepository
    {
        public List<MainMenu> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.MainMenu.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public MainMenu GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.MainMenu.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(MainMenu item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    item.IsDeleted = false;
                    db.MainMenu.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(MainMenu item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.MainMenu.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.NameAr = item.NameAr;
                        q.NameEn = item.NameEn;
                        q.Icons = item.Icons;
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
                    var q = db.MainMenu.FirstOrDefault(m => m.Id == id);
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
