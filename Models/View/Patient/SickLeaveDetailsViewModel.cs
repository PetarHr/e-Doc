using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View.Patient
{
    public class SickLeaveDetailsViewModel
    {
        public string DoctorFullName { get; set; }
        public string DoctorAddress { get; set; }
        public string PatientFullName { get; set; }
        public string PatientAddress { get; set; }
        public string RegistryNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LAKNumber { get; set; }
        public string OutpatientJournalNumber { get; set; }
        public string Continuation { get; set; }
        public string Diagnosis { get; set; }
        public string DisabilityReason { get; set; }
        public string TreatmentRegimen { get; set; }
        public string MKBDiagnose { get; set; }
        public string PatientPIN { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public string PatientCountryCode { get; set; }
    }
}
