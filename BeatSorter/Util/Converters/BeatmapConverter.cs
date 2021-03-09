using BeatSorter.Entities;
using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Util.Converters
{
    public class BeatmapConverter
    {

        public static BeatmapEntity ToEntity(Beatmap beatmap)
        {
            return new BeatmapEntity
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

        public static Beatmap ToModel(BeatmapEntity beatmap)
        {
            var viewModel = new Beatmap()
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
                Duration = beatmap.Duration,
                Uploader = UploaderConverter.ToModel(beatmap.Uploader),
                Difficulties = new List<Difficulty>()
            };

            beatmap.Difficulties.ToList().ForEach(d => viewModel.Difficulties.Add(DifficultyConverter.ToModel(d)));

            return viewModel;
        }

    }
}
