using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopEcommerce.Data.migrations
{
    /// <inheritdoc />
    public partial class modefyModelMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsParent",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "IsChildren",
                table: "Menu",
                newName: "ParentId");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuOrder",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "MenuOrder",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Menu",
                newName: "IsChildren");

            migrationBuilder.AddColumn<bool>(
                name: "IsParent",
                table: "Menu",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
