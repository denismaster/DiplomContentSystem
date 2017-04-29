using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.DataLayer
{
    public static class DiplomContentSystemExtensions
    {
        public static void EnsureSeedData(this DiplomContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(Role.Admin, Role.Owner, Role.Student, Role.Teacher);
                    context.SaveChanges();
                }
                if (!context.Periods.Any())
                {
                    context.Periods.Add(Period.Current);
                    context.SaveChanges();
                }
                if(!context.TeachersPositions.Any())
                {
                    context.TeachersPositions.AddRange(
                        TeacherPosition.Assistance,
                        TeacherPosition.HighTeacher,
                        TeacherPosition.Professor,
                        TeacherPosition.Doctor
                    );
                    context.SaveChanges();
                }
            }
        }
        private static bool AllMigrationsApplied(this DiplomContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}