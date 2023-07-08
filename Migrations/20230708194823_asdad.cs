using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class asdad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientDebts_ClientId",
                table: "ClientDebts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDebts_EmployeeId",
                table: "ClientDebts",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDebts_Clients_ClientId",
                table: "ClientDebts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDebts_Employees_EmployeeId",
                table: "ClientDebts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientDebts_Clients_ClientId",
                table: "ClientDebts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientDebts_Employees_EmployeeId",
                table: "ClientDebts");

            migrationBuilder.DropIndex(
                name: "IX_ClientDebts_ClientId",
                table: "ClientDebts");

            migrationBuilder.DropIndex(
                name: "IX_ClientDebts_EmployeeId",
                table: "ClientDebts");
        }
    }
}
