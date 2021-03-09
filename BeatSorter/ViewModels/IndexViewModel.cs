using BeatSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.ViewModels
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public int BPM { get; set; }
        public string LevelAuthor { get; set; }
        public Uploader Uploader { get; set; }
        public List<string> DifficultyNames { get; set; }
        public List<string> DifficultyTypes { get; set; }

        public string GetDifficultyColour(string difficulty)
        {
            switch(difficulty.ToLower())
            {
                case "easy":
                    return "success";
                case "normal":
                    return "secondary";
                case "hard":
                    return "primary";
                case "expert":
                    return "danger";
                case "expert+":
                    return "dark";
                default:
                    return "info";
            }
        }

        public string CapitalizeFirst(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
