using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addedinventorys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatchArriveDate",
                table: "Inventory",
                newName: "ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "ExppierationDate",
                table: "Inventory",
                newName: "ArrivalDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "Inventory",
                newName: "PatchArriveDate");

            migrationBuilder.RenameColumn(
                name: "ArrivalDate",
                table: "Inventory",
                newName: "ExppierationDate");
        }
    }
}
