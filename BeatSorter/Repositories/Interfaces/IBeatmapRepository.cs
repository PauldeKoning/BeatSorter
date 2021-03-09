﻿using BeatSorter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Repositories.Interfaces
{
    public interface IBeatmapRepository
    {
        IEnumerable<BeatmapEntity> GetBeatmaps();
        BeatmapEntity GetBeatmapById(int beatmapId);
        int InsertBeatmap(BeatmapEntity beatmap);
        void DeleteBeatmap(BeatmapEntity beatmap);
        void UpdateBeatmap(BeatmapEntity beatmap);
    }
}
