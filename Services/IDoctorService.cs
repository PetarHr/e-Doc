using eDoc.Data.Models;
using eDoc.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IDoctorService
    {
        public void CreateRecipe(CreateRecipeInputModel input);
        public void CreateAmbulatoryList(AmbulatoryListInputModel input);
        public void CreateSickLeaveList(SickLeaveListInputModel input);
        public List<ApplicationUser> GetAllPatients();
        public List<ApplicationUser> GetDoctorPatients(string doctorId);
    }
}
