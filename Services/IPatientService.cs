using eDoc.Data.Models;
using eDoc.Models;
using System.Collections.Generic;

namespace eDoc.Services
{
    public interface IPatientService
    {
        public int GetMyRecipesCount(string userId);
        public int GetMyAmbulatoryListsCount(string userId);
        public ICollection<RecipeListViewModel> GetMyRecipes(string userId);
        public ICollection<AmbulatoryList> GetMyAmbulatoryLists(string userId);
    }
}
