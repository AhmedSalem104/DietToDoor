using DataMapping.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace DataAccess.Repositories
{
   public class FoodFrequencyRepository
    {
        public List<FoodFrequency> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.FoodFrequency.ToList();
            }
        }

        public FoodFrequency GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.FoodFrequency.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(FoodFrequency item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    
                    db.FoodFrequency.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(FoodFrequency item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.FoodFrequency.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.UserId = item.UserId;
                        q.RedMeat = item.RedMeat;

                        q.Chicken = item.Chicken;
                        q.SeaFood = item.SeaFood;
                        q.Fruits = item.Fruits;


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
                    var q = db.MyGoals.Where(m => m.UserId == id).ToList();
                    foreach (var item in q)
                    {
                        db.Entry(item).State = EntityState.Deleted;
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
