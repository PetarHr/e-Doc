﻿using eDoc.Data;
using eDoc.Data.Models;
using eDoc.Models.Input;
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
            this.db.SaveChangesAsync();
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
            var saveTask = this.db.SaveChangesAsync();

        }

        public List<ApplicationUser> GetAllPatients()
        {
            List<ApplicationUser> patientList = db.Users.ToList();

            return patientList;
        }


    }
}
