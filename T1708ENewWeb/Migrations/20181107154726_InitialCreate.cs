using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T1708ENewWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    RollNumber = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.RollNumber);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(nullable: true),
                    SubjectMark = table.Column<int>(nullable: false),
                    StudentRollNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_Student_StudentRollNumber",
                        column: x => x.StudentRollNumber,
                        principalTable: "Student",
                        principalColumn: "RollNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A001", new DateTime(2018, 11, 7, 22, 47, 25, 431, DateTimeKind.Local), "tinhgiang9898@gmail.com", "Giang", "Tinh", 0, new DateTime(2018, 11, 7, 22, 47, 25, 432, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A002", new DateTime(2018, 11, 7, 22, 47, 25, 433, DateTimeKind.Local), "ly@gmail.com", "Huong", "Ly", 0, new DateTime(2018, 11, 7, 22, 47, 25, 433, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "RollNumber", "CreatedAt", "Email", "FirstName", "LastName", "Status", "UpdatedAt" },
                values: new object[] { "A003", new DateTime(2018, 11, 7, 22, 47, 25, 433, DateTimeKind.Local), "thanhtung@gmail.com", "Thanh", "Tung", 0, new DateTime(2018, 11, 7, 22, 47, 25, 433, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 1, "A001", 20, "Java" });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 2, "A002", 20, "C#" });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "Id", "StudentRollNumber", "SubjectMark", "SubjectName" },
                values: new object[] { 3, "A003", 20, "PHP" });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentRollNumber",
                table: "Mark",
                column: "StudentRollNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
