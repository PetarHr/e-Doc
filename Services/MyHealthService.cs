using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View.MyHealth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public class MyHealthService : IMyHealthService
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public MyHealthService(ApplicationDbContext db, SignInManager<ApplicationUser> signInManager)
        {
            this._db = db;
            this._signInManager = signInManager;
        }

        public async Task AddAllergy(Allergy input)
        {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = await this._signInManager.UserManager.FindByNameAsync(userName);

            var userAllergy = new Allergy
            {
                User = user, 
                CreatedOn = DateTime.UtcNow,
                Description = input.Description, 
                DiscoveredOn = input.DiscoveredOn
            };

            await this._db.MyAllergies.AddAsync(userAllergy);
            await this._db.SaveChangesAsync();
        }

        public MyHealthHistoryViewModel GetMyHistory()
        {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = this._signInManager
                            .UserManager
                            .FindByNameAsync(userName)
                            .GetAwaiter()
                            .GetResult();

            var userWeightList = this._db.MyWeight.Where(w => w.UserId == user.Id).OrderByDescending(wd => wd.RecordDate).ToList<MyWeight>();
            var userBloodPressureList = this._db.MyBloodPressure.Where(b => b.UserId == user.Id).OrderByDescending(bd => bd.RecordDate).ToList<MyBloodPressure>();
            var userAllergiesList = this._db.MyAllergies.Where(a => a.UserId == user.Id).OrderByDescending(ad => ad.CreatedOn).ToList<Allergy>();

            var myHistory = new MyHealthHistoryViewModel
            {
                UserFullName = user.FullName,
                MyWeightList = userWeightList,
                MyBloodPressureList = userBloodPressureList,
                MyAllergiesList = userAllergiesList
            };

            return myHistory;
        }


        public MyHealthDetailsViewModel GetMyHealthStats()
         {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = this._signInManager
                            .UserManager
                            .FindByNameAsync(userName)
                            .GetAwaiter()
                            .GetResult();

            var userAge = CalculateAge(user.BirthDate);

            var userBloodPressure = this._db.MyBloodPressure.Where(m => m.UserId == user.Id).OrderByDescending(p => p.RecordDate).FirstOrDefault();
            var userWeight = this._db.MyWeight.Where(w => w.UserId == user.Id).OrderByDescending(p => p.RecordDate).FirstOrDefault();

            var userHealthDetails = new MyHealthDetailsViewModel
            {
                Age = userAge,
                AllergiesList = user.MyAllergies,
                MyBloodPressure = userBloodPressure,
                MyWeight = userWeight,
                UserFullName = user.FullName
            };
            return userHealthDetails;
        }

        private static int CalculateAge(DateTime userBirthDate)
        {
            //Get the user's age.
            var userAge = (DateTime.Today.Year - userBirthDate.Year);

            //Revert -1 year if date of birth of the user is still not reached for current year.
            if (userBirthDate.Date > DateTime.Today.AddYears(-userAge)) userAge--;

            return userAge;
        }

        public async Task UpdateBloodPressure(MyBloodPressure input)
        {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = await this._signInManager.UserManager.FindByNameAsync(userName);

            var userBloodPressure = new MyBloodPressure
            {
                RecordDate= DateTime.UtcNow,
                Systolic = input.Systolic, 
                Diastolic = input.Diastolic
            };

            user.MyBloodPressure.Add(userBloodPressure);

            this._db.Update(user);
            await this._db.SaveChangesAsync();
        }

        public async Task UpdateWeight(MyWeight input)
        {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = await this._signInManager.UserManager.FindByNameAsync(userName);

            var userWeight = new MyWeight
            {
                RecordDate = DateTime.UtcNow,
                Value = input.Value
            };

            user.MyWeight.Add(userWeight);

            this._db.Update(user);
            await this._db.SaveChangesAsync();
        }

    }
}
