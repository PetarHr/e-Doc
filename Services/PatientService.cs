﻿using eDoc.Data;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int GetMyAmbulatoryListsCount()
        {
            throw new NotImplementedException();
        }

        public ICollection<Recipe> GetMyRecipes()
        {
            throw new NotImplementedException();
        }

        public int GetMyRecipesCount()
        {
            throw new NotImplementedException();
        }
    }
}
