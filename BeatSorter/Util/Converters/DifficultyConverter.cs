using BeatSorterDatabase.Entities;
using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Util.Converters
{
    public class DifficultyConverter
    {

        public static DifficultyEntity ToEntity(Difficulty difficulty)
        {
            return new DifficultyEntity
            {
                Id = difficulty.Id,
                Name = difficulty.Name,
                Type = difficulty.Type,
                Duration = difficulty.Duration,
                Length = difficulty.Length,
                NJS = difficulty.NJS,
                NJSOffset = difficulty.NJSOffset,
                Bombs = difficulty.Bombs,
                Notes = difficulty.Notes,
                Obstacles = difficulty.Obstacles
            };
        }

        public static Difficulty ToModel(DifficultyEntity difficulty)
        {
            return new Difficulty()
            {
                Id = difficulty.Id,
                Name = difficulty.Name,
                Type = difficulty.Type,
                Duration = difficulty.Duration,
                Length = difficulty.Length,
                NJS = difficulty.NJS,
                NJSOffset = difficulty.NJSOffset,
                Bombs = difficulty.Bombs,
                Notes = difficulty.Notes,
                Obstacles = difficulty.Obstacles
            };
        }

    }
}
