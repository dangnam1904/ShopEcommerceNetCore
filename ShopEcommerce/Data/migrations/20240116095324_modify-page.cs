using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEcommerce.Data.migrations
{
    /// <inheritdoc />
    public partial class modifypage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Menu_IdMenu",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_IdMenu",
                table: "Pages");

            migrationBuilder.AlterColumn<int>(
                name: "IdMenu",
                table: "Pages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_IdMenu",
                table: "Pages",
                column: "IdMenu",
                unique: true,
                filter: "[IdMenu] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Menu_IdMenu",
                table: "Pages",
                column: "IdMenu",
                principalTable: "Menu",
                principalColumn: "IdMenu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Menu_IdMenu",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_IdMenu",
                table: "Pages");

            migrationBuilder.AlterColumn<int>(
                name: "IdMenu",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_IdMenu",
                table: "Pages",
                column: "IdMenu",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Menu_IdMenu",
                table: "Pages",
                column: "IdMenu",
                principalTable: "Menu",
                principalColumn: "IdMenu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
