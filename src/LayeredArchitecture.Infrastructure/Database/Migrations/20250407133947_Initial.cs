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
                name: "studentPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    paymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentPayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    nameSurname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    parentNameSurname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    parentPhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
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
                name: "StudentStudentPayment",
                columns: table => new
                {
                    studentPaymentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    studentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentPayment", x => new { x.studentPaymentsId, x.studentsId });
                    table.ForeignKey(
                        name: "FK_StudentStudentPayment_studentPayments_studentPaymentsId",
                        column: x => x.studentPaymentsId,
                        principalTable: "studentPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentPayment_students_studentsId",
                        column: x => x.studentsId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plannedCourseSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    plannedCourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    dateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plannedCourseSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plannedCourseSessions_PlannedCourses_plannedCourseId",
                        column: x => x.plannedCourseId,
                        principalTable: "PlannedCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "plannedCourseSessionDiscontinuities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    discontinuity = table.Column<bool>(type: "boolean", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlannedCourseSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlannedCourseSessionId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plannedCourseSessionDiscontinuities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plannedCourseSessionDiscontinuities_plannedCourseSessions_P~",
                        column: x => x.PlannedCourseSessionId,
                        principalTable: "plannedCourseSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_plannedCourseSessionDiscontinuities_plannedCourseSessions_~1",
                        column: x => x.PlannedCourseSessionId1,
                        principalTable: "plannedCourseSessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_plannedCourseSessionDiscontinuities_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlannedCourses_CourseId",
                table: "PlannedCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_plannedCourseSessionDiscontinuities_PlannedCourseSessionId",
                table: "plannedCourseSessionDiscontinuities",
                column: "PlannedCourseSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_plannedCourseSessionDiscontinuities_PlannedCourseSessionId1",
                table: "plannedCourseSessionDiscontinuities",
                column: "PlannedCourseSessionId1");

            migrationBuilder.CreateIndex(
                name: "IX_plannedCourseSessionDiscontinuities_StudentId_PlannedCourse~",
                table: "plannedCourseSessionDiscontinuities",
                columns: new[] { "StudentId", "PlannedCourseSessionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_plannedCourseSessions_plannedCourseId",
                table: "plannedCourseSessions",
                column: "plannedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentPayment_studentsId",
                table: "StudentStudentPayment",
                column: "studentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plannedCourseSessionDiscontinuities");

            migrationBuilder.DropTable(
                name: "StudentStudentPayment");

            migrationBuilder.DropTable(
                name: "plannedCourseSessions");

            migrationBuilder.DropTable(
                name: "studentPayments");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "PlannedCourses");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
