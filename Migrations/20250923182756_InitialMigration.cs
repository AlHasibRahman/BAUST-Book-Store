using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BAUST_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    book_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img_Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPrice = table.Column<double>(type: "float", nullable: false),
                    rentPrice = table.Column<double>(type: "float", nullable: false),
                    isAvilable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Description", "author_Name", "bookPrice", "book_Name", "condition", "edition", "img_Url", "isAvilable", "rentPrice" },
                values: new object[,]
                {
                    { 1, "Abcdefg-abcfged-abcdeg", "XYZ", 120.25, "Harry Poter", "Good", "4th edition", "Localhost://123.jpg", true, 25.25 },
                    { 2, "Abcdefg-abcfged-abcdeg", "XYZ", 120.25, "Harry Wolf", "Good", "4th edition", "Localhost://123.jpg", true, 25.25 },
                    { 3, "Abcdefg-abcfged-abcdeg", "XYZ", 120.25, "Harry Big", "Good", "4th edition", "Localhost://123.jpg", true, 25.25 },
                    { 4, "Abcdefg-abcfged-abcdeg", "XYZ", 120.25, "Harry Karl", "Good", "4th edition", "Localhost://123.jpg", true, 25.25 },
                    { 5, "Abcdefg-abcfged-abcdeg", "XYZ", 120.25, "Harry Gen", "Good", "4th edition", "Localhost://123.jpg", true, 25.25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
