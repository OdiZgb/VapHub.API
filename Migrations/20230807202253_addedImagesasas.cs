using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addedImagesasas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Employees_EmployeeId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_EmployeeId",
                table: "Inventory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
