using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DiplomContentSystem.DataLayer;

namespace DiplomContentSystem.DataLayer.Migrations
{
    [DbContext(typeof(DiplomContext))]
    [Migration("20170312105717_ChangeImplementationStage")]
    partial class ChangeImplementationStage
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

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<int>("PeriodId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("TeacherId");

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

                    b.Property<int>("SpecialityId");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

                    b.ToTable("Groups");
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

            modelBuilder.Entity("DiplomContentSystem.Core.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstituteId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.Property<string>("Сode");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("DiplomWorkId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DiplomWorkId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.StageComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentId");

                    b.Property<int>("StageId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("StageId");

                    b.ToTable("StageComments");
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

            modelBuilder.Entity("DiplomContentSystem.Core.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FIO");

                    b.Property<int>("SpecialityId");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityId");

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

                    b.Property<int>("MaxWorkCount");

                    b.Property<string>("Name");

                    b.Property<int>("PeriodId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeachersPositions");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.DiplomWork", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Period", "Period")
                        .WithMany("DiplomWorks")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Teacher")
                        .WithMany("DiplomWorks")
                        .HasForeignKey("TeacherId");
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
                    b.HasOne("DiplomContentSystem.Core.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Speciality", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Institute", "Institute")
                        .WithMany("Specialties")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Stage", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.DiplomWork", "DiplomWork")
                        .WithMany("Stages")
                        .HasForeignKey("DiplomWorkId");
                });

            modelBuilder.Entity("DiplomContentSystem.Core.StageComment", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Comment", "Comment")
                        .WithMany("StageComments")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Stage", "Stage")
                        .WithMany("StageComments")
                        .HasForeignKey("StageId")
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

            modelBuilder.Entity("DiplomContentSystem.Core.Teacher", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("SpecialityId")
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

            modelBuilder.Entity("DiplomContentSystem.Core.TeacherPosition", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.Period", "Period")
                        .WithMany("TeacherPositions")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Teacher", "Teacher")
                        .WithMany("TeacherPositions")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
