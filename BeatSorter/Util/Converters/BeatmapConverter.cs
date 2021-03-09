using BeatSorter.Models;
using BeatSorter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Util.Converters
{
    public class BeatmapConverter
    {

        public static Beatmap toModel(BeatmapViewModel beatmapViewModel)
        {
            return new Beatmap
            {
                Id = beatmapViewModel.Id,
                BeatSaverId = beatmapViewModel.BeatSaverId,
                Hash = beatmapViewModel.Hash,
                Key = beatmapViewModel.Key,
                UploadDate = beatmapViewModel.UploadDate,
                Title = beatmapViewModel.Title,
                Description = beatmapViewModel.Description,
                LevelAuthor = beatmapViewModel.LevelAuthor,
                SongAuthor = beatmapViewModel.SongAuthor,
                SongTitle = beatmapViewModel.SongTitle,
                SongSubTitle = beatmapViewModel.SongSubTitle,
                BPM = beatmapViewModel.BPM,
                Duration = beatmapViewModel.Duration
            };
        }

        public static BeatmapViewModel toViewModel(Beatmap beatmap)
        {
            return new BeatmapViewModel()
            {
                Id = beatmap.Id,
                BeatSaverId = beatmap.BeatSaverId,
                Hash = beatmap.Hash,
                Key = beatmap.Key,
                UploadDate = beatmap.UploadDate,
                Title = beatmap.Title,
                Description = beatmap.Description,
                LevelAuthor = beatmap.LevelAuthor,
                SongAuthor = beatmap.SongAuthor,
                SongTitle = beatmap.SongTitle,
                SongSubTitle = beatmap.SongSubTitle,
                BPM = beatmap.BPM,
                Duration = beatmap.Duration
            };
        }

    }
}
