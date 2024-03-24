using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newshub.Migrations
{
    /// <inheritdoc />
    public partial class Favoriteuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ArticleChannel",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ArticleDescription",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ArticleImage",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "ArticleUrl",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favoriteuser");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favoriteuser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoriteuser",
                table: "Favoriteuser",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoriteuser",
                table: "Favoriteuser");

            migrationBuilder.RenameTable(
                name: "Favoriteuser",
                newName: "Favorites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ArticleChannel",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleDescription",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleImage",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleUrl",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "Id");
        }
    }
}
