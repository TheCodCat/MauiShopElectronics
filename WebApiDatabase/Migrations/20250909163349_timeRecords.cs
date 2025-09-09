using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiDatabase.Migrations
{
    /// <inheritdoc />
    public partial class timeRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOnly",
                table: "Records",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOnly",
                table: "Records");
        }
    }
}
