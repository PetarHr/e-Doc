using System;
using System.Collections;
using System.Collections.Generic;

namespace eDoc.Data.Models
{
    public class AmbulatoryList
    {
        public AmbulatoryList()
        {
            this.IssuedDocs = new HashSet<IssuedDoc>();
            this.Tests = new HashSet<Test>();
        }
        public string Id { get; set; }
        public ApplicationUser Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime IssuedOn { get; set; }
        public string VisitReason { get; set; }
        public string CheckUpType { get; set; }
        public ICollection<IssuedDoc> IssuedDocs { get; set; }
        public string Diagnosis { get; set; }
        public string MedicalHistory { get; set; }
        public string ObjectiveCondition { get; set; }
        public ICollection<Test> Tests { get; set; }
        public string Therapy { get; set; }
        public string Diseases { get; set; }
    }
}