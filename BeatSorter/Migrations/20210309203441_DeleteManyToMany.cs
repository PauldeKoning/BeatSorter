using Microsoft.EntityFrameworkCore.Migrations;

namespace BeatSorter.Migrations
{
    public partial class DeleteManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploaderBeatmap");

            migrationBuilder.AddColumn<int>(
                name: "UploaderId",
                table: "Beatmap",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beatmap_UploaderId",
                table: "Beatmap",
                column: "UploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beatmap_Uploader_UploaderId",
                table: "Beatmap",
                column: "UploaderId",
                principalTable: "Uploader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beatmap_Uploader_UploaderId",
                table: "Beatmap");

            migrationBuilder.DropIndex(
                name: "IX_Beatmap_UploaderId",
                table: "Beatmap");

            migrationBuilder.DropColumn(
                name: "UploaderId",
                table: "Beatmap");

            migrationBuilder.CreateTable(
                name: "UploaderBeatmap",
                columns: table => new
                {
                    UploaderId = table.Column<int>(type: "int", nullable: false),
                    BeatmapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploaderBeatmap", x => new { x.UploaderId, x.BeatmapId });
                    table.ForeignKey(
                        name: "FK_UploaderBeatmap_Beatmap_BeatmapId",
                        column: x => x.BeatmapId,
                        principalTable: "Beatmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploaderBeatmap_Uploader_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "Uploader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploaderBeatmap_BeatmapId",
                table: "UploaderBeatmap",
                column: "BeatmapId");
        }
    }
}
