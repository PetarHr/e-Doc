using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.Input
{
    public class SickLeaveListInputModel
    {
        public string DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientId { get; set; }
        public ICollection<ApplicationUser> PatientsList { get; set; }
        public string RegistryNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Моля, въведете валиден ЛАК номер")]
        public string LAKNumber { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Моля, въведете валиден номер на журнал")]
        public string OutpatientJournalNumber { get; set; }
        public bool Continuation { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string DisabilityReason { get; set; }
        [Required]
        public string TreatmentRegimen { get; set; }
        public ICollection<MKBDiagnose> MKBDiagnoseList { get; set; }
        public MKBDiagnose MKBDiagnose { get; set; }
        public string MKBDiagnoseId { get; set; }
    }
}
