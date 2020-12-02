using System;

namespace eDoc.Models.View.Patient
{
    public class PatientDetailsViewModel
    {
        public string  PIN { get; set; }
        public DateTime BirthDate { get; set; }
        public string  FullAddress { get; set; }
        public string  CountryCode { get; set; }
    }
}
