using BeatSorterDatabase.Entities;
using BeatSorter.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatSorterDatabase.Util;

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

        public List<BeatmapEntity> GetBeatmapsPaginated(int amountPerPage, int page)
        {
            if (page < 0) return new List<BeatmapEntity>();

            var test = context.Beatmap
                .Include(b => b.Uploader)
                .Include(b => b.Difficulties).AsQueryable();

            test = test.Skip(page * amountPerPage)
                .Take(amountPerPage);

            return test.ToList();

        }

        //TODO optimize this, make it one database call with two returning values
        public int GetSelectCount(IBeatmapQueryBuilder queryBuilder)
        {
            return queryBuilder.BuildBeatmapListCountWithContext(context).Count();
        }

        public List<BeatmapEntity> GetBeatmaps(IBeatmapQueryBuilder queryBuilder)
        {
            return queryBuilder.BuildBeatmapListWithContext(context).ToList();
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
