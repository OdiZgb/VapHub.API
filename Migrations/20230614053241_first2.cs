using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class first2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceOut_Items_ItemId",
                table: "PriceOut");

            migrationBuilder.DropIndex(
                name: "IX_PriceOut_ItemId",
                table: "PriceOut");

            migrationBuilder.RenameColumn(
                name: "PriceInOutId",
                table: "Items",
                newName: "PriceOutId");

            migrationBuilder.AddColumn<int>(
                name: "PriceOutId1",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceOutId1",
                table: "Items",
                column: "PriceOutId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceOut_PriceOutId1",
                table: "Items",
                column: "PriceOutId1",
                principalTable: "PriceOut",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceOut_PriceOutId1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PriceOutId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PriceOutId1",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PriceOutId",
                table: "Items",
                newName: "PriceInOutId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceOut_ItemId",
                table: "PriceOut",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceOut_Items_ItemId",
                table: "PriceOut",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
