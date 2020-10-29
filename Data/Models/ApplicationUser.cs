using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace eDoc.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string FathersName { get; set; }
        public string FamilyName { get; set; }
        //ЕГН или ЛНЧ
        public int PIN { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public string Occupation { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<AmbulatoryList> AmbulatoryLists { get; set; }
        public ICollection<SickLeaveList> SickLeaveLists { get; set; }
        public Workplace Workplace { get; set; }
    }
}
