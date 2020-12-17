using eDoc.Data.Models;
using System.Collections.Generic;

namespace eDoc.Models.View.Pharmacist
{
    public class MyWorkListViewModel
    {
        public MyWorkListViewModel()
        {
            this.RecipesList = new List<PharmacistRecipesViewModel>();
        }
        public string PharmacistName { get; set; }
        public string WorkplaceName { get; set; }
        public List<PharmacistRecipesViewModel> RecipesList { get; set; }
    }
}
