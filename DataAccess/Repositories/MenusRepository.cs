using DataMapping.Entites;
using DataMapping.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
   public class MenusRepository
    {
        public List<WeeklyMeals> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.WeeklyMeals.ToList();
            }
        }

        public WeeklyMeals GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.WeeklyMeals.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool InsertBreakFast(WeeklyMealsViewModel obj)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {

                    foreach (var item in obj.Items)
                    {
                        WeeklyMeals tempDetails = new WeeklyMeals()
                        {
                            //Id = (int)temMainId,
                            ClientId = obj.ClientId,
                            MealId = item.MealId,
                            MealType = 1,
                           CreatedDate = obj.CreateDate,
                           Amount = item.Amount,
                           DateDay = obj.CreateDate,


                        };
                        if (tempDetails.Amount < 1)
                        {

                        }
                        else {
                            db.WeeklyMeals.Add(tempDetails);
                            db.SaveChanges();
                        }
                       
                    }
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //public bool Update(WeeklyMealsViewModel obj)
        //{
        //    try
        //    {
        //        using (var db = new ApplicationDbContext())
        //        {
        //            var q = db.WeeklyMeals.FirstOrDefault(m => m.Id == item.Id);
        //            if (q != null)
        //            {
        //                q.Id = item.Id;
        //                q.ClientId = item.ClientId;
        //                q.CreatedDate = item.CreatedDate;
        //                q.MealId = item.MealId;
        //                q.MealType = item.MealType;
        //                db.SaveChanges();
        //            }
        //            return true;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
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
