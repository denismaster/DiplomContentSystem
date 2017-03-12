using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class ChangeImplementationStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiplomWorks_Teachers_TeacherId",
                table: "DiplomWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "ImplementationStageComments");

            migrationBuilder.DropTable(
                name: "SubImplementationStageComments");

            migrationBuilder.DropTable(
                name: "SubImplementationStages");

            migrationBuilder.DropTable(
                name: "ImplementationStages");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "MaxWorkCount",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "MaxWorkCount",
                table: "TeachersPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "TeachersPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TeachersPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "DiplomWorks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    DiplomWorkId = table.Column<int>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_DiplomWorks_DiplomWorkId",
                        column: x => x.DiplomWorkId,
                        principalTable: "DiplomWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StageComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    StageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StageComments_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachersPositions_PeriodId",
                table: "TeachersPositions",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersPositions_TeacherId",
                table: "TeachersPositions",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_DiplomWorkId",
                table: "Stages",
                column: "DiplomWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_StageComments_CommentId",
                table: "StageComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_StageComments_StageId",
                table: "StageComments",
                column: "StageId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiplomWorks_Teachers_TeacherId",
                table: "DiplomWorks",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersPositions_Periods_PeriodId",
                table: "TeachersPositions",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeachersPositions_Teachers_TeacherId",
                table: "TeachersPositions",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiplomWorks_Teachers_TeacherId",
                table: "DiplomWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersPositions_Periods_PeriodId",
                table: "TeachersPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeachersPositions_Teachers_TeacherId",
                table: "TeachersPositions");

            migrationBuilder.DropTable(
                name: "StageComments");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_TeachersPositions_PeriodId",
                table: "TeachersPositions");

            migrationBuilder.DropIndex(
                name: "IX_TeachersPositions_TeacherId",
                table: "TeachersPositions");

            migrationBuilder.DropColumn(
                name: "MaxWorkCount",
                table: "TeachersPositions");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "TeachersPositions");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeachersPositions");

            migrationBuilder.AddColumn<int>(
                name: "MaxWorkCount",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "DiplomWorks",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "ImplementationStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DiplomWorkId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImplementationStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImplementationStages_DiplomWorks_DiplomWorkId",
                        column: x => x.DiplomWorkId,
                        principalTable: "DiplomWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "SubImplementationStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImplementationStageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubImplementationStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubImplementationStages_ImplementationStages_ImplementationStageId",
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
                name: "IX_Teachers_PositionId",
                table: "Teachers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStages_DiplomWorkId",
                table: "ImplementationStages",
                column: "DiplomWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStageComments_CommentId",
                table: "ImplementationStageComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ImplementationStageComments_ImplementationStageId",
                table: "ImplementationStageComments",
                column: "ImplementationStageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImplementationStages_ImplementationStageId",
                table: "SubImplementationStages",
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
                name: "FK_DiplomWorks_Teachers_TeacherId",
                table: "DiplomWorks",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
