using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View.Pharmacist;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public Task<IActionResult> CompleteAsync(string recipeId)
        {
            throw new System.NotImplementedException();
        }

        public RecipeDetailsViewModel Find(string recipeId)
        {
            throw new System.NotImplementedException();
        }

        public MyWorkListViewModel GetMyWorkList()
        {

            var userName = this._signInManager.Context.User.Identity.Name;
            var user = this._signInManager.UserManager.FindByNameAsync(userName).Result;

            var recipesList = this._db.Recipes.Where(x => x.Completed == false).ToList();

            var myWorklist = new MyWorkListViewModel
            {
                PharmacistName = user.FirstName + " " + user.FamilyName, 
                WorkplaceName = user.Workplace?.Name, 
                RecipesList = recipesList
            };

            return myWorklist;
        }
    }
}
