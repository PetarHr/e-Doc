using eDoc.Models.View.MyHealth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
            this.MyAllergies = new HashSet<Allergy>();
            this.MyWeight = new HashSet<MyWeight>();
            this.MyBloodPressure = new HashSet<MyBloodPressure>();
        }
        public string FirstName { get; set; }
        public string FathersName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }
        public string PIN { get; set; }
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
        public string UIN { get; set; }
        public string SpecialtyCode { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public string MyDoctorId { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<MyWeight> MyWeight { get; set; }
        public ICollection<MyBloodPressure> MyBloodPressure { get; set; }
        public ICollection<Allergy>  MyAllergies { get; set; }
    }
}
