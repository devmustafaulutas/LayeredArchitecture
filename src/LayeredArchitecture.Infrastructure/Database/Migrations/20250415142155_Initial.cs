using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayeredArchitecture.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Time = table.Column<int>(type: "integer", nullable: false),
                    Quota = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlannedCourses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedCourseSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    plannedCourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedCourseSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedCourseSessions_PlannedCourses_plannedCourseId",
                        column: x => x.plannedCourseId,
                        principalTable: "PlannedCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedCourseSessionDiscontinuities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    discontinuity = table.Column<bool>(type: "boolean", nullable: false),
                    plannedCourseStudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlannedCourseSessionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedCourseSessionDiscontinuities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedCourseSessionDiscontinuities_PlannedCourseSessions_P~",
                        column: x => x.PlannedCourseSessionId,
                        principalTable: "PlannedCourseSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlannedCourseStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    studentId = table.Column<Guid>(type: "uuid", nullable: false),
                    plannedCourseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedCourseStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlannedCourseStudents_PlannedCourses_plannedCourseId",
                        column: x => x.plannedCourseId,
                        principalTable: "PlannedCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nameSurname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    parentNameSurname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    parentPhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    StudentPaymentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudentPayments_StudentPaymentId",
                        column: x => x.StudentPaymentId,
                        principalTable: "StudentPayments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourses_CourseId",
                table: "PlannedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourseSessionDiscontinuities_PlannedCourseSessionId",
                table: "PlannedCourseSessionDiscontinuities",
                column: "PlannedCourseSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourseSessionDiscontinuities_plannedCourseStudentId",
                table: "PlannedCourseSessionDiscontinuities",
                column: "plannedCourseStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourseSessions_plannedCourseId",
                table: "PlannedCourseSessions",
                column: "plannedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourseStudents_plannedCourseId",
                table: "PlannedCourseStudents",
                column: "plannedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourseStudents_studentId",
                table: "PlannedCourseStudents",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPayments_StudentId",
                table: "StudentPayments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentPaymentId",
                table: "Students",
                column: "StudentPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedCourseSessionDiscontinuities_PlannedCourseStudents_p~",
                table: "PlannedCourseSessionDiscontinuities",
                column: "plannedCourseStudentId",
                principalTable: "PlannedCourseStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedCourseStudents_Students_studentId",
                table: "PlannedCourseStudents",
                column: "studentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPayments_Students_StudentId",
                table: "StudentPayments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentPayments_Students_StudentId",
                table: "StudentPayments");

            migrationBuilder.DropTable(
                name: "PlannedCourseSessionDiscontinuities");

            migrationBuilder.DropTable(
                name: "PlannedCourseSessions");

            migrationBuilder.DropTable(
                name: "PlannedCourseStudents");

            migrationBuilder.DropTable(
                name: "PlannedCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentPayments");
        }
    }
}
