using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class ParentChildItem3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoryOfCashBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemId = table.Column<string>(type: "TEXT", nullable: true),
                    ItemBarcode = table.Column<string>(type: "TEXT", nullable: true),
                    ItemCostIn = table.Column<double>(type: "REAL", nullable: false),
                    ItemCostOut = table.Column<double>(type: "REAL", nullable: false),
                    EmployeeName = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientName = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryName = table.Column<int>(type: "INTEGER", nullable: false),
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    barcode = table.Column<string>(type: "TEXT", nullable: true),
                    billId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequierdPrice = table.Column<double>(type: "REAL", nullable: false),
                    ClientCashPayed = table.Column<double>(type: "REAL", nullable: false),
                    ClientRecived = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryOfCashBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryOfCashBill_Bills_billId",
                        column: x => x.billId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfCashBill_billId",
                table: "HistoryOfCashBill",
                column: "billId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryOfCashBill");
        }
    }
}
