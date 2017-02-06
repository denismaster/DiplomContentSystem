using System;
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
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<DiplomWork> DiplomWorks { get; set; }
        public DbSet<DiplomWorkMaterial> DiplomWorkMaterials { get; set; }
        public DbSet<GostControlTry> GostControlTries { get; set; }
        public DbSet<ImplementationStage> ImplementationStages { get; set; }
        public DbSet<SubImplementationStage> SubImplementationStages { get; set; }
        public DbSet<TeacherComment> TeacherComments { get; set; }
        public DbSet<StudentComment> StudentComments { get; set; }
        public DbSet<DiplomWorkComment> DiplomWorkComments { get; set; }
        public DbSet<DiplomWorkMaterialComment> DiplomWorkMaterialComments { get; set; }
        public DbSet<GostControlTryComment> GostControlTryComments { get; set; }
        public DbSet<ImplementationStageComment> ImplementationStageComments { get; set; }
        public DbSet<SubImplementationStageComment> SubImplementationStageComments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DiplomContext(DbContextOptions<DiplomContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=Diplom;UserId=postgres;Password=1234;Pooling=true");
        }
    }
}
