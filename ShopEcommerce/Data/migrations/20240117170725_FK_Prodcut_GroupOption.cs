using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEcommerce.Data.migrations
{
    /// <inheritdoc />
    public partial class FK_Prodcut_GroupOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupOptions_Products_ProductIdProduct",
                table: "GroupOptions");

            migrationBuilder.DropTable(
                name: "ProductModels");

            migrationBuilder.DropIndex(
                name: "IX_GroupOptions_ProductIdProduct",
                table: "GroupOptions");

            migrationBuilder.DropColumn(
                name: "IdGroup",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductIdProduct",
                table: "GroupOptions");

            migrationBuilder.AddColumn<int>(
                name: "GroupOptionIdGroup",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "GroupOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupOptionIdGroup",
                table: "Products",
                column: "GroupOptionIdGroup");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GroupOptions_GroupOptionIdGroup",
                table: "Products",
                column: "GroupOptionIdGroup",
                principalTable: "GroupOptions",
                principalColumn: "IdGroup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GroupOptions_GroupOptionIdGroup",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GroupOptionIdGroup",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GroupOptionIdGroup",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "GroupOptions");

            migrationBuilder.AddColumn<int>(
                name: "IdGroup",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductIdProduct",
                table: "GroupOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductModels",
                columns: table => new
                {
                    IdProductModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGroupOtion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModels", x => x.IdProductModel);
                    table.ForeignKey(
                        name: "FK_ProductModels_GroupOptions_IdGroupOtion",
                        column: x => x.IdGroupOtion,
                        principalTable: "GroupOptions",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupOptions_ProductIdProduct",
                table: "GroupOptions",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModels_IdGroupOtion",
                table: "ProductModels",
                column: "IdGroupOtion");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupOptions_Products_ProductIdProduct",
                table: "GroupOptions",
                column: "ProductIdProduct",
                principalTable: "Products",
                principalColumn: "IdProduct");
        }
    }
}
