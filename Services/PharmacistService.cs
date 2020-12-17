using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View.Pharmacist;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public class PharmacistService : IPharmacistService
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PharmacistService(ApplicationDbContext db,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this._db = db;
            this._signInManager = signInManager;
        }
        public async Task CompleteAsync(string recipeId)
        {
            var recipe = this._db.Recipes.Find(recipeId);

            recipe.Completed = true;

            this._db.Update(recipe);
            await this._db.SaveChangesAsync();
        }

        public MyWorkListViewModel GetMyWorkList()
        {

            var userName = this._signInManager.Context.User.Identity.Name;
            var user = this._signInManager.UserManager.FindByNameAsync(userName).Result;

            var recipesList = this._db.Recipes.Where(x => x.Completed == false || x.AllowMultiCompletion == true).ToList();
            var activeRecipes = new List<PharmacistRecipesViewModel>();

            foreach (var recipe in recipesList)
            {
                var recipeData = new PharmacistRecipesViewModel
                {
                    RecipeId = recipe.Id,
                    CreatedOn = recipe.CreatedOn,
                    DoctorFullName = recipe.Doctor.FullName,
                    PatientFullName = recipe.Patient.FullName,
                    Completed = recipe.Completed ? "Да" : "Не",
                    AllowMultiCompletion = recipe.AllowMultiCompletion ? "Да" : "Не"
                };

                activeRecipes.Add(recipeData);
            }

            var myWorklist = new MyWorkListViewModel
            {
                PharmacistName = user.FullName,
                WorkplaceName = string.IsNullOrEmpty(user.Workplace?.Name) ? "Не е зададено" : user.Workplace.Name,
                RecipesList = activeRecipes
            };

            return myWorklist;
        }
    }
}
