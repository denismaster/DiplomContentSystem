﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.DataLayer
{
    public class DiplomContext : DbContext
    {
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<TeacherPosition> TeachersPositions { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<DiplomWork> DiplomWorks { get; set; }
        public DbSet<DiplomWorkMaterial> DiplomWorkMaterials { get; set; }
        public DbSet<GostControlTry> GostControlTries { get; set; }
        public DbSet<ImplementationStage> ImplementationStages { get; set; }
        public DbSet<CustomStage> CustomStages { get; set; }
        public DbSet<TeacherComment> TeacherComments { get; set; }
        public DbSet<StudentComment> StudentComments { get; set; }
        public DbSet<DiplomWorkComment> DiplomWorkComments { get; set; }
        public DbSet<DiplomWorkMaterialComment> DiplomWorkMaterialComments { get; set; }
        public DbSet<GostControlTryComment> GostControlTryComments { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<TemplateType> TemplateTypes { get; set; }
        public DbSet<Template> Templates { get; set; }
        
        public DiplomContext(DbContextOptions<DiplomContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.Roles)
                .HasForeignKey(pt => pt.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(pt => pt.Role)
                .WithMany(t => t.Users)
                .HasForeignKey(pt => pt.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Use appsettings.json or environment variable, not the string here.
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=DCS;UserId=postgres;Password=12345678;Pooling=true");
        }
    }
}