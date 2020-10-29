using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IPatientService
    {
        public int GetMyRecipesCount();
        public int GetMyAmbulatoryListsCount();
        public ICollection<Recipe> GetMyRecipes();
        public ICollection<AmbulatoryList> GetMyAmbulatoryLists(string userId);
    }
}
