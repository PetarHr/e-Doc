using System;
using System.Collections.Generic;

namespace eDoc.Data.Models
{
    public class AmbulatoryList
    {
        public AmbulatoryList()
        {
            this.IssuedDocumentsList = new HashSet<IssuedDocument>();
        }
        public int Id { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Doctor { get; set; }
        public string NZOKNumber { get; set; }
        public SubstituteType? SubstituteType { get; set; }
        public DateTime CreatedOn { get; set; }
        public VisitReason VisitReason { get; set; }
        public TypeOfCheckup TypeOfCheckup { get; set; }
        public bool IssuedDocuments { get; set; }
        public virtual ICollection<IssuedDocument> IssuedDocumentsList { get; set; }
        public string MedicalHistory { get; set; }
        public string ObjectiveCondition { get; set; }
        public string Examinations { get; set; }
        public string Therapy { get; set; }
        public string Diagnosis { get; set; }
        public virtual MKBDiagnose MKBDiagnose { get; set; }
        public string AccompanyingConditions { get; set; }
    }
}