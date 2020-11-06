using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public PatientService(ApplicationDbContext db)
        {
            this.db = db;
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
    }
}
