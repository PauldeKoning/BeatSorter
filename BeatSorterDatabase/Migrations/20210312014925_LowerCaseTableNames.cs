using Microsoft.EntityFrameworkCore.Migrations;

namespace BeatSorterDatabase.Migrations
{
    public partial class LowerCaseTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beatmap_Uploader_UploaderId",
                table: "Beatmap");

            migrationBuilder.DropForeignKey(
                name: "FK_Difficulty_Beatmap_BeatmapId",
                table: "Difficulty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uploader",
                table: "Uploader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Difficulty",
                table: "Difficulty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beatmap",
                table: "Beatmap");

            migrationBuilder.RenameTable(
                name: "Uploader",
                newName: "uploader");

            migrationBuilder.RenameTable(
                name: "Difficulty",
                newName: "difficulty");

            migrationBuilder.RenameTable(
                name: "Beatmap",
                newName: "beatmap");

            migrationBuilder.RenameIndex(
                name: "IX_Difficulty_BeatmapId",
                table: "difficulty",
                newName: "IX_difficulty_BeatmapId");

            migrationBuilder.RenameIndex(
                name: "IX_Beatmap_UploaderId",
                table: "beatmap",
                newName: "IX_beatmap_UploaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uploader",
                table: "uploader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_difficulty",
                table: "difficulty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_beatmap",
                table: "beatmap",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_beatmap_uploader_UploaderId",
                table: "beatmap",
                column: "UploaderId",
                principalTable: "uploader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_difficulty_beatmap_BeatmapId",
                table: "difficulty",
                column: "BeatmapId",
                principalTable: "beatmap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_beatmap_uploader_UploaderId",
                table: "beatmap");

            migrationBuilder.DropForeignKey(
                name: "FK_difficulty_beatmap_BeatmapId",
                table: "difficulty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uploader",
                table: "uploader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_difficulty",
                table: "difficulty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_beatmap",
                table: "beatmap");

            migrationBuilder.RenameTable(
                name: "uploader",
                newName: "Uploader");

            migrationBuilder.RenameTable(
                name: "difficulty",
                newName: "Difficulty");

            migrationBuilder.RenameTable(
                name: "beatmap",
                newName: "Beatmap");

            migrationBuilder.RenameIndex(
                name: "IX_difficulty_BeatmapId",
                table: "Difficulty",
                newName: "IX_Difficulty_BeatmapId");

            migrationBuilder.RenameIndex(
                name: "IX_beatmap_UploaderId",
                table: "Beatmap",
                newName: "IX_Beatmap_UploaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uploader",
                table: "Uploader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Difficulty",
                table: "Difficulty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beatmap",
                table: "Beatmap",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beatmap_Uploader_UploaderId",
                table: "Beatmap",
                column: "UploaderId",
                principalTable: "Uploader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Difficulty_Beatmap_BeatmapId",
                table: "Difficulty",
                column: "BeatmapId",
                principalTable: "Beatmap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
