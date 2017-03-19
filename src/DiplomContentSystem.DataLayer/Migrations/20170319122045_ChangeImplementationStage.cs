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

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Teachers",
                newName: "TeacherPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers",
                newName: "IX_Teachers_TeacherPositionId");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Teachers",
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
                name: "IX_Teachers_PeriodId",
                table: "Teachers",
                column: "PeriodId");

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
                name: "FK_Teachers_Periods_PeriodId",
                table: "Teachers",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeachersPositions_TeacherPositionId",
                table: "Teachers",
                column: "TeacherPositionId",
                principalTable: "TeachersPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiplomWorks_Teachers_TeacherId",
                table: "DiplomWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Periods_PeriodId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeachersPositions_TeacherPositionId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "StageComments");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PeriodId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "TeacherPositionId",
                table: "Teachers",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_TeacherPositionId",
                table: "Teachers",
                newName: "IX_Teachers_PositionId");

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
