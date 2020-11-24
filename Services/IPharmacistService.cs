using eDoc.Models.View.Pharmacist;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IPharmacistService
    {
        public MyWorkListViewModel GetMyWorkList();

        public RecipeDetailsViewModel Find(string recipeId);

        public Task CompleteAsync(string recipeId);
    }
}
