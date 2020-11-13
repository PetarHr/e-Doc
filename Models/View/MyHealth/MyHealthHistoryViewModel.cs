using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Models.View.MyHealth
{
    public class MyHealthHistoryViewModel
    {
        public string UserFullName { get; set; }
        public List<MyWeight> MyWeightList { get; set; }
        public List<MyBloodPressure> MyBloodPressureList { get; set; }
        public List<Allergy> MyAllergiesList { get; set; }
    }
}
