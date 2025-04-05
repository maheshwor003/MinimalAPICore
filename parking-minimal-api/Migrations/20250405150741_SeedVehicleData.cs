using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace parking_minimal_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "parkingapi",
                table: "Vehicles",
                columns: new[] { "Id", "Color", "LicensePlate", "Make", "Model", "ParkingDate" },
                values: new object[,]
                {
                    { new Guid("446b86c0-8b5f-4a3a-9f7a-e02569c0d70e"), "Blue", "AB123CD", "Toyota", "Corolla", new DateTime(2023, 1, 1, 10, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("74ed1641-5568-4a27-b3e1-159be61daebe"), "Blue", "AB123CD", "Toyota", "Corolla", new DateTime(2023, 1, 1, 10, 30, 0, 0, DateTimeKind.Utc) },
                    { new Guid("84c3a691-81e6-49ad-8ecc-9a1ff59c334f"), "Red", "XY987ZT", "Honda", "Civic", new DateTime(2023, 2, 1, 15, 45, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f1f0d8e4-d285-4cc5-9038-8964c1726dd2"), "Red", "XY987ZT", "Honda", "Civic", new DateTime(2023, 2, 1, 15, 45, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "parkingapi",
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("446b86c0-8b5f-4a3a-9f7a-e02569c0d70e"));

            migrationBuilder.DeleteData(
                schema: "parkingapi",
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("74ed1641-5568-4a27-b3e1-159be61daebe"));

            migrationBuilder.DeleteData(
                schema: "parkingapi",
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("84c3a691-81e6-49ad-8ecc-9a1ff59c334f"));

            migrationBuilder.DeleteData(
                schema: "parkingapi",
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f1f0d8e4-d285-4cc5-9038-8964c1726dd2"));
        }
    }
}
