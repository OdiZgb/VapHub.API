using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployeeToInv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Inventory",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_EmployeeId",
                table: "Inventory",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Employees_EmployeeId",
                table: "Inventory",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Employees_EmployeeId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_EmployeeId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Inventory");
        }
    }
}
