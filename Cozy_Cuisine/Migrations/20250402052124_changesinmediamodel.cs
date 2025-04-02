using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cozy_Cuisine.Migrations
{
    /// <inheritdoc />
    public partial class changesinmediamodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImageList",
                table: "Gallery");

            migrationBuilder.AlterColumn<string>(
                name: "URLGifOrVideo",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "URLImage",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URLImage",
                table: "Gallery");

            migrationBuilder.AlterColumn<string>(
                name: "URLGifOrVideo",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URLImageList",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
