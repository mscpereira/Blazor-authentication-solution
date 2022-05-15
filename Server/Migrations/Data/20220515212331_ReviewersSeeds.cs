using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations.Data
{
    public partial class ReviewersSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Reviewers",
              columns: new[] { "Id", "FirstName", "LastName", "BirthDate", "Email", "Avatar", "JoinedDate" },
              values: new object[] { 1, "Mário", "Pereira", new DateTime(1990, 7, 4), "mario@gmail.com", "", new DateTime(2022, 1, 1) });

            migrationBuilder.InsertData(
               table: "Reviewers",
               columns: new[] { "Id", "FirstName", "LastName", "BirthDate", "Email", "Avatar", "JoinedDate" },
               values: new object[] { 2, "Ana", "Serrano", new DateTime(1990, 3, 7), "ana@gmail.com", "", new DateTime(2022, 2, 23) });

            migrationBuilder.InsertData(
                table: "Reviewers",
               columns: new[] { "Id", "FirstName", "LastName", "BirthDate", "Email", "Avatar", "JoinedDate" },
               values: new object[] { 3, "Ana", "Maia", new DateTime(1989, 12, 14), "maia@gmail.com", "", new DateTime(2022, 3, 1) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
