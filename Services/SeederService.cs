using eDoc.Data;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace eDoc.Services
{
    public static class SeederService
    {
        public static async Task Initialize(RoleManager<IdentityRole> roleManager,
                                             UserManager<ApplicationUser> userManager,
                                             ApplicationDbContext db)
        {
            await InitializeRoles(roleManager);
            InitializeDemoProfiles(userManager);
            await InitializeMKBListAsync(db);
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
                    EmailConfirmed = true, 
                    Title = Title.Господин,
                    Address = new Address
                    {
                        Apartment = "12", 
                        City = "Пловдив", 
                        Comment = "Това е основният ми адрес.", 
                        Country = new Country
                        {
                                Code = "BGR", 
                                Name = "България", 
                                PhoneCode = "+359"
                        }, 
                        Entrance = "Вход А", 
                        Floor = 1, 
                        Street = "ул. Първа",
                        StreetNumber = 34, 
                        Region = new Region
                        {
                            Name = "Пловдив"
                        }, 
                        Municipality = new Municipality
                        {
                            Name = "Пловдив"
                        }
                    }

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
                    FullName = "Пациент Хипохондриков Болнавов",
                    PIN = "123456789",
                    BirthDate = DateTime.UtcNow,
                    Sex = 0,
                    Occupation = "Оксиженист",
                    EmailConfirmed = true,
                    Title = Title.Господин,
                    Address = new Address
                    {
                        Apartment = "12",
                        City = "Пловдив",
                        Comment = "Това е основният ми адрес.",
                        Country = new Country
                        {
                            Code = "BGR",
                            Name = "България",
                            PhoneCode = "+359"
                        },
                        Entrance = "Вход А",
                        Floor = 1,
                        Street = "ул. Първа",
                        StreetNumber = 34,
                        Region = new Region
                        {
                            Name = "Пловдив"
                        },
                        Municipality = new Municipality
                        {
                            Name = "Пловдив"
                        }
                    }
                };

                IdentityResult result = userManager.CreateAsync(user, "Patient@edoc.com1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "ePatient").Wait();
                }
            };

            if (userManager.FindByEmailAsync("Admin@edoc.com1").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Admin@edoc.com1",
                    Email = "Admin@edoc.com1",
                    FirstName = "Администратор",
                    FathersName = "@",
                    FamilyName = "еДок",
                    FullName = "Администратор @ еДок",
                    PIN = "5555555555",
                    BirthDate = DateTime.UtcNow,
                    Sex = 0,
                    Occupation = "Администратор",
                    EmailConfirmed = true,
                    Title = Title.Господин,
                    Address = new Address
                    {
                        Apartment = "12",
                        City = "Пловдив",
                        Comment = "Това е основният ми адрес.",
                        Country = new Country
                        {
                            Code = "BGR",
                            Name = "България",
                            PhoneCode = "+359"
                        },
                        Entrance = "Вход А",
                        Floor = 1,
                        Street = "ул. Първа",
                        StreetNumber = 34,
                        Region = new Region
                        {
                            Name = "Пловдив"
                        },
                        Municipality = new Municipality
                        {
                            Name = "Пловдив"
                        }
                    }
                };

                IdentityResult result = userManager.CreateAsync(user, "Admin@edoc.com1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "GodModeAdmin").Wait();
                }
            };

            if (userManager.FindByEmailAsync("Pharmacist@edoc.com1").Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Pharmacist@edoc.com1",
                    Email = "Pharmacist@edoc.com1",
                    FirstName = "Фармацевт",
                    FathersName = "@",
                    FamilyName = "еДок",
                    FullName = "Фармацевт @ еДок",
                    PIN = "5555555555",
                    BirthDate = DateTime.UtcNow,
                    Sex = 0,
                    Occupation = "Фармацевт",
                    EmailConfirmed = true,
                    Title = Title.Господин,
                    Address = new Address
                    {
                        Apartment = "12",
                        City = "Пловдив",
                        Comment = "Това е основният ми адрес.",
                        Country = new Country
                        {
                            Code = "BGR",
                            Name = "България",
                            PhoneCode = "+359"
                        },
                        Entrance = "Вход А",
                        Floor = 1,
                        Street = "ул. Първа",
                        StreetNumber = 34,
                        Region = new Region
                        {
                            Name = "Пловдив"
                        },
                        Municipality = new Municipality
                        {
                            Name = "Пловдив"
                        }
                    }
                };

                IdentityResult result = userManager.CreateAsync(user, "Pharmacist@edoc.com1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "ePharmacist").Wait();
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

        private static async Task InitializeMKBListAsync(ApplicationDbContext db)
        {
            List<MKBDiagnose> MKBList = db.MKBDiagnoses.ToList();

            if (MKBList.Count != 0)
            {
                return;
            }

            string[] lines = System.IO.File.ReadAllLines(@"D:\Проекти\MKBArraySeeder\TXTArray\ArrayBG.txt");


            foreach (string line in lines)
            {
                if (line.Contains("достига до вас благодарение") ||
                    line.Contains("Международна класификация на"))
                {
                    continue;
                }
                else
                {
                    var tokens = line.Split(' ', 2, StringSplitOptions.None);

                    if (tokens[0] != null || tokens[1] != null)
                    {

                        var MKBDiagnose = new MKBDiagnose
                        {
                            Code = tokens[0].Replace("*",""),
                            Description = tokens[1]
                        };

                        MKBList.Add(MKBDiagnose);
                    }

                }
            }

            await db.AddRangeAsync(MKBList);
            await db.SaveChangesAsync();
        }
    }
}