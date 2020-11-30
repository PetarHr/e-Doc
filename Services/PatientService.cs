using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace eDoc.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public PatientService(ApplicationDbContext db, 
                              UserManager<ApplicationUser> userManager, 
                              SignInManager<ApplicationUser> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this._signInManager = signInManager;
        }
        public ICollection<AmbulatoryListViewModel> GetMyAmbulatoryLists(string userId)
        {

            var userLists = db.AmbulatoryLists.Where(x => x.Patient.Id == userId)
                .Select(x => new AmbulatoryListViewModel
                {
                    Id = x.Id,
                    PatientFullName = x.Patient.FullName, 
                    DoctorFullName = x.Doctor.FullName, 
                    IssueDate = x.IssuedOn, 
                    CheckUpType = x.CheckUpType, 
                    Diagnosis = x.Diagnosis,
                    Diseases = x.Diseases, 
                    Therapy = x.Therapy

                })
                .ToList();

            return userLists;
        }

        public ICollection<SickLeaveListViewModel> GetMySickLeaveLists(string userId)
        {

            var sickLeaves = db.SickLeaveLists.Where(x => x.Patient.Id == userId)
                .Select(x => new SickLeaveListViewModel
                { 
                    Id = x.Id, 
                    DoctorFullName = x.Doctor.FullName, 
                    PatientFullName = x.Patient.FullName, 
                    IssueDate = x.DateOfIssue, 
                    StartDate = x.StartDate, 
                    EndDate = x.EndDate, 
                    Employer = x.Patient.Workplace.Name
                })
                .ToList();

            return sickLeaves;
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

            var recipeViewDetails = new RecipeDetailsViewModel
            {
                RecipeId = recipe.Id,

                DoctorFullName = recipe.Doctor.FullName,
                DoctorUIN = recipe.Doctor.UIN,
                
                MedCenterName = recipe.Doctor.MedicalCenter?.Name,
                MedCenterAddress = recipe.Doctor.MedicalCenter?.Address?.Street,

                PatientFullName = recipe.Patient.FullName,
                PatientPIN = recipe.Patient.PIN,

                RecipeDescription = recipe.Description,
                RecipeCreationDate = recipe.CreatedOn,
                RecipeCompleted = recipe.Completed ? "Да" : "Не",
                AllowMultiCompletion = recipe.AllowMultiCompletion ? "Да" : "Не"
            };

            return recipeViewDetails;
        }

        public MyDoctorViewModel GetMyDoctor()
        {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = this._signInManager
                            .UserManager
                            .FindByNameAsync(userName)
                            .GetAwaiter()
                            .GetResult();

            var doctor = db.Users.Where(x => x.Id == user.MyDoctorId).FirstOrDefault();

            if (doctor == null)
            {
                return null;
            }

            var myDoctorView = new MyDoctorViewModel
            {
                DoctorId = doctor.Id, 
                DoctorFullName = doctor.FullName, 
                DoctorSpecialty = doctor.Occupation, 
                DoctorProfilePicture = "https://bootdey.com/img/Content/avatar/avatar7.png", 
                DoctorMedicalCenterName = doctor.MedicalCenter?.Name, 
                DoctorMedicalCenterAddress = doctor.MedicalCenter?.Address.Street + " № "
                                                + doctor.MedicalCenter?.Address.StreetNumber + ", "
                                                + doctor.MedicalCenter?.Address.City + ", "
                                                + doctor.MedicalCenter?.Address.Country
            };

            return myDoctorView;
        }

        public List<DoctorsListViewModel> GetDoctorsLists()
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

        public void AssignDoctor(string doctorId)
        {
            var userName = this._signInManager.Context.User.Identity.Name;
            var user = this._signInManager
                            .UserManager
                            .FindByNameAsync(userName)
                            .GetAwaiter()
                            .GetResult();

            user.MyDoctorId = doctorId;

            this.db.Update(user);
            this.db.SaveChanges();
        }
    }
}
