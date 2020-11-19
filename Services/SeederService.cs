using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace eDoc.Services
{
    public static class SeederService
    {
        public static async Task Initialize(RoleManager<IdentityRole> roleManager,
                                             UserManager<ApplicationUser> userManager)
        {
            await InitializeRoles(roleManager);
            InitializeDemoProfiles(userManager);
        }

        private static void InitializeDemoProfiles(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("Doctor@edoc.com1").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Doctor@edoc.com1",
                    Email = "Doctor@edoc.com1",
                    FirstName = "Доктор",
                    FathersName = "Лечителов",
                    FamilyName = "Докторов",
                    FullName = "Доктор Докторов Лечителов",
                    PIN = "123456789",
                    BirthDate = DateTime.UtcNow,
                    Sex = 0,
                    Occupation = "УНГ",
                    UIN = "УИН12345",
                    SpecialtyCode = "99897",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "Doctor@edoc.com1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "eDoctor").Wait();
                }
            };

            if (userManager.FindByEmailAsync("Patient@edoc.com1").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Patient@edoc.com1",
                    Email = "Patient@edoc.com1",
                    FirstName = "Пациент",
                    FathersName = "Хипохондриков",
                    FamilyName = "Болнавов",
                    PIN = "123456789",
                    BirthDate = DateTime.UtcNow,
                    Sex = 0,
                    Occupation = "Оксиженист",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "Patient@edoc.com1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "ePatient").Wait();
                }
            };
        }

        private static async Task InitializeRoles(RoleManager<IdentityRole> roleManager)
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