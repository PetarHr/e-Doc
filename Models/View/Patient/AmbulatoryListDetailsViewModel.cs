using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View.Patient
{
    public class AmbulatoryListDetailsViewModel
    {
        public string Id { get; set; }
        public string PatientFullName { get; set; }
        public string PatientPIN { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public string PatientAddress { get; set; }
        public string PatientCountryCode { get; set; }
        public string DoctorFullName { get; set; }
        public string DoctorSpecialtyCode { get; set; }
        public string DoctorUIN { get; set; }
        public string NZOKNumber { get; set; }
        public SubstituteType? SubstituteType { get; set; }
        public DateTime CreatedOn { get; set; }
        public VisitReason VisitReason { get; set; }
        public TypeOfCheckup TypeOfCheckup { get; set; }
        public string MedicalHistory { get; set; }
        public string ObjectiveCondition { get; set; }
        public string Examinations { get; set; }
        public string Therapy { get; set; }
        public string Diagnosis { get; set; }
        public string AccompanyingConditions { get; set; }
    }
}
