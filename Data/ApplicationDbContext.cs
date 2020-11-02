﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using eDoc.Controllers;
using eDoc.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eDoc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AmbulatoryList> AmbulatoryLists { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<IssuedDoc> IssuedDocuments { get; set; }
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
            builder.Entity<ApplicationUser>()
                     .HasMany(d => d.AmbulatoryLists);
            builder.Entity<ApplicationUser>()
         .HasMany(d => d.Recipes);
            builder.Entity<ApplicationUser>()
         .HasMany(d => d.SickLeaveLists);

            builder.Entity<AmbulatoryList>().
                HasOne(y => y.Doctor);
            builder.Entity<AmbulatoryList>().
                HasOne(y => y.Patient);

            builder.Entity<Recipe>().
                HasOne(y => y.Patient);
            builder.Entity<Recipe>().
                HasOne(y => y.Doctor);

            builder.Entity<SickLeaveList>().
                 HasOne(y => y.Patient);
            builder.Entity<SickLeaveList>().
                HasOne(y => y.Doctor);


            base.OnModelCreating(builder);
        }
    }
}
