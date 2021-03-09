using BeatSorter.Models;
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

        public void DeleteBeatmap(Beatmap beatmap)
        {
            context.Beatmap.Remove(beatmap);
            context.SaveChanges();
        }

        public Beatmap GetBeatmapById(int beatmapId)
        {
            return context.Beatmap.Find(beatmapId);
        }

        public IEnumerable<Beatmap> GetBeatmaps()
        {
            return context.Beatmap.ToList();
        }

        public int InsertBeatmap(Beatmap beatmap)
        {
            context.Beatmap.Add(beatmap);
            context.SaveChanges();
            return beatmap.Id;
        }

        public void UpdateBeatmap(Beatmap beatmap)
        {
            context.Entry(beatmap).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
