using BeatSorterDatabase.Entities;
using BeatSorterDatabase.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorterDatabase.Repositories.Interfaces
{
    public interface IBeatmapRepository
    {
        List<BeatmapEntity> GetBeatmaps(IBeatmapQueryBuilder queryBuilder);
        List<BeatmapEntity> GetBeatmapsPaginated(int amountPerPage, int page);
        int GetSelectCount(IBeatmapQueryBuilder queryBuilder);
        BeatmapEntity GetBeatmapById(int beatmapId);
        int InsertBeatmap(BeatmapEntity beatmap);
        void DeleteBeatmap(BeatmapEntity beatmap);
        void UpdateBeatmap(BeatmapEntity beatmap);
        object GetBeatmapByBeatSaverId(string beatSaverId);
    }
}
