using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public static class RoleSeederService
    {
        public static async Task Initialize (RoleManager<IdentityRole> roleManager)
        {
            await InitializeRoles(roleManager);
        }
        public static async Task InitializeRoles (RoleManager<IdentityRole> roleManager)
        {
            var adminExists = roleManager.RoleExistsAsync("GodModeAdmin").Result;
            var patientExists = roleManager.RoleExistsAsync("ePatient").Result;
            var doctorExists = roleManager.RoleExistsAsync("eDoctor").Result;
            var pharmacistExists = roleManager.RoleExistsAsync("ePharmacist").Result;
            var employerExists = roleManager.RoleExistsAsync("eEmployer").Result;

            if (!adminExists)
            {
                await roleManager.CreateAsync(new IdentityRole("GodModeAdmin"));
            }
            if (!patientExists)
            {
                await roleManager.CreateAsync(new IdentityRole("ePatient"));
            }
            if (!doctorExists)
            {
                await roleManager.CreateAsync(new IdentityRole("eDoctor"));
            }
            if (!pharmacistExists)
            {
                await roleManager.CreateAsync(new IdentityRole("ePharmacist"));
            }
            if (!employerExists)
            {
                await roleManager.CreateAsync(new IdentityRole("eEmployer"));
            }
        }
    }
}
