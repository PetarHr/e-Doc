using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View
{
    public class AmbulatoryListViewModel
    {
        public string Id { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public DateTime IssueDate { get; set; }
        public string CheckUpType { get; set; }
        public string Therapy { get; set; }
        public string Diagnosis { get; set; }
        public string Diseases { get; set; }
    }
}
