using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PAFIAST_IMS.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignTask_IMS",
                columns: table => new
                {
                    ATId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tasks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stdinfoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignTask_IMS", x => x.ATId);
                    table.ForeignKey(
                        name: "FK_AssignTask_IMS_stdInfo_IMS_stdinfoid",
                        column: x => x.stdinfoid,
                        principalTable: "stdInfo_IMS",
                        principalColumn: "stdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyAdvisor_IMS",
                columns: table => new
                {
                    FAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyAdvisorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyAdvisorDept = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyAdvisorDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyAdvisorContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyAdvisorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stdinfoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyAdvisor_IMS", x => x.FAId);
                    table.ForeignKey(
                        name: "FK_FacultyAdvisor_IMS_stdInfo_IMS_stdinfoid",
                        column: x => x.stdinfoid,
                        principalTable: "stdInfo_IMS",
                        principalColumn: "stdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IEForm_IMS",
                columns: table => new
                {
                    IEFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stdinfoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IEForm_IMS", x => x.IEFId);
                    table.ForeignKey(
                        name: "FK_IEForm_IMS_stdInfo_IMS_stdinfoid",
                        column: x => x.stdinfoid,
                        principalTable: "stdInfo_IMS",
                        principalColumn: "stdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supervisor_IMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorIN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorDesignation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stdinfoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisor_IMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supervisor_IMS_stdInfo_IMS_stdinfoid",
                        column: x => x.stdinfoid,
                        principalTable: "stdInfo_IMS",
                        principalColumn: "stdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignTask_IMS_stdinfoid",
                table: "AssignTask_IMS",
                column: "stdinfoid");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyAdvisor_IMS_stdinfoid",
                table: "FacultyAdvisor_IMS",
                column: "stdinfoid");

            migrationBuilder.CreateIndex(
                name: "IX_IEForm_IMS_stdinfoid",
                table: "IEForm_IMS",
                column: "stdinfoid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supervisor_IMS_stdinfoid",
                table: "Supervisor_IMS",
                column: "stdinfoid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignTask_IMS");

            migrationBuilder.DropTable(
                name: "FacultyAdvisor_IMS");

            migrationBuilder.DropTable(
                name: "IEForm_IMS");

            migrationBuilder.DropTable(
                name: "Supervisor_IMS");
        }
    }
}
