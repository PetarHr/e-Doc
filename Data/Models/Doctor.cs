using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Data.Models
{
    public class Doctor: User
    {
        //Променливи, които притежават лекарите (УИН, Код специалност)
        public int UIN { get; set; }
        public string Specialtycode { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
