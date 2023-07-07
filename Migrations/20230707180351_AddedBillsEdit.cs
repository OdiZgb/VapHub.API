using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedBillsEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientDebts_Bills_BillId",
                table: "ClientDebts");

            migrationBuilder.DropIndex(
                name: "IX_ClientDebts_BillId",
                table: "ClientDebts");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Bills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Bills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "ClientDebtId",
                table: "Bills",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ClientDebtId1",
                table: "Bills",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ClientDebtId1",
                table: "Bills",
                column: "ClientDebtId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_ClientDebts_ClientDebtId1",
                table: "Bills",
                column: "ClientDebtId1",
                principalTable: "ClientDebts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_ClientDebts_ClientDebtId1",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ClientDebtId1",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ClientDebtId1",
                table: "Bills");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Bills",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Bills",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientDebtId",
                table: "Bills",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientDebts_BillId",
                table: "ClientDebts",
                column: "BillId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDebts_Bills_BillId",
                table: "ClientDebts",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "Id");
        }
    }
}
