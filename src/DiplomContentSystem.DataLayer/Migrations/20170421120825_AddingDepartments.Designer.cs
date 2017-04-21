using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DiplomContentSystem.DataLayer;

namespace DiplomContentSystem.DataLayer.Migrations
{
    [DbContext(typeof(DiplomContext))]
    [Migration("20170421120825_AddingDepartments")]
    partial class AddingDepartments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("DiplomContentSystem.Core.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstituteId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int>("PeriodId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("TeacherId");

                    b.ToTable("DiplomWorks");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWorkComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("DiplomWorkId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("DiplomWorkId");

                    b.ToTable("DiplomWorkComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWorkMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<byte[]>("Data");

                    b.Property<int>("DiplomWorkId");

                    b.Property<string>("Name");

                    b.Property<int>("Rank");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DiplomWorkId");

                    b.ToTable("DiplomWorkMaterials");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWorkMaterialComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("DiplomWorkMaterialId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("DiplomWorkMaterialId");

                    b.ToTable("DiplomWorkMaterialComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.GostControlTry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("DiplomWorkMaterialId");

                    b.Property<string>("Discription");

                    b.Property<bool>("Result");

                    b.Property<string>("Сontroller");

                    b.HasKey("Id");

                    b.HasIndex("DiplomWorkMaterialId");

                    b.ToTable("GostControlTries");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.GostControlTryComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("GostControlTryId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("GostControlTryId");

                    b.ToTable("GostControlTryComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("PeriodId");

                    b.Property<int>("SpecialityId");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.ImplementationStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("DiplomWorkId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DiplomWorkId");

                    b.ToTable("ImplementationStages");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.ImplementationStageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("ImplementationStageId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("ImplementationStageId");

                    b.ToTable("ImplementationStageComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<string>("Сode");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DiplomWorkId");

                    b.Property<string>("FIO");

                    b.Property<int>("GroupId");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("DiplomWorkId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.StudentComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.SubImplementationStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("ImplementationStageId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ImplementationStageId");

                    b.ToTable("SubImplementationStages");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.SubImplementationStageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("SubImplementationStageId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("SubImplementationStageId");

                    b.ToTable("SubImplementationStageComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FIO");

                    b.Property<int>("MaxWorkCount");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PositionId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.TeacherComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherComments");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.TeacherPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TeachersPositions");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityId");

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Department", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Institute", "Institute")
                        .WithMany("Departments")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWork", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Period", "Period")
                        .WithMany("DiplomWorks")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Teacher", "Teacher")
                        .WithMany("DiplomWorks")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWorkComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("DiplomWorkComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.DiplomWork", "DiplomWork")
                        .WithMany("DiplomWorkComments")
                        .HasForeignKey("DiplomWorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWorkMaterial", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Student", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.DiplomWork", "DiplomWork")
                        .WithMany("DiplomWorkMaterials")
                        .HasForeignKey("DiplomWorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWorkMaterialComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("DiplomWorkMaterialComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.DiplomWorkMaterial", "DiplomWorkMaterial")
                        .WithMany("DiplomWorkMaterialComment")
                        .HasForeignKey("DiplomWorkMaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.GostControlTry", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.DiplomWorkMaterial", "DiplomWorkMaterial")
                        .WithMany("GostControlTries")
                        .HasForeignKey("DiplomWorkMaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.GostControlTryComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("GostControlTryComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.GostControlTry", "GostControlTry")
                        .WithMany()
                        .HasForeignKey("GostControlTryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Group", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Period", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.ImplementationStage", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.DiplomWork", "DiplomWork")
                        .WithMany("ImplementationStages")
                        .HasForeignKey("DiplomWorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.ImplementationStageComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("ImplementationStageComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.ImplementationStage", "ImplementationStage")
                        .WithMany("ImplementationStageComments")
                        .HasForeignKey("ImplementationStageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Speciality", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Department", "Department")
                        .WithMany("Specialities")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Student", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.DiplomWork", "DiplomWork")
                        .WithMany("Students")
                        .HasForeignKey("DiplomWorkId");

                    b.HasOne("DiplomContentSystem.Core.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.StudentComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("StudentComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Student", "Student")
                        .WithMany("StudentComments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.SubImplementationStage", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.ImplementationStage", "ImplementationStage")
                        .WithMany("SubImplementationStages")
                        .HasForeignKey("ImplementationStageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.SubImplementationStageComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("SubImplementationStageComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.SubImplementationStage", "SubImplementationStage")
                        .WithMany("SubImplementationStageComment")
                        .HasForeignKey("SubImplementationStageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Teacher", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.TeacherPosition", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.TeacherComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("TeacherComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Teacher", "Teacher")
                        .WithMany("TeacherComments")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.UserRole", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
