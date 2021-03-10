using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeatSorterDatabase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beatmap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeatSaverId = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LevelAuthor = table.Column<string>(nullable: true),
                    SongAuthor = table.Column<string>(nullable: true),
                    SongTitle = table.Column<string>(nullable: true),
                    SongSubTitle = table.Column<string>(nullable: true),
                    BPM = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beatmap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uploader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeatSaverId = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Difficulty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Duration = table.Column<double>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    NJS = table.Column<int>(nullable: false),
                    NJSOffset = table.Column<float>(nullable: false),
                    Bombs = table.Column<int>(nullable: false),
                    Notes = table.Column<int>(nullable: false),
                    Obstacles = table.Column<int>(nullable: false),
                    BeatmapId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Difficulty_Beatmap_BeatmapId",
                        column: x => x.BeatmapId,
                        principalTable: "Beatmap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploaderBeatmap",
                columns: table => new
                {
                    UploaderId = table.Column<int>(nullable: false),
                    BeatmapId = table.Column<int>(nullable: false)
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
                name: "IX_Difficulty_BeatmapId",
                table: "Difficulty",
                column: "BeatmapId");

            migrationBuilder.CreateIndex(
                name: "IX_UploaderBeatmap_BeatmapId",
                table: "UploaderBeatmap",
                column: "BeatmapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Difficulty");

            migrationBuilder.DropTable(
                name: "UploaderBeatmap");

            migrationBuilder.DropTable(
                name: "Beatmap");

            migrationBuilder.DropTable(
                name: "Uploader");
        }
    }
}
