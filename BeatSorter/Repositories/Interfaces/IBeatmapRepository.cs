using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Repositories.Interfaces
{
    public interface IBeatmapRepository
    {
        IEnumerable<Beatmap> GetBeatmaps();
        Beatmap GetBeatmapById(int beatmapId);
        int InsertBeatmap(Beatmap beatmap);
        void DeleteBeatmap(Beatmap beatmap);
        void UpdateBeatmap(Beatmap beatmap);
    }
}
