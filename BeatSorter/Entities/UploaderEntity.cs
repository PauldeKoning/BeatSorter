using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Entities
{
    public class UploaderEntity
    {

        public int Id { get; set; }

        public string BeatSaverId { get; set; }

        public string Username { get; set; }

        public ICollection<BeatmapEntity> Beatmaps { get; set; }

    }
}
