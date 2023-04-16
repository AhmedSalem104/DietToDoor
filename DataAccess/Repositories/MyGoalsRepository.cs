using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace DataAccess.Repositories
{
  public  class MyGoalsRepository
    {
        public List<MyGoals> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.MyGoals.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public MyGoals GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.MyGoals.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(MyGoals item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.IsDeleted = false;
                    db.MyGoals.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool InsertList(List<TempGoals> items)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var record = db.SignForm.Max(a => a.Id);
                    foreach (var e in items)
                    {
                        MyGoals myGoals = new MyGoals();
                        myGoals.GoalId = e.GoalId;
                        myGoals.UserId = record;
                        myGoals.IsDeleted = false;
                        db.MyGoals.Add(myGoals);
                    }
                    var q = db.TempGoals.ToList();
                    if (q.Count()!=0)
                    {
                        foreach (var i in q) {
                            db.Entry(i).State = EntityState.Deleted;
                            db.SaveChanges();
                        }
                       
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch  (Exception ee)
            {
                var e = ee.Message;
                return false;
            }
        }
        public bool Update(MyGoals item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.MyGoals.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.UserId = item.UserId;
                        q.GoalId = item.GoalId;
                      
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
                    var q = db.MyGoals.FirstOrDefault(m => m.Id == id);
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

        public bool InsertTemp(TempGoals item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    //ItemSubUint unit = db.ItemSubUint.FirstOrDefault(a => a.UnitId == item.UnitId && a.IsDeleted == false && a.ItemId==item.ItemId); 



                    //    if (item.ItemId == null || item.ItemId == 0)
                    //    {

                    //        var ItemId = db.Item.Max(a => a.Id);
                    //        item.ItemId = ItemId;

                    //}


                    //if (unit == null)
                    //{
                    //item.ItemId = ItemId;
                    //item.IsDeleted = false;
                    db.TempGoals.Add(item);
                    db.SaveChanges();
                    return true;
                    //}
                    //return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool UpdateTemp(TempGoals item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.TempGoals.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.GoalId = item.GoalId;
                      

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

        public bool RemoveTemp(int id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.TempGoals.FirstOrDefault(m => m.Id == id);
                    if (q != null)
                    {
                        db.Entry(q).State = EntityState.Deleted;
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
