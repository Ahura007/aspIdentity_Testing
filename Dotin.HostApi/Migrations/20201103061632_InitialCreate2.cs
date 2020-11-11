using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotin.HostApi.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUser");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUser",
                nullable: true);

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUser");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUser",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
