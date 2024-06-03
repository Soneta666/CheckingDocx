using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GetSearch = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequirementId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Values_Requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Requirements",
                columns: new[] { "Id", "GetSearch", "Name" },
                values: new object[,]
                {
                    { 1L, "FontFamily", "Шрифт" },
                    { 2L, "Size", "Розмір шрифту" },
                    { 3L, "Size", "Вирівняти" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Values_RequirementId",
                table: "Values",
                column: "RequirementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Requirements");
        }
    }
}
