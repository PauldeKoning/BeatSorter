using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.ViewModels
{
    public class IndexViewModel
    {
        private readonly Beatmap beatmap;

        public IndexViewModel(Beatmap beatmap)
        {
            this.beatmap = beatmap;
            Title = beatmap.Title;
            BPM = beatmap.BPM;
            LevelAuthor = beatmap.LevelAuthor;
            Uploader = beatmap.Uploader;
        }

        public string Title { get; set; }
        public int BPM { get; set; }
        public string LevelAuthor { get; set; }
        public Uploader Uploader { get; set; }

        public List<string> DifficultyNames
        {
            get
            {
                return beatmap.DifficultyNames;
            }
        }

        public List<string> DifficultyTypes
        {
            get
            {
                return beatmap.DifficultyTypes;
            }
        }

        public string GetDifficultyColourTagName(string difficulty)
        {
            switch(difficulty.ToLower())
            {
                case "easy":
                    return "badge-success";
                case "normal":
                    return "badge-secondary";
                case "hard":
                    return "badge-primary";
                case "expert":
                    return "badge-danger";
                case "expert+":
                    return "badge-dark";
                default:
                    return "badge-info";
            }
        }

        public string CapitalizeFirst(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
