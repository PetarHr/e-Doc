using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models
{
    public class SickLeaveListViewModel
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Employer { get; set; }
    }
}
