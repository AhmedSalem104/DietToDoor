using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories
{
   public class SignFormRepository
    {
        public List<SignForm> GetAll()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SignForm.Where(a => a.IsDeleted == false).ToList();
            }
        }

        public SignForm GetById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.SignForm.FirstOrDefault(m => m.Id == id);
            }
        }

        public bool Insert(SignForm item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    item.IsDeleted = false;
                    db.SignForm.Add(item);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(SignForm item)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    var q = db.SignForm.FirstOrDefault(m => m.Id == item.Id);
                    if (q != null)
                    {
                        q.Id = item.Id;
                        q.FullName = item.FullName;
                        q.Mobile = item.Mobile;
                        q.Address = item.Address;
                        q.Phone = item.Phone;
                        q.Type = item.Type;
                        q.Age = item.Age;
                        q.BirthDate = item.BirthDate;
                        q.HowHear = item.HowHear;
                        q.CurrentWeight = item.CurrentWeight;
                        q.IsDeleted = false;
                        q.Height = item.Height;
                        q.waistCircumference = item.waistCircumference;

                        q.fatPercentage = item.fatPercentage;
                        q.muscleMass = item.muscleMass;
                        q.waterPercentage = item.waterPercentage;
                        q.ActivityLevel = item.ActivityLevel;

                        q.AlcoholConsumes = item.AlcoholConsumes;
                        q.Smoker = item.Smoker;
                        q.HealthCondition = item.HealthCondition;
                        q.DoYouHaveAnyFoodAllergy = item.DoYouHaveAnyFoodAllergy;

                        q.BodyShapeImage = item.BodyShapeImage;
                        q.ImportantToKnowAboutMe = item.ImportantToKnowAboutMe;
                        q.fullDayExampleFromWakingUpToSleep = item.fullDayExampleFromWakingUpToSleep;
                        q.WakingUpTime = item.WakingUpTime;
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

        //public static void Update(Country item)
        //{

        //    using (var db = new ApplicationDbContext())
        //    {

        //        Country Old = db.Country.FirstOrDefault(d => d.Id == item.Id);
        //        if (Old != null)
        //        {
        //            var propInfo = item.GetType().GetProperties();
        //            foreach (var p in propInfo)
        //            {
        //                Old.GetType().GetProperty(p.Name).SetValue(Old, p.GetValue(item, null), null);
        //            }

        //            db.SaveChanges();
        //        }
        //    }

        //}
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
