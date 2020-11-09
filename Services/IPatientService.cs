using eDoc.Data.Models;
using eDoc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IPatientService
    {
        public int GetMyRecipesCount(string userId);
        public int GetMyAmbulatoryListsCount(string userId);
        public ICollection<RecipeListViewModel> GetMyRecipes(string userId);
        public RecipeDetailsViewModel GetRecipeDetails(string id);
        public ICollection<AmbulatoryList> GetMyAmbulatoryLists(string userId);
        public ApplicationUser GetMyDoctor(string userId);
        public List<DoctorsListViewModel> GetDoctorsListsAsync();
    }
}
