using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class ChangeStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_DiplomWorks_DiplomWorkId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "DiplomWorkId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeacherId",
                table: "Students",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_DiplomWorks_DiplomWorkId",
                table: "Students",
                column: "DiplomWorkId",
                principalTable: "DiplomWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_DiplomWorks_DiplomWorkId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teachers_TeacherId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeacherId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiplomWorkId",
                table: "Students",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_DiplomWorks_DiplomWorkId",
                table: "Students",
                column: "DiplomWorkId",
                principalTable: "DiplomWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
