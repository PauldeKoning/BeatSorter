using Microsoft.EntityFrameworkCore.Migrations;

namespace BeatSorterDatabase.Migrations
{
    public partial class CreateUniqueBeatSaverId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BeatSaverId",
                table: "uploader",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BeatSaverId",
                table: "beatmap",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_uploader_BeatSaverId",
                table: "uploader",
                column: "BeatSaverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_beatmap_BeatSaverId",
                table: "beatmap",
                column: "BeatSaverId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_uploader_BeatSaverId",
                table: "uploader");

            migrationBuilder.DropIndex(
                name: "IX_beatmap_BeatSaverId",
                table: "beatmap");

            migrationBuilder.AlterColumn<string>(
                name: "BeatSaverId",
                table: "uploader",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BeatSaverId",
                table: "beatmap",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
