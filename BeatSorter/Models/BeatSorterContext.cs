using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Models
{
    public class BeatSorterContext : DbContext
    {

        public BeatSorterContext(DbContextOptions<BeatSorterContext> options) : base(options)
        {

        }

        public DbSet<Beatmap> Beatmap { get; set; }

        public DbSet<Difficulty> Difficulty { get; set; }

        public DbSet<Uploader> Uploader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beatmap>()
                .HasMany(b => b.Difficulties)
                .WithOne(d => d.Beatmap);

            modelBuilder.Entity<Beatmap>()
                .HasOne(b => b.Uploader)
                .WithMany(u => u.Beatmaps);

        }

    }
}
