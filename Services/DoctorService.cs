using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.Input;
using eDoc.Models.View.Doctor;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eDoc.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DoctorService(ApplicationDbContext db,
                             SignInManager<ApplicationUser> signInManager)
        {
            this._db = db;
            this._signInManager = signInManager;
        }
        public CreateRecipeInputModel PrepareRecipeInputModel()
        {
            var doctorUserName = _signInManager.Context.User.Identity.Name;
            var doctor = this._db.Users.Where(x => x.UserName == doctorUserName).FirstOrDefault();
            var patientList = _signInManager
                                            .UserManager
                                            .GetUsersInRoleAsync("ePatient")
                                            .GetAwaiter()
                                            .GetResult()
                                            .ToList();

            var inputModel = new CreateRecipeInputModel
            {
                DoctorId = doctor.Id,
                DoctorFullName = doctor.FullName,
                DoctorSpecialtyCode = doctor.SpecialtyCode,
                DoctorUIN = doctor.UIN,
                PatientsList = patientList,
                CreatedOn = DateTime.Now
            };
            return inputModel;
        }

        public void CreateRecipe(CreateRecipeInputModel input)
        {
            var patient = _db.Users.Where(x => x.Id == input.PatientId).FirstOrDefault();
            var doctor = _db.Users.Where(x => x.Id == input.DoctorId).FirstOrDefault();

            var recipe = new Recipe
            {
                Patient = patient,
                Doctor = doctor,
                AllowMultiCompletion = input.AllowMultiCompletion,
                CreatedOn = DateTime.UtcNow,
                Description = input.Description
            };

            this._db.Recipes.Add(recipe);
            this._db.SaveChanges();
        }

        public AmbulatoryListInputModel PrepareAmbListInputModel()
        {
            var listAllPatients = this.GetAllPatients();

            var doctorUserName = _signInManager.Context.User.Identity.Name;
            var doctor = this._db.Users.Where(x => x.UserName == doctorUserName).FirstOrDefault();

            var ambulatoryListInputModel = new AmbulatoryListInputModel
            {
                PatientsList = listAllPatients,
                DoctorFullName = doctor.FullName,
                DoctorId = doctor.Id,
                DoctorSpecialtyCode = doctor.SpecialtyCode,
                DoctorUIN = doctor.UIN,
                CreatedOn = DateTime.Now
            };

            return ambulatoryListInputModel;
        }

        public void CreateAmbulatoryList(AmbulatoryListInputModel input)
        {
            var doctor = this._db.Users.Find(input.DoctorId);
            var patient = this._db.Users.Find(input.PatientId);

            if (doctor == null || patient == null)
            {
                return;
            }

            var ambulatoryList = new AmbulatoryList
            {
                CreatedOn = input.CreatedOn,
                AccompanyingConditions = input.AccompanyingConditions,
                Diagnosis = input.Diagnosis,
                Doctor = doctor,
                Examinations = input.Examinations,
                MedicalHistory = input.MedicalHistory,
                NZOKNumber = input.NZOKNumber,
                ObjectiveCondition = input.ObjectiveCondition,
                Patient = patient,
                SubstituteType = input.SubstituteType,
                Therapy = input.Therapy,
                TypeOfCheckup = input.TypeOfCheckup,
                VisitReason = input.VisitReason
            };

            this._db.AmbulatoryLists.Add(ambulatoryList);
            this._db.SaveChanges();
        }


        public SickLeaveListInputModel PrepareSickLeaveInputModel()
        {
            var listAllPatients = this.GetAllPatients();
            var MKBList = _db.MKBDiagnoses.ToList();

            var doctorUserName = _signInManager.Context.User.Identity.Name;
            var doctor = this._db.Users.Where(x => x.UserName == doctorUserName).FirstOrDefault();

            var sickLeaveInputModel = new SickLeaveListInputModel
            {
                DoctorFullName = doctor.FullName,
                DoctorId = doctor.Id,
                PatientsList = listAllPatients,
                MKBDiagnoseList = MKBList,
                DateOfIssue = DateTime.Now
            };

            return sickLeaveInputModel;
        }

        public void CreateSickLeaveList(SickLeaveListInputModel input)
        {
            var patient = _db.Users.Where(p => p.Id == input.PatientId).FirstOrDefault();
            var doctor = _db.Users.Where(d => d.Id == input.DoctorId).FirstOrDefault();
            var mkbdiagnose = _db.MKBDiagnoses.Where(m => m.Id == input.MKBDiagnoseId).FirstOrDefault();

            var sickLeave = new SickLeaveList
            {
                Doctor = doctor,
                Patient = patient,
                LAKNumber = input.LAKNumber,
                Continuation = input.Continuation,
                DateOfIssue = input.DateOfIssue,
                Diagnosis = input.Diagnosis,
                DisabilityReason = input.DisabilityReason,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                MKBDiagnose = mkbdiagnose,
                OutpatientJournalNumber = input.OutpatientJournalNumber,
                RegistryNumber = input.RegistryNumber,
                TreatmentRegimen = input.TreatmentRegimen,
            };

            this._db.SickLeaveLists.Add(sickLeave);
            var result = this._db.SaveChanges();
        }

        public ICollection<ApplicationUser> GetAllPatients()
        {
            return _signInManager.UserManager.GetUsersInRoleAsync("ePatient").GetAwaiter().GetResult().ToList();
        }

        public ICollection<ApplicationUser> GetDoctorPatients(string doctorId)
        {
            return this._db.Users.Where(u => u.MyDoctorId == doctorId).ToList();
        }

        public List<RecipesIssuedByMeViewModel> GetRecipesIssueByMe()
        {
            var userName = _signInManager.Context.User.Identity.Name;
            var user = this._db.Users.Where(x => x.UserName == userName).FirstOrDefault();

            List<RecipesIssuedByMeViewModel> recipeList = new List<RecipesIssuedByMeViewModel>();

            foreach (var issuedRecipe in user.RecipesIssuedByMe)
            {
                var recipe = new RecipesIssuedByMeViewModel
                {
                    Id = issuedRecipe.Id,
                    DoctorFullName = issuedRecipe.Doctor.FullName,
                    PatientFullName = issuedRecipe.Patient.FullName,
                    CreatedOn = issuedRecipe.CreatedOn,
                    AllowMultiCompletion = issuedRecipe.AllowMultiCompletion ? "Да" : "Не",
                    Completed = issuedRecipe.Completed ? "Да" : "Не"
                };

                recipeList.Add(recipe);
            }
            return recipeList;
        }

        public ICollection<AmbulatoryList> GetAmbulatoryListsIssueByMe()
        {
            var userName = _signInManager.Context.User.Identity.Name;
            var user = this._db.Users.Where(x => x.UserName == userName).FirstOrDefault();

            var listsIssueByUser = user.AmbulatoryListsIssuedByMe;

            return listsIssueByUser;
        }

        public ICollection<SickLeaveList> GetSickLeavesIssueByMe()
        {
            var userName = _signInManager.Context.User.Identity.Name;
            var user = this._db.Users.Where(x => x.UserName == userName).FirstOrDefault();

            var listsIssueByUser = user.SickLeaveListsIssuedByMe;

            return listsIssueByUser;
        }
    }
}
