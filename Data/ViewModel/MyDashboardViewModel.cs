using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Data.ViewModel
{
    public class MyDashboardViewModel
    {
        public MyDashboardViewModel()
        {
            this.MyRecipes = new HashSet<Recipe>();
            this.MyAmbulatoryLists = new HashSet<AmbulatoryList>();
        }
        public ICollection<Recipe> MyRecipes { get; set; }
        public ICollection<AmbulatoryList> MyAmbulatoryLists { get; set; }
    }
}
