
using eDoc.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace eDoc.Models.Input
{
    public class AmbulatoryListInputModel
    {
        public string Id { get; set; }
        public ICollection<ApplicationUser> PatientsList { get; set; }
        public string PatientFullName { get; set; }
        public string PatientId { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorId { get; set; }
        public DateTime IssuedOn { get; set; }
        public string VisitReason { get; set; }
        public string CheckUpType { get; set; }
        public string Diagnosis { get; set; }
        public string MedicalHistory { get; set; }
        public string ObjectiveCondition { get; set; }
        public string Therapy { get; set; }
        public string Diseases { get; set; }
    }
}
