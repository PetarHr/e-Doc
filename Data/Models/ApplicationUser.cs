﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace eDoc.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Contacts = new HashSet<Contact>();
            this.Recipes = new HashSet<Recipe>();
            this.AmbulatoryLists = new HashSet<AmbulatoryList>();
            this.SickLeaveLists = new HashSet<SickLeaveList>();
        }
        public string FirstName { get; set; }
        public string FathersName { get; set; }
        public string FamilyName { get; set; }
        public int PIN { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public Address Address { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<AmbulatoryList> AmbulatoryLists { get; set; }
        public ICollection<SickLeaveList> SickLeaveLists { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Workplace Workplace { get; set; }
        public string Occupation { get; set; }
        //Променливи, които притежават лекарите(УИН, Код специалност)
        public int UIN { get; set; }
        public string Specialtycode { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
