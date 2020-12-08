
using eDoc.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eDoc.Models.Input
{
    public class AmbulatoryListInputModel
    {
        public ICollection<ApplicationUser> PatientsList { get; set; }
        public string PatientFullName { get; set; }
        public string PatientId { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialtyCode { get; set; }
        public string MedicalCenterRegNumber { get; set; }
        public string DoctorId { get; set; }
        public string DoctorUIN { get; set; }
        public string NZOKNumber { get; set; }
        public SubstituteType? SubstituteType { get; set; }
        public DateTime CreatedOn { get; set; }
        public VisitReason VisitReason { get; set; }
        public TypeOfCheckup TypeOfCheckup { get; set; }
        public bool IssuedDocuments { get; set; }
        public ICollection<IssuedDocument> IssuedDocumentsList { get; set; }
        [Required]
        public string MedicalHistory { get; set; }
        [Required]
        public string ObjectiveCondition { get; set; }
        [Required]
        public string Examinations { get; set; }
        [Required]
        public string Therapy { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public int MKBDiagnoseCode { get; set; }
        [Required]
        public string MKBDiagnoseDescription { get; set; }
        [Required]
        public string AccompanyingConditions { get; set; }
    }
}
