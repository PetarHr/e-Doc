
using eDoc.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace eDoc.Models.Input
{
    public class AmbulatoryListInputModel
    {
        public int ListId { get; set; }
        public ICollection<ApplicationUser> PatientsList { get; set; }
        public string PatientFullName { get; set; }
        public string PatientPIN { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public string PatientFullAddress { get; set; }
        public string CountryCode { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialtyCode { get; set; }
        public string MedicalCenterRegNumber { get; set; }
        public string DoctorUIN { get; set; }
        public string NZOKNumber { get; set; }
        public string SubstituteUIN { get; set; }
        public SubstituteType SubstituteType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string VisitReason { get; set; }
        public string TypeOfCheckup { get; set; }
        public bool IssuedDocuments { get; set; }
        public ICollection<IssuedDocument> IssuedDocumentsList { get; set; }
        public string MedicalHistory { get; set; }
        public string ObjectiveCondition { get; set; }
        public string Examinations { get; set; }
        public string Therapy { get; set; }
        public string Diagnosis { get; set; }
        public virtual MKBDiagnose MKBDiagnose { get; set; }
        public string AccompanyingConditions { get; set; }
    }
}
