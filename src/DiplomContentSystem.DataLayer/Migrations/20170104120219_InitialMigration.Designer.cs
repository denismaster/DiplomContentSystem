using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DiplomContentSystem.DataLayer;

namespace DiplomContentSystem.DataLayer.Migrations
{
    [DbContext(typeof(DiplomContext))]
    [Migration("20170104120219_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("DiplomContentSystem.Core.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FIO");

                    b.Property<int>("MaxWorkCount");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });
        }
    }
}
