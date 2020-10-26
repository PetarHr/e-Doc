using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eDoc.Data.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Username => 
                            this.Contacts.Where(x => x.Type =="email")
                                .FirstOrDefault()
                                .ToString();
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

        //Променливи, които притежават лекарите (УИН, Код специалност)
        public int UIN { get; set; }
        public string Specialtycode { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public Workplace Workplace { get; set; }

        //Колекции, които притежава всеки човек
        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<AmbulatoryList> AmbulatoryLists { get; set; }

        public ICollection<SickLeaveList> SickLeaveLists { get; set; }
    }
}
