using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface  IRecipeService
    {
        public IEnumerable<Recipe> GetUserRecipes(string username);

        public void CreateRecipe(string username, string doctor);
    }
}
