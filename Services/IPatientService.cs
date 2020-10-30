using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IPatientService
    {
        public int GetMyRecipesCount(string userId);
        public int GetMyAmbulatoryListsCount(string userId);
        public ICollection<Recipe> GetMyRecipes(string userId);
        public ICollection<AmbulatoryList> GetMyAmbulatoryLists(string userId);
    }
}
