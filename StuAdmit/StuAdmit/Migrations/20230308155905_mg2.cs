using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StuAdmit.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(nullable: false),
                    Course_fees = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_Id);
                });

            migrationBuilder.CreateTable(
                name: "Registaration",
                columns: table => new
                {
                    Student_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(maxLength: 20, nullable: false),
                    gender = table.Column<string>(nullable: false),
                    contact_number = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(maxLength: 20, nullable: false),
                    confirmpassword = table.Column<string>(nullable: false),
                    usertype = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registaration", x => x.Student_Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Admission_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admission_date = table.Column<DateTime>(nullable: false),
                    Student_Id = table.Column<int>(nullable: false),
                    Course_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Admission_Id);
                    table.ForeignKey(
                        name: "FK_Admin_Course_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Course",
                        principalColumn: "Course_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_Registaration_Student_Id",
                        column: x => x.Student_Id,
                        principalTable: "Registaration",
                        principalColumn: "Student_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Course_Id",
                table: "Admin",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Student_Id",
                table: "Admin",
                column: "Student_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Registaration");
        }
    }
}
