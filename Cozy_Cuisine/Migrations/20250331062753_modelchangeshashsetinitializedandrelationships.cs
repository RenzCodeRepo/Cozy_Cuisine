using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cozy_Cuisine.Migrations
{
    /// <inheritdoc />
    public partial class modelchangeshashsetinitializedandrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugReport_Patches_PatchId",
                table: "BugReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Wiki_WikiId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BugReport_BugId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_GameItems_Wiki_WikiId",
                table: "GameItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMechanics_Wiki_WikiId",
                table: "GameMechanics");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Wiki_WikiId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryPlot_Wiki_WikiId",
                table: "StoryPlot");

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "StoryPlot",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "GameMechanics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "GameItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BugId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "Characters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PatchId",
                table: "BugReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BugReport_Patches_PatchId",
                table: "BugReport",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "PatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Wiki_WikiId",
                table: "Characters",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BugReport_BugId",
                table: "Comments",
                column: "BugId",
                principalTable: "BugReport",
                principalColumn: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameItems_Wiki_WikiId",
                table: "GameItems",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameMechanics_Wiki_WikiId",
                table: "GameMechanics",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Wiki_WikiId",
                table: "Locations",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoryPlot_Wiki_WikiId",
                table: "StoryPlot",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugReport_Patches_PatchId",
                table: "BugReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Wiki_WikiId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BugReport_BugId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_GameItems_Wiki_WikiId",
                table: "GameItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GameMechanics_Wiki_WikiId",
                table: "GameMechanics");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Wiki_WikiId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryPlot_Wiki_WikiId",
                table: "StoryPlot");

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "StoryPlot",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "GameMechanics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "GameItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BugId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WikiId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatchId",
                table: "BugReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BugReport_Patches_PatchId",
                table: "BugReport",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "PatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Wiki_WikiId",
                table: "Characters",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BugReport_BugId",
                table: "Comments",
                column: "BugId",
                principalTable: "BugReport",
                principalColumn: "BugId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameItems_Wiki_WikiId",
                table: "GameItems",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameMechanics_Wiki_WikiId",
                table: "GameMechanics",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Wiki_WikiId",
                table: "Locations",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoryPlot_Wiki_WikiId",
                table: "StoryPlot",
                column: "WikiId",
                principalTable: "Wiki",
                principalColumn: "WikiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
