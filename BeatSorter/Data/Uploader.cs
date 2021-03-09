using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Data
{
    public class Uploader
    {

        public int Id { get; set; }

        public string BeatSaverId { get; set; }

        public string Username { get; set; }

        public ICollection<UploaderBeatmap> UploaderBeatmaps { get; set; }

    }
}
