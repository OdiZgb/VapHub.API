using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSalaryToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
