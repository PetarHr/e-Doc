using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View
{
    public class DoctorsListViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Specialty { get; set; }
        public string MedicalCenter { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}
