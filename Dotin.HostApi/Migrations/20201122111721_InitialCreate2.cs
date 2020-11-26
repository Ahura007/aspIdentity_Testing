using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotin.HostApi.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ledgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LedgerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupLedgers_Ledgers_LedgerId",
                        column: x => x.LedgerId,
                        principalTable: "Ledgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    GroupLedgerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralLedgers_GroupLedgers_GroupLedgerId",
                        column: x => x.GroupLedgerId,
                        principalTable: "GroupLedgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubLedgers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    GeneralLedgersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLedgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubLedgers_GeneralLedgers_GeneralLedgersId",
                        column: x => x.GeneralLedgersId,
                        principalTable: "GeneralLedgers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralLedgers_GroupLedgerId",
                table: "GeneralLedgers",
                column: "GroupLedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupLedgers_LedgerId",
                table: "GroupLedgers",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubLedgers_GeneralLedgersId",
                table: "SubLedgers",
                column: "GeneralLedgersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubLedgers");

            migrationBuilder.DropTable(
                name: "GeneralLedgers");

            migrationBuilder.DropTable(
                name: "GroupLedgers");

            migrationBuilder.DropTable(
                name: "Ledgers");
        }
    }
}
