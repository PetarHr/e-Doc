using System;
using System.Collections.Generic;
using System.Text;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eDoc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AmbulatoryList> AmbulatoryLists { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<IssuedDoc> IssuedDocs { get; set; }
        public DbSet<MedicalCenter> MedicalCenters { get; set; }
        public DbSet<MKBDiagnose> MKBDiagnoses { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SickLeaveList> SickLeaveLists { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasMany(x => x.Recipes);
            builder.Entity<Doctor>().HasMany(x => x.Recipes);
        }
    }
}
