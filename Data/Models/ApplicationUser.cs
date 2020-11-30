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

            this.MyRecipes = new HashSet<Recipe>();
            this.RecipesIssuedByMe = new HashSet<Recipe>();

            this.MyAmbulatoryLists = new HashSet<AmbulatoryList>();
            this.AmbulatoryListsIssuedByMe = new HashSet<AmbulatoryList>();

            this.MySickLeaveLists = new HashSet<SickLeaveList>();
            this.SickLeaveListsIssuedByMe = new HashSet<SickLeaveList>();

            this.MyAllergies = new HashSet<Allergy>();
            this.MyWeight = new HashSet<MyWeight>();
            this.MyBloodPressure = new HashSet<MyBloodPressure>();
        }
        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string FathersName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }
        public string PIN { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }
        public virtual Address Address { get; set; }

        [InverseProperty("Patient")]
        public virtual ICollection<Recipe> MyRecipes { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<Recipe> RecipesIssuedByMe { get; set; }

        [InverseProperty("Patient")]
        public virtual ICollection<AmbulatoryList> MyAmbulatoryLists { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<AmbulatoryList> AmbulatoryListsIssuedByMe { get; set; }

        [InverseProperty("Patient")]
        public virtual ICollection<SickLeaveList> MySickLeaveLists { get; set; }

        [InverseProperty("Doctor")]
        public virtual ICollection<SickLeaveList> SickLeaveListsIssuedByMe { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual Workplace Workplace { get; set; }
        public string Occupation { get; set; }
        //Променливи, които притежават лекарите(УИН, Код специалност)
        public string UIN { get; set; }
        public string SpecialtyCode { get; set; }
        public virtual MedicalCenter MedicalCenter { get; set; }
        public string MyDoctorId { get; set; }
        public string ProfilePicture { get; set; }
        public virtual ICollection<MyWeight> MyWeight { get; set; }
        public virtual ICollection<MyBloodPressure> MyBloodPressure { get; set; }
        public virtual ICollection<Allergy>  MyAllergies { get; set; }
    }
}
