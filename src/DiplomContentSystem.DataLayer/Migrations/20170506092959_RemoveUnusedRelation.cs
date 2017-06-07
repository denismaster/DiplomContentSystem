using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class RemoveUnusedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubImplementationStages_DiplomWorks_DiplomWorkId",
                table: "SubImplementationStages");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImplementationStages_ImplementationStages_ImplementationStageId",
                table: "SubImplementationStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubImplementationStages",
                table: "SubImplementationStages");

            migrationBuilder.DropIndex(
                name: "IX_SubImplementationStages_ImplementationStageId",
                table: "SubImplementationStages");

            migrationBuilder.DropColumn(
                name: "ImplementationStageId",
                table: "SubImplementationStages");

            migrationBuilder.RenameTable(
                name: "SubImplementationStages",
                newName: "CustomStages");

            migrationBuilder.RenameIndex(
                name: "IX_SubImplementationStages_DiplomWorkId",
                table: "CustomStages",
                newName: "IX_CustomStages_DiplomWorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomStages",
                table: "CustomStages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomStages_DiplomWorks_DiplomWorkId",
                table: "CustomStages",
                column: "DiplomWorkId",
                principalTable: "DiplomWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomStages_DiplomWorks_DiplomWorkId",
                table: "CustomStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomStages",
                table: "CustomStages");

            migrationBuilder.RenameTable(
                name: "CustomStages",
                newName: "SubImplementationStages");

            migrationBuilder.RenameIndex(
                name: "IX_CustomStages_DiplomWorkId",
                table: "SubImplementationStages",
                newName: "IX_SubImplementationStages_DiplomWorkId");

            migrationBuilder.AddColumn<int>(
                name: "ImplementationStageId",
                table: "SubImplementationStages",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubImplementationStages",
                table: "SubImplementationStages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubImplementationStages_ImplementationStageId",
                table: "SubImplementationStages",
                column: "ImplementationStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubImplementationStages_DiplomWorks_DiplomWorkId",
                table: "SubImplementationStages",
                column: "DiplomWorkId",
                principalTable: "DiplomWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImplementationStages_ImplementationStages_ImplementationStageId",
                table: "SubImplementationStages",
                column: "ImplementationStageId",
                principalTable: "ImplementationStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
