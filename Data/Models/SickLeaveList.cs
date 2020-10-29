using System;

namespace eDoc.Data.Models
{
    public class SickLeaveList
    {
        public string Id { get; set; }
        public string RegistryNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LAKNumber { get; set; }
        public int OutpatientJournalNumber { get; set; }
        public bool Continuation { get; set; }

        public ApplicationUser Patient { get; set; }
        public Doctor Doctor { get; set; }

        public string Diagnosis { get; set; }
        public string DisabilityReason { get; set; }
        public string TreatmentRegimen { get; set; }
        public int TotalDaysOff => (this.EndDate - this.StartDate).Days;

        public MKBDiagnose MKBDiagnose { get; set; }
    }
}