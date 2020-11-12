using eDoc.Data.Models;
using System.Collections.Generic;

namespace eDoc.Models.View.MyHealth
{
    public class MyHealthDetailsViewModel
    {
        public string UserFullName { get; set; }
        public int Age { get; set; }
        public ICollection<Allergy> Allergies { get; set; }
        public MyWeight MyWeight{ get; set; }
        public MyBloodPressure MyBloodPressure { get; set; }
    }
}
