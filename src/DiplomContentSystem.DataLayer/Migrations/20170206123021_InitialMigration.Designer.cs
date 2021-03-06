﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DiplomContentSystem.DataLayer;

namespace DiplomContentSystem.DataLayer.Migrations
{
    [DbContext(typeof(DiplomContext))]
    [Migration("20170206123021_InitialMigration")]
    partial class InitialMigration
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

                    b.Property<int>("SpecialityId");

                    b.HasKey("Id");

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

            modelBuilder.Entity("DiplomContentSystem.Core.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiplomWorkId");

                    b.Property<string>("FIO");

                    b.Property<int>("GroupId");

                    b.HasKey("Id");

                    b.HasIndex("DiplomWorkId");

                    b.HasIndex("GroupId");

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

                    b.Property<string>("FIO");

                    b.Property<int>("MaxWorkCount");

                    b.Property<string>("Position");

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
                    b.HasOne("DiplomContentSystem.Core.Speciality", "Speciality")
                        .WithMany("Groups")
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
                    b.HasOne("DiplomContentSystem.Core.Institute", "Institute")
                        .WithMany("Specialties")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DiplomContentSystem.Core.Student", b =>
                {
                    b.HasOne("DiplomContentSystem.Core.DiplomWork", "DiplomWork")
                        .WithMany("Students")
                        .HasForeignKey("DiplomWorkId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DiplomContentSystem.Core.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("DiplomContentSystem.Core.Speciality", "Speciality")
                        .WithMany("Teachers")
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
        }
    }
}
