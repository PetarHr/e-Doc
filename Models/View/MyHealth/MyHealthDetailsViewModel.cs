using eDoc.Data.Models;
using System.Collections.Generic;

namespace eDoc.Models.View.MyHealth
{
    public class MyHealthDetailsViewModel
    {
        public MyHealthDetailsViewModel()
        {
            this.AllergiesList = new HashSet<Allergy>();
        }
        public string UserFullName { get; set; }
        public int Age { get; set; }
        public ICollection<Allergy> AllergiesList { get; set; }
        public MyWeight MyWeight{ get; set; }
        public MyBloodPressure MyBloodPressure { get; set; }
    }
}
