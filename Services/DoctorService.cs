using eDoc.Data;
using eDoc.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext db;

        public DoctorService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateRecipe(string doctorId, string patientId, string description)
        {
            //TODO: Create ADD RECIPE mechanism
            throw new NotImplementedException();
        }
    }
}
