using eDoc.Data.Models;
using eDoc.Models.Input;
using eDoc.Models.View.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    
    public interface IDoctorService
    {
        public CreateRecipeInputModel PrepareRecipeInputModel();
        public void CreateRecipe(CreateRecipeInputModel input);
        public AmbulatoryListInputModel PrepareAmbListInputModel();
        public void CreateAmbulatoryList(AmbulatoryListInputModel input);
        public SickLeaveListInputModel PrepareSickLeaveInputModel();
        public void CreateSickLeaveList(SickLeaveListInputModel input);
        public ICollection<ApplicationUser> GetAllPatients();
        public ICollection<ApplicationUser> GetDoctorPatients(string doctorId);
        public List<RecipesIssuedByMeViewModel> GetRecipesIssueByMe();
        public ICollection<AmbulatoryList> GetAmbulatoryListsIssueByMe();
        public ICollection<SickLeaveList> GetSickLeavesIssueByMe();
    }
}
