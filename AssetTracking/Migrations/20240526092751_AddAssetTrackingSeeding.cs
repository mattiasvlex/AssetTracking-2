using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssetTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetTrackingSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Location", "Currency", "ToUSD" },
                values: new object[,]
                {
                    { "Denmark", "DKK", 6.88m },
                    { "Sweden", "SEK", 10.68m },
                    { "USA", "USD", 1.0m }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Brand", "Date", "Model", "OfficeLocation", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "ASUS ROG", new DateOnly(2020, 11, 24), "B550-F", "Sweden", 950, "Computer" },
                    { 2, "HP", new DateOnly(2023, 1, 30), "14S-FQ1010NO", "Denmark", 679, "Computer" },
                    { 3, "Samsung", new DateOnly(2022, 9, 12), "S20 Plus", "USA", 700, "Phone" },
                    { 4, "Sony Xperia", new DateOnly(2021, 3, 6), "10 III", "Sweden", 800, "Phone" },
                    { 5, "Iphone", new DateOnly(2018, 11, 25), "10", "Denmark", 750, "Phone" },
                    { 6, "HP", new DateOnly(2023, 8, 30), "Elitebook", "USA", 1530, "Computer" },
                    { 7, "HP", new DateOnly(2021, 7, 6), "Elitebook", "Sweden", 1640, "Computer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Location",
                keyValue: "Denmark");

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Location",
                keyValue: "Sweden");

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Location",
                keyValue: "USA");
        }
    }
}
