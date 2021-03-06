// <auto-generated />
using System;
using BeatSorterDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeatSorterDatabase.Migrations
{
    [DbContext(typeof(BeatSorterContext))]
    partial class BeatSorterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BeatSorterDatabase.Entities.BeatmapEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BPM")
                        .HasColumnType("int");

                    b.Property<string>("BeatSaverId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Hash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Key")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LevelAuthor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SongAuthor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SongSubTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SongTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("UploaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeatSaverId")
                        .IsUnique();

                    b.HasIndex("UploaderId");

                    b.ToTable("beatmap");
                });

            modelBuilder.Entity("BeatSorterDatabase.Entities.DifficultyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BeatmapId")
                        .HasColumnType("int");

                    b.Property<int>("Bombs")
                        .HasColumnType("int");

                    b.Property<double>("Duration")
                        .HasColumnType("double");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("NJS")
                        .HasColumnType("int");

                    b.Property<float>("NJSOffset")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Notes")
                        .HasColumnType("int");

                    b.Property<int>("Obstacles")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BeatmapId");

                    b.ToTable("difficulty");
                });

            modelBuilder.Entity("BeatSorterDatabase.Entities.UploaderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BeatSaverId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BeatSaverId")
                        .IsUnique();

                    b.ToTable("uploader");
                });

            modelBuilder.Entity("BeatSorterDatabase.Entities.BeatmapEntity", b =>
                {
                    b.HasOne("BeatSorterDatabase.Entities.UploaderEntity", "Uploader")
                        .WithMany("Beatmaps")
                        .HasForeignKey("UploaderId");
                });

            modelBuilder.Entity("BeatSorterDatabase.Entities.DifficultyEntity", b =>
                {
                    b.HasOne("BeatSorterDatabase.Entities.BeatmapEntity", "Beatmap")
                        .WithMany("Difficulties")
                        .HasForeignKey("BeatmapId");
                });
#pragma warning restore 612, 618
        }
    }
}
