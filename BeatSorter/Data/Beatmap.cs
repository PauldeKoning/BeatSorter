using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Data
{
    public class Beatmap
    {
        public int Id { get; set; }

        public string BeatSaverId { get; set; }

        public string Hash { get; set; }

        public string Key { get; set; }

        public DateTime UploadDate { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        // Song stats

        public string LevelAuthor { get; set; }

        public string SongAuthor { get; set; }

        public string SongTitle { get; set; }

        public string SongSubTitle { get; set; } = null!;

        public int BPM { get; set; }

        public int Duration { get; set; }

        public ICollection<Difficulty> Difficulties { get; set; }

        public ICollection<UploaderBeatmap> UploaderBeatmaps { get; set; }

    }
}
