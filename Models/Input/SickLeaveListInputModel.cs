using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.Input
{
    public class SickLeaveListInputModel
    {
        public SickLeaveListInputModel()
        {
            this.PatientsList = new HashSet<ApplicationUser>();
            this.MKBDiagnoseList = new HashSet<MKBDiagnose>();
        }
        public string Id { get; set; }
        public string DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientId { get; set; }
        public ICollection<ApplicationUser> PatientsList { get; set; }
        public string RegistryNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LAKNumber { get; set; }
        public int OutpatientJournalNumber { get; set; }
        public bool Continuation { get; set; }
        public string Diagnosis { get; set; }
        public string DisabilityReason { get; set; }
        public string TreatmentRegimen { get; set; }
        public int TotalDaysOff => (this.EndDate - this.StartDate).Days;
        public ICollection<MKBDiagnose> MKBDiagnoseList { get; set; }
        public MKBDiagnose MKBDiagnose { get; set; }
        public string MKBDiagnoseId { get; set; }
    }
}
