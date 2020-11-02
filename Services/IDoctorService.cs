using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public interface IDoctorService
    {
        public void CreateRecipe(string doctorId, string patientId, string description);
    }
}
