using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Entities
{
    public class DifficultyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } // Easy - Normal - Hard - Expert - ExpertPlus

        public string Type { get; set; } // Standard - OneSaber - 360Degree - 90Degree - Lightshow

        public double Duration { get; set; }

        public int Length { get; set; }

        public int NJS { get; set; }

        public float NJSOffset { get; set; }

        public int Bombs { get; set; }

        public int Notes { get; set; }

        public int Obstacles { get; set; }

        public BeatmapEntity Beatmap { get; set; }

    }
}
