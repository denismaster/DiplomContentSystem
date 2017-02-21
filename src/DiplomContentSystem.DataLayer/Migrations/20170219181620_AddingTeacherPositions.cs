using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class AddingTeacherPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeachersPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersPositions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "TeachersPositions");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Teachers",
                nullable: true);
        }
    }
}
