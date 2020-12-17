using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View.Doctor
{
    public class AmbulatoryListsIssuedByMeViewModel
    {
        public string Id { get; set; }
        public string DoctorFullName { get; set; }
        public string PatientFullName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Therapy { get; set; }
        public string ObjectiveCondition { get; set; }
    }
}
