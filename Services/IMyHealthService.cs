using eDoc.Data.Models;
using eDoc.Models.View.MyHealth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IMyHealthService
    {
        public Task UpdateWeight(MyWeight input);
        public Task UpdateBloodPressure(MyBloodPressure input);
        public Task AddAllergy(Allergy input);
        public MyHealthDetailsViewModel GetMyHealthStats();
    }
}
