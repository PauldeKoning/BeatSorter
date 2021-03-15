using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.ViewModels
{
    public class BeatmapViewModel
    {
        public BeatmapViewModel(Beatmap beatmap)
        {
            Id = beatmap.Id;
            BPM = beatmap.BPM;
            LevelAuthor = beatmap.LevelAuthor;
            SongAuthor = beatmap.SongAuthor;
            Title = beatmap.Title;
            Uploader = beatmap.Uploader;
            DifficultyTypes = beatmap.DifficultyTypes;
            Hash = beatmap.Hash;
            Key = beatmap.Key;
            Duration = beatmap.Duration;
            Description = beatmap.Description;

            Difficulties = new Dictionary<string, List<string>>();
            DifficultyTypes.ForEach(d => Difficulties.Add(d, beatmap.GetDifficultiesByType(d)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int BPM { get; set; }
        public string LevelAuthor { get; set; }
        public string SongAuthor { get; set; }
        public string Hash { get; set; }
        public string Key { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public Uploader Uploader { get; set; }

        public Dictionary<string, List<string>> Difficulties { get; set; }

        public List<string> GetAvailableDifficulties(string difficultyType)
        {
            if (Difficulties.ContainsKey(difficultyType))
                return Difficulties[difficultyType];
            return new List<string>();
        }

        //TODO Add support for 'unsupported types', these should be displayed after supported types
        public List<string> DifficultyTypes { get; set; }

        //Previous usage, add back for performance: Following function manually adds the 'badge-not-present' class to the BeatmapView difficulties if Standard is the only DifficultyType
        //DifficultyTypes.Count == 1 && //First two check if manual check is necessary or if javascript is handling it
        public bool ContainsDifficulty(string difficultyType, string difficultyName)
        {
            if (DifficultyTypes.Contains(difficultyType) && 
                GetAvailableDifficulties(difficultyType).Contains(difficultyName))
                return true;
            return false;
        }

        public string DurationFormatted
        {
            get
            {
                return $"{Math.Floor((float)Duration / 60)}:{Duration % 60:00}";
            }
        }

        public string DescriptionFormatted
        {
            get
            {
                return Description
                    .Replace("\n", "<br>").Replace("\r\n", "<br>");
            }
        }

        public string CapitalizeFirst(string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
    }
}
