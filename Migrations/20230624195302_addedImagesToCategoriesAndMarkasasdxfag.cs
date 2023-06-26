using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addedImagesToCategoriesAndMarkasasdxfag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceIn_PriceInId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_PriceOut_PriceOutId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "PriceOutId",
                table: "Items",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PriceInId",
                table: "Items",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceIn_PriceInId",
                table: "Items",
                column: "PriceInId",
                principalTable: "PriceIn",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_PriceOut_PriceOutId",
                table: "Items",
                column: "PriceOutId",
                principalTable: "PriceOut",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<int>(
                name: "PriceOutId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriceInId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
    }
}
