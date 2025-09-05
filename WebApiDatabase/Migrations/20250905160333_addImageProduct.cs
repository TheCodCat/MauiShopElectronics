using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDatabase.Migrations
{
    /// <inheritdoc />
    public partial class addImageProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProductRecordsBytes",
                table: "Records",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductRecordsBytes",
                table: "Records");
        }
    }
}
