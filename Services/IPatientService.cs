using eDoc.Data.Models;
using eDoc.Models.View;
using System.Collections.Generic;

namespace eDoc.Services
{
    public interface IPatientService
    {
        public int GetMyRecipesCount(string userId);
        public int GetMyAmbulatoryListsCount(string userId);
        public ICollection<RecipeListViewModel> GetMyRecipes(string userId);
        public RecipeDetailsViewModel GetRecipeDetails(string id);
        public ICollection<AmbulatoryListViewModel> GetMyAmbulatoryLists(string userId);
        public ICollection<SickLeaveListViewModel> GetMySickLeaveLists(string userId);
        public MyDoctorViewModel GetMyDoctor(string userId);
        public List<DoctorsListViewModel> GetDoctorsLists();
        public void AssignDoctor(string patientId, string doctorId);
    }
}
