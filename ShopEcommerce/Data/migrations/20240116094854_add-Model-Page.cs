using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEcommerce.Data.migrations
{
    /// <inheritdoc />
    public partial class addModelPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    IdPage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitlePage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ContentPage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMenu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.IdPage);
                    table.ForeignKey(
                        name: "FK_Pages_Menu_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Menu",
                        principalColumn: "IdMenu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_IdMenu",
                table: "Pages",
                column: "IdMenu",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");
        }
    }
}
