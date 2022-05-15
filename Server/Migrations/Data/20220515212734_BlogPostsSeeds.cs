using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations.Data
{
    public partial class BlogPostsSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Url", "Title", "Restaurant", "City", "Country", "Diet", "Latitude", "Longitude", "Description", "ReviewerId", "Image", "Rating", "DateCreated", "IsPublished", "IsDeleted" },
                values: new object[] { 1, "brunch-dos-amigos", "Our first review", "Brunch dos Amigos", "Lisboa", "Portugal", "General", 0.00, 0.00, "Our first review. This one comes from the DB. Amazing restaurant.", 1, "", "5", new DateTime(2022, 1, 15), true, false });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Url", "Title", "Restaurant", "City", "Country", "Diet", "Latitude", "Longitude", "Description", "ReviewerId", "Image", "Rating", "DateCreated", "IsPublished", "IsDeleted" },
                values: new object[] { 2, "brunch-for-us", "Our second review", "Brunch for Us", "Lisboa", "Portugal", "General", 0.00, 0.00, "Our second review. This one comes from the DB just like the first one. The worst brunch ever. Cold food!", 3, "", "1", new DateTime(2022, 3, 2), true, false });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Url", "Title", "Restaurant", "City", "Country", "Diet", "Latitude", "Longitude", "Description", "ReviewerId", "Image", "Rating", "DateCreated", "IsPublished", "IsDeleted" },
                values: new object[] { 3, "brunch-for-lunch", "Our last review", "Brunch for Lunch", "Almada", "Portugal", "Vegan", 0.00, 0.00, "Our last review. This one comes from the DB too. Taste like grass....Not that good", 2, "", "3", new DateTime(2022, 2, 27), true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
