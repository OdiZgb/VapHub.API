using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapHub.API.Migrations
{
    /// <inheritdoc />
    public partial class addedMarkaToItemjfnb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Marka_MarkaId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "MarkaId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Marka_MarkaId",
                table: "Items",
                column: "MarkaId",
                principalTable: "Marka",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Marka_MarkaId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "MarkaId",
                table: "Items",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Marka_MarkaId",
                table: "Items",
                column: "MarkaId",
                principalTable: "Marka",
                principalColumn: "Id");
        }
    }
}
