using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class patrones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnNumber",
                table: "Sector",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Sector",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosX",
                table: "Sector",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosY",
                table: "Sector",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RowNumber",
                table: "Sector",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Sector",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosX",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosY",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnNumber",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "RowNumber",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Sector");

            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Seat");
        }
    }
}
