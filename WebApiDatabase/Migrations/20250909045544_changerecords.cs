using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDatabase.Migrations
{
    /// <inheritdoc />
    public partial class changerecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductRecordsBytes",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "ProductRecords",
                table: "Records",
                newName: "ProductRecordsJson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductRecordsJson",
                table: "Records",
                newName: "ProductRecords");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductRecordsBytes",
                table: "Records",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
