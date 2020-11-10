using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.Input;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eDoc.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> user;

        public DoctorService(ApplicationDbContext db, UserManager<ApplicationUser> user)
        {
            this.db = db;
            this.user = user;
        }

        public void CreateRecipe(CreateRecipeInputModel input)
        {
            var patient = db.Users.Where(x => x.Id == input.PatientId).FirstOrDefault();
            var doctor = db.Users.Where(x => x.Id == input.DoctorId).FirstOrDefault();

            var recipe = new Recipe
            {
                Patient = patient,
                Doctor = doctor,
                AllowMultiCompletion = input.AllowMultiCompletion,
                CreatedOn = DateTime.UtcNow,
                Description = input.RecipeDescription
            };

            this.db.Recipes.Add(recipe);
            this.db.SaveChanges();
        }

        public void CreateAmbulatoryList(AmbulatoryListInputModel input)
        {
            var patient = db.Users.Where(x => x.Id == input.PatientId).FirstOrDefault();
            var doctor = db.Users.Where(x => x.Id == input.DoctorId).FirstOrDefault();

            var ambulatoryList = new AmbulatoryList
            {
                CheckUpType = input.CheckUpType,
                Diagnosis = input.Diagnosis, 
                Diseases = input.Diseases,
                Doctor = doctor,
                Patient = patient,
                IssuedOn = DateTime.UtcNow, 
                MedicalHistory = input.MedicalHistory, 
                ObjectiveCondition = input.ObjectiveCondition, 
                Therapy = input.Therapy, 
                VisitReason = input.VisitReason
            };

            this.db.AmbulatoryLists.Add(ambulatoryList);
            this.db.SaveChanges();

        }

        public void CreateSickLeaveList(SickLeaveListInputModel input)
        {
            var patient = db.Users.Where(p => p.Id == input.PatientId).FirstOrDefault();
            var doctor = db.Users.Where(d => d.Id == input.DoctorId).FirstOrDefault();
            var mkbdiagnose = db.MKBDiagnoses.Where(m => m.Id == input.MKBDiagnoseId).FirstOrDefault();

            var sickLeave = new SickLeaveList
            {
                Doctor = doctor,
                Patient = patient,
                LAKNumber = input.LAKNumber,
                Continuation = input.Continuation,
                DateOfIssue = input.DateOfIssue,
                Diagnosis = input.Diagnosis,
                DisabilityReason = input.DisabilityReason,
                EndDate = input.EndDate,
                MKBDiagnose = mkbdiagnose,
                OutpatientJournalNumber = input.OutpatientJournalNumber,
                RegistryNumber = input.RegistryNumber,
                StartDate = input.StartDate,
                TreatmentRegimen = input.TreatmentRegimen
            };

            this.db.SickLeaveLists.Add(sickLeave);
            this.db.SaveChanges();
        }

        public List<ApplicationUser> GetAllPatients()
        {
            return user.GetUsersInRoleAsync("ePatient").GetAwaiter().GetResult().ToList(); ;
        }

        public List<ApplicationUser> GetDoctorPatients(string doctorId)
        {
            return this.db.Users.Where(u => u.MyDoctorId == doctorId).ToList();
        }


    }
}
