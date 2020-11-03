using eDoc.Data;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public void CreateRecipe(string doctorId, string patientId, string description)
        {
            var patient = db.Users.Where(x => x.Id == patientId).FirstOrDefault();
            var doctor = db.Users.Where(x => x.Id == doctorId).FirstOrDefault();

            var recipe = new Recipe
            {
                Patient = patient,
                Doctor = doctor,
                PatientId = patientId, 
                DoctorId = doctorId, 
                Description = description
            };

            this.db.Recipes.Add(recipe);
            this.db.SaveChanges();
        }
    }
}
