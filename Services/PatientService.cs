using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.View;
using eDoc.Models.View.Patient;
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
                    IssueDate = x.CreatedOn,
                    CheckUpType = x.TypeOfCheckup.ToString(),
                    Diagnosis = x.Diagnosis,
                    Diseases = x.AccompanyingConditions,
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

                MedCenterName = string.IsNullOrEmpty(recipe.Doctor.Workplace?.Name) ? "Не е посочен център" : recipe.Doctor.Workplace.Name,
                MedCenterAddress = string.IsNullOrEmpty(recipe.Doctor.Workplace?.Address?.Street) ? "Не е посочен адрес" :
                                                "ул. " + recipe.Doctor.Workplace.Address.Street + " № "
                                                + recipe.Doctor.Workplace.Address.StreetNumber + ", гр. "
                                                + recipe.Doctor.Workplace.Address.City + ", "
                                                + recipe.Doctor.Workplace.Address.Country.Name,

                PatientFullName = recipe.Patient.FullName,
                PatientAddress = string.IsNullOrEmpty(recipe.Patient.Address?.Street) ? "Не е посочен адрес" :
                                                "ул. " + recipe.Patient.Address.Street + " № "
                                                + recipe.Patient.Address.StreetNumber + ", гр. "
                                                + recipe.Patient.Address.City + ", "
                                                + recipe.Patient.Address.Country.Name,
                PatientPIN = CleanPIN(recipe.Patient.PIN),

                RecipeDescription = recipe.Description,
                RecipeCreationDate = recipe.CreatedOn,
                RecipeCompleted = recipe.Completed ? "Да" : "Не",
                AllowMultiCompletion = recipe.AllowMultiCompletion ? "Да" : "Не"
            };

            return recipeViewDetails;
        }

        public MyDoctorViewModel GetMyDoctor()
        {
            var userName = this._signInManager
                               .Context.User
                               .Identity
                               .Name;
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
                DoctorMedicalCenterName = doctor.Workplace.Name,
                DoctorMedicalCenterAddress = "ул. " + doctor.Workplace.Address.Street + " № "
                                                + doctor.Workplace.Address.StreetNumber + ", гр. "
                                                + doctor.Workplace.Address.City + ", "
                                                + doctor.Workplace.Address.Country.Name
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
                    MedicalCenter = doctor.Workplace.Name,
                    WorkplaceAddress = string.IsNullOrEmpty(doctor.Workplace.Name) ?
                                                "Не е зададен адрес" :
                                                "ул. " + doctor.Workplace.Address.Street + " № "
                                                + doctor.Workplace.Address.StreetNumber + ", гр. "
                                                + doctor.Workplace.Address.City + ", "
                                                + doctor.Workplace.Address.Country.Name,
                    ContactEmail = doctor.Email,
                    ContactPhone = string.IsNullOrEmpty(doctor.PhoneNumber) ? "Не е посочен телефон" : doctor.PhoneNumber,
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

            if (doctorId == user.Id)
            {
                return;
            }

            user.MyDoctorId = doctorId;

            this.db.Update(user);
            this.db.SaveChanges();
        }

        public PatientDetailsViewModel GetPatientDetails(string userId)
        {
            var patient = this.db.Users.Find(userId);
            var аddressDetails = "Няма въведен адрес";

            if (patient != null)
            {
                if (patient.Address != null)
                {
                    аddressDetails = string.Concat("ул. ", patient.Address?.Street, ", ",
                                                "№ ", patient.Address?.StreetNumber, ", ",
                                                "Вход: ", patient.Address?.Entrance, ", ",
                                                "Етаж: ", patient.Address?.Floor, ", ",
                                                "Апартамент: ", patient.Address?.Apartment, ", ",
                                                "Град: ", patient.Address?.City, ", ",
                                                "Държава: ", patient.Address?.Country.Name, ".");
                };

                var patienDetails = new PatientDetailsViewModel
                {
                    BirthDate = patient.BirthDate,
                    PIN = CleanPIN(patient.PIN),
                    FullAddress = аddressDetails,
                    CountryCode = patient.Address?.Country?.Code
                };

                return patienDetails;
            }
            return null;
        }
        public void RemoveMyDoctor()
        {
            var userName = this._signInManager
                                 .Context.User
                                 .Identity
                                 .Name;
            var user = this._signInManager
                            .UserManager
                            .FindByNameAsync(userName)
                            .GetAwaiter()
                            .GetResult();

            user.MyDoctorId = string.Empty;

            this.db.Update(user);
            this.db.SaveChanges();
        }
        private static string CleanPIN(string PIN)
        {
            return string.Concat(PIN.Remove(6), "****");
        }

        public AmbulatoryListDetailsViewModel GetAmbulgatoryListDetails(string id)
        {
            var ambulatoryList = this.db.AmbulatoryLists.Find(id);

            var ambulatoryListViewModel = new AmbulatoryListDetailsViewModel
            {
                Id = ambulatoryList.Id, 
                AccompanyingConditions = ambulatoryList.AccompanyingConditions, 
                PatientAddress = string.Concat("ул. ", ambulatoryList.Patient.Address?.Street, ", ",
                                                "№ ", ambulatoryList.Patient.Address?.StreetNumber, ", ",
                                                "Вход: ", ambulatoryList.Patient.Address?.Entrance, ", ",
                                                "Етаж: ", ambulatoryList.Patient.Address?.Floor, ", ",
                                                "Апартамент: ", ambulatoryList.Patient.Address?.Apartment, ", ",
                                                "Град: ", ambulatoryList.Patient.Address?.City, ", ",
                                                "Държава: ", ambulatoryList.Patient.Address?.Country.Name, "."), 
                CreatedOn = ambulatoryList.CreatedOn, 
                Diagnosis = ambulatoryList.Diagnosis, 
                DoctorFullName = ambulatoryList.Doctor.FullName, 
                DoctorSpecialtyCode = ambulatoryList.Doctor.SpecialtyCode, 
                DoctorUIN = ambulatoryList.Doctor.UIN, 
                Examinations = ambulatoryList.Examinations, 
                MedicalHistory = ambulatoryList.MedicalHistory, 
                NZOKNumber = ambulatoryList.NZOKNumber, 
                ObjectiveCondition = ambulatoryList.ObjectiveCondition, 
                PatientCountryCode = ambulatoryList.Patient.Address?.Country?.Code, 
                PatientDateOfBirth = ambulatoryList.Patient.BirthDate, 
                PatientFullName = ambulatoryList.Patient.FullName, 
                PatientPIN = CleanPIN(ambulatoryList.Patient.PIN), 
                SubstituteType = ambulatoryList.SubstituteType, 
                TypeOfCheckup = ambulatoryList.TypeOfCheckup,
                Therapy = ambulatoryList.Therapy, 
                VisitReason = ambulatoryList.VisitReason
        };
            return ambulatoryListViewModel;
        }

        public SickLeaveDetailsViewModel GetSickLeaveDetails(string id)
        {
            var sickLeave = db.SickLeaveLists.Find(id);

            var sickLeaveDetails = new SickLeaveDetailsViewModel
            {
                PatientFullName = sickLeave.Patient.FullName,
                PatientAddress = string.Concat("ул. ", sickLeave.Patient.Address?.Street, ", ",
                                                "№ ", sickLeave.Patient.Address?.StreetNumber, ", ",
                                                "Вход: ", sickLeave.Patient.Address?.Entrance, ", ",
                                                "Етаж: ", sickLeave.Patient.Address?.Floor, ", ",
                                                "Апартамент: ", sickLeave.Patient.Address?.Apartment, ", ",
                                                "Град: ", sickLeave.Patient.Address?.City, ", ",
                                                "Държава: ", sickLeave.Patient.Address?.Country.Name, "."),
                DoctorFullName = sickLeave.Doctor.FullName, 
                DoctorAddress = string.Concat("ул. ", sickLeave.Doctor.Address?.Street, ", ",
                                                "№ ", sickLeave.Doctor.Address?.StreetNumber, ", ",
                                                "Вход: ", sickLeave.Doctor.Address?.Entrance, ", ",
                                                "Етаж: ", sickLeave.Doctor.Address?.Floor, ", ",
                                                "Апартамент: ", sickLeave.Doctor.Address?.Apartment, ", ",
                                                "Град: ", sickLeave.Doctor.Address?.City, ", ",
                                                "Държава: ", sickLeave.Doctor.Address?.Country.Name, "."),
                LAKNumber = sickLeave.LAKNumber, 
                Continuation = sickLeave.Continuation ? "Да" : "Не", 
                DateOfIssue = sickLeave.DateOfIssue, 
                Diagnosis = sickLeave.Diagnosis, 
                DisabilityReason = sickLeave.DisabilityReason, 
                EndDate = sickLeave.EndDate, 
                MKBDiagnose = sickLeave.MKBDiagnose.Description, 
                OutpatientJournalNumber = sickLeave.OutpatientJournalNumber, 
                RegistryNumber = sickLeave.RegistryNumber, 
                StartDate = sickLeave.StartDate, 
                TreatmentRegimen = sickLeave.TreatmentRegimen.ToString(), 
                PatientPIN = CleanPIN(sickLeave.Patient.PIN), 
                PatientCountryCode = sickLeave.Patient.Address.Country.Code, 
                PatientDateOfBirth = sickLeave.Patient.BirthDate
            };

            return sickLeaveDetails;
        }
    }
}
