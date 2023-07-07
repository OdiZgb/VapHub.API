using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedBills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<string>(type: "TEXT", nullable: false),
                    ClientDebtId = table.Column<string>(type: "TEXT", nullable: false),
                    RequierdPrice = table.Column<double>(type: "REAL", nullable: false),
                    PaiedPrice = table.Column<double>(type: "REAL", nullable: false),
                    ExchangeRepaied = table.Column<double>(type: "REAL", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientDebts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DebtValue = table.Column<double>(type: "REAL", nullable: false),
                    DebtPayed = table.Column<double>(type: "REAL", nullable: false),
                    DebtFree = table.Column<bool>(type: "INTEGER", nullable: false),
                    DebtDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DebtFreeDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDebts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientDebts_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_BillId",
                table: "Items",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDebts_BillId",
                table: "ClientDebts",
                column: "BillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Bills_BillId",
                table: "Items",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Bills_BillId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ClientDebts");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Items_BillId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "Items");
        }
    }
}
