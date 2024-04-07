using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserting initial data
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Name", "City" },
                values: new object[,]
                {
                    { "SSAU", "Samara" },
                    { "SamGTU", "Samara" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Name", "Surname" },
                values: new object[,]
                {
                    { "Ivan", "Ivanov" },
                    { "Petr", "Petrov" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Name", "UniversityId" },
                values: new object[,]
                {
                    { "First", 1 },
                    { "First", 2 },
                    { "Second", 1 },
                    { "Second", 2 }
                });

            migrationBuilder.InsertData(
                table: "UniversityStudents",
                columns: new[] { "UniversityId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupStudents",
                columns: new[] { "GroupId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Universities", "Name", "SSAU");
            migrationBuilder.DeleteData("Universities", "Name", "SamGTU");
            migrationBuilder.DeleteData("Students", "Name", "Ivan");
            migrationBuilder.DeleteData("Students", "Name", "Petr");
            migrationBuilder.DeleteData("Groups", "Name", "First");
            migrationBuilder.DeleteData("Groups", "Name", "Second");
            migrationBuilder.DeleteData("UniversityStudents", "UniversityId", 1);
            migrationBuilder.DeleteData("UniversityStudents", "UniversityId", 2);
            migrationBuilder.DeleteData("GroupStudents", "GroupId", 1);
            migrationBuilder.DeleteData("GroupStudents", "GroupId", 2);
            migrationBuilder.DeleteData("GroupStudents", "GroupId", 3);
            migrationBuilder.DeleteData("GroupStudents", "GroupId", 4);
        }
    }
}
