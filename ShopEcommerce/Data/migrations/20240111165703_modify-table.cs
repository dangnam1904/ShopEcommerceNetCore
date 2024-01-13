using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEcommerce.Data.migrations
{
    /// <inheritdoc />
    public partial class modifytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_GroupOptions_GroupOptionIdGroup",
                table: "ProductModels");

            migrationBuilder.DropIndex(
                name: "IX_ProductModels_GroupOptionIdGroup",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "GroupOptionIdGroup",
                table: "ProductModels");

            migrationBuilder.RenameColumn(
                name: "NameCategroty",
                table: "Categories",
                newName: "NameCategoty");

            migrationBuilder.RenameColumn(
                name: "IdCategrory",
                table: "Categories",
                newName: "IdCategory");

            migrationBuilder.AddColumn<int>(
                name: "IdOption",
                table: "GroupOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_IdGroupOtion",
                table: "ProductModels",
                column: "IdGroupOtion");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_GroupOptions_IdGroupOtion",
                table: "ProductModels",
                column: "IdGroupOtion",
                principalTable: "GroupOptions",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductModels_GroupOptions_IdGroupOtion",
                table: "ProductModels");

            migrationBuilder.DropIndex(
                name: "IX_ProductModels_IdGroupOtion",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "IdOption",
                table: "GroupOptions");

            migrationBuilder.RenameColumn(
                name: "NameCategoty",
                table: "Categories",
                newName: "NameCategroty");

            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Categories",
                newName: "IdCategrory");

            migrationBuilder.AddColumn<int>(
                name: "GroupOptionIdGroup",
                table: "ProductModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_GroupOptionIdGroup",
                table: "ProductModels",
                column: "GroupOptionIdGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModels_GroupOptions_GroupOptionIdGroup",
                table: "ProductModels",
                column: "GroupOptionIdGroup",
                principalTable: "GroupOptions",
                principalColumn: "IdGroup",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
