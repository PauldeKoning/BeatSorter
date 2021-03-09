using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Models
{
    public class UploaderBeatmap
    {
        public int UploaderId { get; set; }
        public Uploader Uploader { get; set; }

        public int BeatmapId { get; set; }
        public Beatmap Beatmap { get; set; }
    }
}
