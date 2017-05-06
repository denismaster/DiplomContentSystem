using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class CalendarChangesAndCommentsRedone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubImplementationStages_ImplementationStages_ImplementationStageId",
                table: "SubImplementationStages");

            migrationBuilder.DropTable(
                name: "ImplementationStageComments");

            migrationBuilder.DropTable(
                name: "SubImplementationStageComments");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ImplementationStages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ImplementationStages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ImplementationStages");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "SubImplementationStages",
                newName: "StartDate");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "ImplementationStages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GlobalStageId",
                table: "ImplementationStages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ImplementationStageId",
                table: "SubImplementationStages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "SubImplementationStages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DiplomWorkId",
                table: "SubImplementationStages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "SubImplementationStages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GlobalStage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalStage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStages_GlobalStageId",
                table: "ImplementationStages",
                column: "GlobalStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImplementationStages_DiplomWorkId",
                table: "SubImplementationStages",
                column: "DiplomWorkId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ImplementationStages_GlobalStage_GlobalStageId",
                table: "ImplementationStages",
                column: "GlobalStageId",
                principalTable: "GlobalStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubImplementationStages_DiplomWorks_DiplomWorkId",
                table: "SubImplementationStages");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImplementationStages_ImplementationStages_ImplementationStageId",
                table: "SubImplementationStages");

            migrationBuilder.DropForeignKey(
                name: "FK_ImplementationStages_GlobalStage_GlobalStageId",
                table: "ImplementationStages");

            migrationBuilder.DropTable(
                name: "GlobalStage");

            migrationBuilder.DropIndex(
                name: "IX_ImplementationStages_GlobalStageId",
                table: "ImplementationStages");

            migrationBuilder.DropIndex(
                name: "IX_SubImplementationStages_DiplomWorkId",
                table: "SubImplementationStages");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "ImplementationStages");

            migrationBuilder.DropColumn(
                name: "GlobalStageId",
                table: "ImplementationStages");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "SubImplementationStages");

            migrationBuilder.DropColumn(
                name: "DiplomWorkId",
                table: "SubImplementationStages");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "SubImplementationStages");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "SubImplementationStages",
                newName: "Date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ImplementationStages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ImplementationStages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ImplementationStages",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImplementationStageId",
                table: "SubImplementationStages",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ImplementationStageComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    ImplementationStageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplementationStageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImplementationStageComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImplementationStageComments_ImplementationStages_ImplementationStageId",
                        column: x => x.ImplementationStageId,
                        principalTable: "ImplementationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubImplementationStageComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    SubImplementationStageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubImplementationStageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubImplementationStageComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubImplementationStageComments_SubImplementationStages_SubImplementationStageId",
                        column: x => x.SubImplementationStageId,
                        principalTable: "SubImplementationStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStageComments_CommentId",
                table: "ImplementationStageComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStageComments_ImplementationStageId",
                table: "ImplementationStageComments",
                column: "ImplementationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImplementationStageComments_CommentId",
                table: "SubImplementationStageComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImplementationStageComments_SubImplementationStageId",
                table: "SubImplementationStageComments",
                column: "SubImplementationStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubImplementationStages_ImplementationStages_ImplementationStageId",
                table: "SubImplementationStages",
                column: "ImplementationStageId",
                principalTable: "ImplementationStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
