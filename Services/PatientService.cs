using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public PatientService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public ICollection<AmbulatoryList> GetMyAmbulatoryLists(string userId)
        {

            var userLists = db.AmbulatoryLists.Where(x => x.Patient.Id == userId).ToList();

            return userLists;
        }

        public int GetMyAmbulatoryListsCount(string userId)
        {
            var userLists = db.AmbulatoryLists.Where(x => x.Patient.Id == userId).ToList();

            return userLists.Count();
        }

        public ICollection<RecipeListViewModel> GetMyRecipes(string userId)
        {
            var recipesList = db.Recipes.Select(x => new RecipeListViewModel
            {
                Number = x.Id,
                PatientId = x.Patient.Id,
                DoctorFullName = x.Doctor.FullName,
                PatientFullName = x.Patient.FullName,
                IssueDate = x.CreatedOn,
                RecipeDescription = x.Description,
                Completed = x.Completed ? "Да" : "Не",
                AllowMultiCompletion = x.AllowMultiCompletion ? "Да" : "Не"
            })
                .Where(y => y.PatientId == userId).ToList();

            return recipesList;
        }

        public RecipeDetailsViewModel GetRecipeDetails(string id)
        {
            var recipe = db.Recipes.Where(x => x.Id == id).FirstOrDefault();

            var doctor = db.Users.Where(d => d.Id == recipe.DoctorId).First();

            var patient = db.Users.Where(p => p.Id == recipe.PatientId).First();

            var recipeViewDetails = new RecipeDetailsViewModel
            {
                Id = recipe.Id,

                DoctorFirstName = doctor.FirstName,
                DoctorFamilyName = doctor.FamilyName,
                DoctorUIN = doctor.UIN,

                PatientFirstName = patient.FirstName,
                PatientFamilyName = patient.FamilyName,
                PatientPIN = patient.PIN,

                RecipeDescription = recipe.Description,
                RecipeCreationDate = recipe.CreatedOn,
                RecipeCompleted = recipe.Completed ? "Да" : "Не",
                AllowMultiCompletion = recipe.AllowMultiCompletion ? "Да" : "Не"
            };

            return recipeViewDetails;
        }

        public ApplicationUser GetMyDoctor(string userId)
        {
            var myDoctorId = db.Users.Find(userId).MyDoctorId;

            var doctor = db.Users.Where(x => x.Id == myDoctorId).FirstOrDefault();

            return doctor;
        }

        public int GetMyRecipesCount(string userId)
        {
            var userLists = db.Recipes.Where(x => x.Patient.Id == userId).ToList();

            return userLists.Count();
        }

        public List<DoctorsListViewModel> GetDoctorsListsAsync()
        {
            var doctorsList = userManager.GetUsersInRoleAsync("eDoctor").GetAwaiter().GetResult();

            List<DoctorsListViewModel> doctorsListViewModel = new List<DoctorsListViewModel>();

            foreach (var doctor in doctorsList)
            {

                var doctorModel = new DoctorsListViewModel()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    ContactEmail = doctor.Email,
                    Specialty = doctor.SpecialtyCode,
                };

                doctorsListViewModel.Add(doctorModel);
            }
            return doctorsListViewModel;
        }
    }
}
