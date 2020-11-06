using eDoc.Data.Models;
using eDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IDoctorService
    {
        public void CreateRecipe(CreateRecipeInputModel input);

        public List<ApplicationUser> GetAllPatients();
    }
}
