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
            Title = beatmap.Title;
            BPM = beatmap.BPM;
            LevelAuthor = beatmap.LevelAuthor;
            Uploader = beatmap.Uploader;
            DifficultyTypes = beatmap.DifficultyTypes;

            Difficulties = new Dictionary<string, List<string>>();
            DifficultyTypes.ForEach(d => Difficulties.Add(d, beatmap.GetDifficultiesByType(d)));
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int BPM { get; set; }
        public string LevelAuthor { get; set; }
        public Uploader Uploader { get; set; }

        public Dictionary<string, List<string>> Difficulties { get; set; }

        public List<string> GetAvailableDifficulties(string difficultyType)
        {
            if (Difficulties.ContainsKey(difficultyType))
                return Difficulties[difficultyType];
            return new List<string>();
        }

        public List<string> DifficultyTypes { get; set; }

        public string CapitalizeFirst(string str)
        {
            return char.ToUpper(str[0]) + str[1..];
        }
    }
}
