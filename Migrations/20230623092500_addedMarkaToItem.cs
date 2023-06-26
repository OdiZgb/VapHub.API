using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addedMarkaToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarkaId",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_MarkaId",
                table: "Items",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Marka_MarkaId",
                table: "Items",
                column: "MarkaId",
                principalTable: "Marka",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Marka_MarkaId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MarkaId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MarkaId",
                table: "Items");
        }
    }
}
