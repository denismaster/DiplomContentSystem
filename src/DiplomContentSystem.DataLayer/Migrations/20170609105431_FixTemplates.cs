using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class FixTemplates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Template_TemplateType_TemplateTypeId",
                table: "Template");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateType",
                table: "TemplateType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Template",
                table: "Template");

            migrationBuilder.RenameTable(
                name: "TemplateType",
                newName: "TemplateTypes");

            migrationBuilder.RenameTable(
                name: "Template",
                newName: "Templates");

            migrationBuilder.RenameIndex(
                name: "IX_Template_TemplateTypeId",
                table: "Templates",
                newName: "IX_Templates_TemplateTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateTypes",
                table: "TemplateTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Templates",
                table: "Templates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Templates_TemplateTypes_TemplateTypeId",
                table: "Templates",
                column: "TemplateTypeId",
                principalTable: "TemplateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Templates_TemplateTypes_TemplateTypeId",
                table: "Templates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateTypes",
                table: "TemplateTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Templates",
                table: "Templates");

            migrationBuilder.RenameTable(
                name: "TemplateTypes",
                newName: "TemplateType");

            migrationBuilder.RenameTable(
                name: "Templates",
                newName: "Template");

            migrationBuilder.RenameIndex(
                name: "IX_Templates_TemplateTypeId",
                table: "Template",
                newName: "IX_Template_TemplateTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateType",
                table: "TemplateType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Template",
                table: "Template",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Template_TemplateType_TemplateTypeId",
                table: "Template",
                column: "TemplateTypeId",
                principalTable: "TemplateType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
