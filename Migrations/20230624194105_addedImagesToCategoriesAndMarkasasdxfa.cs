using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addedImagesToCategoriesAndMarkasasdxfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceIn_PriceInId1",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceOut_PriceOutId1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PriceInId1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PriceOutId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PriceOut");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "PriceIn");

            migrationBuilder.DropColumn(
                name: "PriceInId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PriceOutId1",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceInId",
                table: "Items",
                column: "PriceInId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceOutId",
                table: "Items",
                column: "PriceOutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceIn_PriceInId",
                table: "Items",
                column: "PriceInId",
                principalTable: "PriceIn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceOut_PriceOutId",
                table: "Items",
                column: "PriceOutId",
                principalTable: "PriceOut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceIn_PriceInId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceOut_PriceOutId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PriceInId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PriceOutId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PriceOut",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "PriceIn",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceInId1",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceOutId1",
                table: "Items",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceInId1",
                table: "Items",
                column: "PriceInId1");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PriceOutId1",
                table: "Items",
                column: "PriceOutId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceIn_PriceInId1",
                table: "Items",
                column: "PriceInId1",
                principalTable: "PriceIn",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceOut_PriceOutId1",
                table: "Items",
                column: "PriceOutId1",
                principalTable: "PriceOut",
                principalColumn: "Id");
        }
    }
}
