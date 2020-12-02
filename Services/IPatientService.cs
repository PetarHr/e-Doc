using eDoc.Models.View;
using eDoc.Models.View.Patient;
using System.Collections.Generic;

namespace eDoc.Services
{
    public interface IPatientService
    {
        public ICollection<RecipeListViewModel> GetMyRecipes(string userId);
        public RecipeDetailsViewModel GetRecipeDetails(string id);
        public ICollection<AmbulatoryListViewModel> GetMyAmbulatoryLists(string userId);
        public ICollection<SickLeaveListViewModel> GetMySickLeaveLists(string userId);
        public MyDoctorViewModel GetMyDoctor();
        public List<DoctorsListViewModel> GetDoctorsLists();
        public PatientDetailsViewModel GetPatientDetails(string userId);
        public void AssignDoctor(string doctorId);
    }
}
