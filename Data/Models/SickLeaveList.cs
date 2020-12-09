using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eDoc.Data.Models
{
    public class SickLeaveList
    {
        public SickLeaveList()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Doctor { get; set; }
        public string RegistryNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LAKNumber { get; set; }
        public string OutpatientJournalNumber { get; set; }
        public bool Continuation { get; set; }
        public string Diagnosis { get; set; }
        public string DisabilityReason { get; set; }
        public string TreatmentRegimen { get; set; }
        public virtual MKBDiagnose MKBDiagnose { get; set; }
    }
}