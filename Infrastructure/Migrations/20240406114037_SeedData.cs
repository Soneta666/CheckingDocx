using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Шрифт" },
                    { 2L, "Розмір шрифту" },
                    { 3L, "Вирівняти" }
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Name", "RequirementId" },
                values: new object[,]
                {
                    { 1L, "Times New Roman", 1L },
                    { 2L, "Arial", 1L },
                    { 3L, "MS Sans Serif", 1L },
                    { 4L, "10", 2L },
                    { 5L, "11", 2L },
                    { 6L, "12", 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Requirements",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Requirements",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Requirements",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
