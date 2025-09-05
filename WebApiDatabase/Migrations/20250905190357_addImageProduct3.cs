using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDatabase.Migrations
{
    /// <inheritdoc />
    public partial class addImageProduct3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Products",
                newName: "ProductRecordsBytes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductRecordsBytes",
                table: "Products",
                newName: "ImageURL");
        }
    }
}
