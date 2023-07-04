using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSalaryToEmployeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Salarys_SalaryId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SalaryId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SalaryID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_EmployeeId",
                table: "Salarys",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salarys_Employees_EmployeeId",
                table: "Salarys",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salarys_Employees_EmployeeId",
                table: "Salarys");

            migrationBuilder.DropIndex(
                name: "IX_Salarys_EmployeeId",
                table: "Salarys");

            migrationBuilder.AddColumn<int>(
                name: "SalaryID",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalaryId",
                table: "Employees",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Salarys_SalaryId",
                table: "Employees",
                column: "SalaryId",
                principalTable: "Salarys",
                principalColumn: "Id");
        }
    }
}
