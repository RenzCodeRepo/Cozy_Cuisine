using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cozy_Cuisine.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameReview_GameDownloads_DownloadId",
                table: "GameReview");

            migrationBuilder.DropIndex(
                name: "IX_GameReview_DownloadId",
                table: "GameReview");

            migrationBuilder.DropColumn(
                name: "DownloadId",
                table: "GameReview");

            migrationBuilder.DropColumn(
                name: "GameURL",
                table: "GameDownloads");

            migrationBuilder.AddColumn<string>(
                name: "GameURL",
                table: "Patches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameURL",
                table: "Patches");

            migrationBuilder.AddColumn<int>(
                name: "DownloadId",
                table: "GameReview",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GameURL",
                table: "GameDownloads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GameReview_DownloadId",
                table: "GameReview",
                column: "DownloadId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameReview_GameDownloads_DownloadId",
                table: "GameReview",
                column: "DownloadId",
                principalTable: "GameDownloads",
                principalColumn: "DownloadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
