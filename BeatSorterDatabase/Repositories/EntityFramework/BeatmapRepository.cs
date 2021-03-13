﻿using BeatSorterDatabase.Entities;
using BeatSorter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Repositories.EntityFramework
{
    public class BeatmapRepository : IBeatmapRepository
    {
        private readonly BeatSorterContext context;

        public BeatmapRepository(BeatSorterContext context)
        {
            this.context = context;
        }

        public void DeleteBeatmap(BeatmapEntity beatmap)
        {
            context.Beatmap.Remove(beatmap);
            context.SaveChanges();
        }

        public BeatmapEntity GetBeatmapById(int beatmapId)
        {
            return context.Beatmap
                .Include(b => b.Uploader)
                .Include(b => b.Difficulties)
                .FirstOrDefault(b => b.Id == beatmapId);
        }

        public IEnumerable<BeatmapEntity> GetBeatmapsPaginated(int amountPerPage, int page)
        {
            if (page < 0) return new List<BeatmapEntity>();

            return context.Beatmap
                .Include(b => b.Uploader)
                .Include(b => b.Difficulties)
                .Skip(page * amountPerPage)
                .Take(amountPerPage)
                .ToList();
        }
        public int GetSelectCount()
        {
            return context.Beatmap
                .Include(b => b.Uploader)
                .Include(b => b.Difficulties)
                .Count();
        }

        public IEnumerable<BeatmapEntity> GetBeatmaps()
        {
            return context.Beatmap.ToList();
        }

        public int InsertBeatmap(BeatmapEntity beatmap)
        {
            context.Beatmap.Add(beatmap);
            context.SaveChanges();
            return beatmap.Id;
        }

        public void UpdateBeatmap(BeatmapEntity beatmap)
        {
            context.Entry(beatmap).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
