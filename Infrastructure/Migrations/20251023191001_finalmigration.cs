using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class finalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Sector_ControlledSector",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "SectorType",
                table: "Sector");

            migrationBuilder.RenameColumn(
                name: "ControlledSector",
                table: "Sector",
                newName: "IsControlled");

            migrationBuilder.RenameColumn(
                name: "ControlledSector",
                table: "Seat",
                newName: "SectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ControlledSector",
                table: "Seat",
                newName: "IX_Seat_SectorId");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Venue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MapUrl",
                table: "Venue",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "SeatCount",
                table: "Sector",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Sector",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SectorId1",
                table: "Seat",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "VenueType",
                columns: new[] { "VenueTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Stadium" },
                    { 2, "Theater" },
                    { 3, "Field" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SectorId1",
                table: "Seat",
                column: "SectorId1",
                unique: true,
                filter: "[SectorId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Sector_SectorId",
                table: "Seat",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Sector_SectorId1",
                table: "Seat",
                column: "SectorId1",
                principalTable: "Sector",
                principalColumn: "SectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Sector_SectorId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Sector_SectorId1",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_SectorId1",
                table: "Seat");

            migrationBuilder.DeleteData(
                table: "VenueType",
                keyColumn: "VenueTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VenueType",
                keyColumn: "VenueTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VenueType",
                keyColumn: "VenueTypeId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "MapUrl",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "SectorId1",
                table: "Seat");

            migrationBuilder.RenameColumn(
                name: "IsControlled",
                table: "Sector",
                newName: "ControlledSector");

            migrationBuilder.RenameColumn(
                name: "SectorId",
                table: "Seat",
                newName: "ControlledSector");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SectorId",
                table: "Seat",
                newName: "IX_Seat_ControlledSector");

            migrationBuilder.AlterColumn<long>(
                name: "SeatCount",
                table: "Sector",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Capacity",
                table: "Sector",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectorType",
                table: "Sector",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Sector_ControlledSector",
                table: "Seat",
                column: "ControlledSector",
                principalTable: "Sector",
                principalColumn: "SectorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
