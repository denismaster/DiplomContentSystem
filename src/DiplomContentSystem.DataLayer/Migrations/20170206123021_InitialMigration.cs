using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DiplomContentSystem.DataLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
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
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    InstituteId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Сode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialities_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FIO = table.Column<string>(nullable: true),
                    MaxWorkCount = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    SpecialityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiplomWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PeriodId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomWorks_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomWorks_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherComments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiplomWorkComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    DiplomWorkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomWorkComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomWorkComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomWorkComments_DiplomWorks_DiplomWorkId",
                        column: x => x.DiplomWorkId,
                        principalTable: "DiplomWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DiplomWorkId = table.Column<int>(nullable: false),
                    FIO = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_DiplomWorks_DiplomWorkId",
                        column: x => x.DiplomWorkId,
                        principalTable: "DiplomWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
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
                name: "DiplomWorkMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true),
                    DiplomWorkId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomWorkMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomWorkMaterials_Students_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomWorkMaterials_DiplomWorks_DiplomWorkId",
                        column: x => x.DiplomWorkId,
                        principalTable: "DiplomWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentComments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
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

            migrationBuilder.CreateTable(
                name: "DiplomWorkMaterialComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    DiplomWorkMaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiplomWorkMaterialComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiplomWorkMaterialComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiplomWorkMaterialComments_DiplomWorkMaterials_DiplomWorkMaterialId",
                        column: x => x.DiplomWorkMaterialId,
                        principalTable: "DiplomWorkMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GostControlTries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DiplomWorkMaterialId = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    Result = table.Column<bool>(nullable: false),
                    Сontroller = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GostControlTries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GostControlTries_DiplomWorkMaterials_DiplomWorkMaterialId",
                        column: x => x.DiplomWorkMaterialId,
                        principalTable: "DiplomWorkMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GostControlTryComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CommentId = table.Column<int>(nullable: false),
                    GostControlTryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GostControlTryComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GostControlTryComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GostControlTryComments_GostControlTries_GostControlTryId",
                        column: x => x.GostControlTryId,
                        principalTable: "GostControlTries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorks_PeriodId",
                table: "DiplomWorks",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorks_TeacherId",
                table: "DiplomWorks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorkComments_CommentId",
                table: "DiplomWorkComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorkComments_DiplomWorkId",
                table: "DiplomWorkComments",
                column: "DiplomWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorkMaterials_AuthorId",
                table: "DiplomWorkMaterials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorkMaterials_DiplomWorkId",
                table: "DiplomWorkMaterials",
                column: "DiplomWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorkMaterialComments_CommentId",
                table: "DiplomWorkMaterialComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_DiplomWorkMaterialComments_DiplomWorkMaterialId",
                table: "DiplomWorkMaterialComments",
                column: "DiplomWorkMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_GostControlTries_DiplomWorkMaterialId",
                table: "GostControlTries",
                column: "DiplomWorkMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_GostControlTryComments_CommentId",
                table: "GostControlTryComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_GostControlTryComments_GostControlTryId",
                table: "GostControlTryComments",
                column: "GostControlTryId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SpecialityId",
                table: "Groups",
                column: "SpecialityId");

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
                name: "IX_Specialities_InstituteId",
                table: "Specialities",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DiplomWorkId",
                table: "Students",
                column: "DiplomWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentComments_CommentId",
                table: "StudentComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentComments_StudentId",
                table: "StudentComments",
                column: "StudentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SpecialityId",
                table: "Teachers",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherComments_CommentId",
                table: "TeacherComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherComments_TeacherId",
                table: "TeacherComments",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiplomWorkComments");

            migrationBuilder.DropTable(
                name: "DiplomWorkMaterialComments");

            migrationBuilder.DropTable(
                name: "GostControlTryComments");

            migrationBuilder.DropTable(
                name: "ImplementationStageComments");

            migrationBuilder.DropTable(
                name: "StudentComments");

            migrationBuilder.DropTable(
                name: "SubImplementationStageComments");

            migrationBuilder.DropTable(
                name: "TeacherComments");

            migrationBuilder.DropTable(
                name: "GostControlTries");

            migrationBuilder.DropTable(
                name: "SubImplementationStages");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DiplomWorkMaterials");

            migrationBuilder.DropTable(
                name: "ImplementationStages");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "DiplomWorks");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}
