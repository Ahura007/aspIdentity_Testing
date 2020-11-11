using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotin.HostApi.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDateTime", "NormalizedName" },
                values: new object[] { "dbbb77eb-7f3c-4de2-8700-e96e12f656e6", new DateTime(2020, 11, 10, 18, 7, 10, 906, DateTimeKind.Local).AddTicks(7185), "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreateDateTime", "NormalizedName" },
                values: new object[] { "53be72d2-8189-4729-8c68-6e9f90ce62c2", new DateTime(2020, 11, 10, 18, 7, 10, 906, DateTimeKind.Local).AddTicks(9023), "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp" },
                values: new object[] { new DateTime(1991, 11, 10, 18, 7, 10, 898, DateTimeKind.Local).AddTicks(3822), "33abe884-1d1a-45c1-9175-2c500926a4a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp" },
                values: new object[] { new DateTime(1985, 11, 10, 18, 7, 10, 904, DateTimeKind.Local).AddTicks(3713), "4fe59cad-35d3-4bd9-abd4-345d90ca04b4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreateDateTime", "NormalizedName" },
                values: new object[] { "ac051344-efd2-4722-82d3-613e10773b03", new DateTime(2020, 11, 10, 18, 3, 43, 580, DateTimeKind.Local).AddTicks(5692), null });

            migrationBuilder.UpdateData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreateDateTime", "NormalizedName" },
                values: new object[] { "0326884d-198a-4b9a-a732-3942fd601281", new DateTime(2020, 11, 10, 18, 3, 43, 580, DateTimeKind.Local).AddTicks(7016), null });

            migrationBuilder.UpdateData(
                table: "AspNetUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "ConcurrencyStamp" },
                values: new object[] { new DateTime(1991, 11, 10, 18, 3, 43, 572, DateTimeKind.Local).AddTicks(7503), "e16b79d5-fee2-4877-ac39-727763c0fd82" });

            migrationBuilder.UpdateData(
                table: "AspNetUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "ConcurrencyStamp" },
                values: new object[] { new DateTime(1985, 11, 10, 18, 3, 43, 577, DateTimeKind.Local).AddTicks(9879), "3a2f8a66-7f22-4943-86dd-d6214a251b11" });
        }
    }
}
