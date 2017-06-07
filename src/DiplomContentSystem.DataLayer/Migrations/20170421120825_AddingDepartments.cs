using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class AddingDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Institutes_InstituteId",
                table: "Specialities");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Specialities_SpecialityId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "Teachers",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_SpecialityId",
                table: "Teachers",
                newName: "IX_Teachers_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "InstituteId",
                table: "Specialities",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialities_InstituteId",
                table: "Specialities",
                newName: "IX_Specialities_DepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Groups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InstituteId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PeriodId",
                table: "Groups",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstituteId",
                table: "Departments",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Periods_PeriodId",
                table: "Groups",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Departments_DepartmentId",
                table: "Specialities",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Periods_PeriodId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Departments_DepartmentId",
                table: "Specialities");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Departments_DepartmentId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Groups_PeriodId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Teachers",
                newName: "SpecialityId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                newName: "IX_Teachers_SpecialityId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Specialities",
                newName: "InstituteId");

            migrationBuilder.RenameIndex(
                name: "IX_Specialities_DepartmentId",
                table: "Specialities",
                newName: "IX_Specialities_InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Institutes_InstituteId",
                table: "Specialities",
                column: "InstituteId",
                principalTable: "Institutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Specialities_SpecialityId",
                table: "Teachers",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
