using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Models
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

        //FKs

        public Uploader Uploader { get; set; }

        public List<Difficulty> Difficulties { get; set; }

        public List<string> DifficultyNames
        {
            get
            {
                var difficultyNames = new List<string>();

                Difficulties.ForEach(d => { if (!difficultyNames.Contains(d.Name)) difficultyNames.Add(d.Name); });

                return difficultyNames;
            }
        }

        public List<string> DifficultyTypes
        {
            get 
            {
                var difficultyTypes = new List<string>();

                Difficulties.ForEach(d => { if (!difficultyTypes.Contains(d.Name)) difficultyTypes.Add(d.Type); });

                return difficultyTypes;
            }
        }

    }
}
