using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorterDatabase.Entities
{
    public class BeatSorterContext : DbContext
    {

        public BeatSorterContext(DbContextOptions<BeatSorterContext> options) : base(options)
        {

        }

        public DbSet<BeatmapEntity> Beatmap { get; set; }

        public DbSet<DifficultyEntity> Difficulty { get; set; }

        public DbSet<UploaderEntity> Uploader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeatmapEntity>()
                .HasMany(b => b.Difficulties)
                .WithOne(d => d.Beatmap);

            modelBuilder.Entity<BeatmapEntity>()
                .HasOne(b => b.Uploader)
                .WithMany(u => u.Beatmaps);

            modelBuilder.Entity<BeatmapEntity>()
                .HasIndex(b => b.BeatSaverId).IsUnique();
            modelBuilder.Entity<UploaderEntity>()
                .HasIndex(u => u.BeatSaverId).IsUnique();
        }

    }
}
