using BeatSorterDatabase.Entities;
using BeatSorterDatabase.Repositories.Interfaces;
using BeatSorterDatabase.Util;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeatSorterDatabase.External
{
    public class BeatSaverAPI
    {
        private readonly IBeatmapRepository beatmapRepository;
        private readonly IDifficultyRepository difficultyRepository;
        private readonly IUploaderRepository uploaderRepository;

        public BeatSaverAPI(IBeatmapRepository beatmapRepository, IDifficultyRepository difficultyRepository, IUploaderRepository uploaderRepository)
        {
            this.beatmapRepository = beatmapRepository;
            this.difficultyRepository = difficultyRepository;
            this.uploaderRepository = uploaderRepository;
        }

        public void RetrieveLatestSongs(int page = 0)
        {
            Console.WriteLine(" -- STARTING DATA REQUEST FROM BEATSAVER --");
            var api = new APIConnection();
            var task = api.GetAsync<BeatSaverAPILatestResponse>("https://beatsaver.com/api/maps/latest/" + page);
            task.Wait();
            var results = task.Result;

            Console.WriteLine(" -- DATA RECEIVED FROM BEATSAVER --");
            HandleData(results);
        }

        public void HandleData(BeatSaverAPILatestResponse data)
        {
            Console.WriteLine(" -- STARTING BEATSAVER DATA HANDLING --");
            foreach (var api in data.docs)
            {
                if (beatmapRepository.GetBeatmapByBeatSaverId(api._id) != null)
                {
                    Console.WriteLine(" -- FINISHED BEATSAVER DATA HANDLING (BEATMAP ALREADY FOUND) --");
                    return; ; ; //TODO change for production
                }

                var uploader = uploaderRepository.GetUploaderByBeatSaverId(api.uploader._id);
                if (uploader == null)
                {
                    Console.WriteLine(" -- INSERTING NEW UPLOADER --");
                    uploader = new UploaderEntity()
                    {
                        BeatSaverId = api.uploader._id,
                        Username = api.uploader.username
                    };
                    uploaderRepository.InsertUploader(uploader);
                }

                Console.WriteLine(" -- INSERTING NEW BEATMAP --");
                var beatmap = new BeatmapEntity()
                {
                    BeatSaverId = api._id,
                    Hash = api.hash,
                    Key = api.key,
                    UploadDate = api.uploaded,
                    Title = api.name,
                    Description = api.description,
                    LevelAuthor = api.metadata.levelAuthorName,
                    SongAuthor = api.metadata.songAuthorName,
                    SongTitle = api.metadata.songName,
                    SongSubTitle = api.metadata.songSubName,
                    BPM = (int)Math.Round(api.metadata.bpm),
                    Duration = api.metadata.duration,
                    Uploader = uploader
                };
                beatmapRepository.InsertBeatmap(beatmap);

                foreach (var characteristics in api.metadata.characteristics)
                {
                    foreach (var difficultyData in characteristics.difficulties)
                    {
                        if (difficultyData.Value == null) continue;
                        Console.WriteLine(" -- INSERTING NEW DIFFICULTY --");
                        var difficulty = new DifficultyEntity()
                        {
                            Name = difficultyData.Key
                            .ToLower(),
                            Type = characteristics.name
                            .ToLower()
                            .Replace("one saber", "onsaber")
                            .Replace("no arrows", "noarrows"),
                            Duration = difficultyData.Value.duration,
                            Length = (int)Math.Round(difficultyData.Value.length),
                            NJS = (int)Math.Round(difficultyData.Value.njs),
                            NJSOffset = (float)difficultyData.Value.njsOffset,
                            Bombs = difficultyData.Value.bombs,
                            Notes = difficultyData.Value.notes,
                            Obstacles = difficultyData.Value.obstacles,
                            Beatmap = beatmap
                        };
                        difficultyRepository.InsertDifficulty(difficulty);
                    }
                }
            }

            if (data.nextPage != null)
            {
                Console.WriteLine(" -- CONTINUING DATA REQUEST --");
                RetrieveLatestSongs((int)data.nextPage);
            } 
            else
            {
                Console.WriteLine(" -- FINISHED BEATSAVER DATA HANDLING (NO FURTHER MAPS FOUND) --");
            }
        }
    }

#pragma warning disable IDE1006, IDE0060 // Naming Styles
    public class BeatSaverAPILatestResponse
    {

        public BeatSaverAPIBeatmap[] docs { get; set; }
        public int totalDocs { get; set; }
        public int? lastPage { get; set; }
        public int? prevPage { get; set; }
        public int? nextPage { get; set; }

    }

    public class BeatSaverAPIBeatmap
    {
        public BeatSaverAPIBeatmapMetadata metadata { get; set; }
        public BeatSaverAPIBeatmapStats stats { get; set; }
        public string description { get; set; }
        public string _id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public BeatSaverAPIBeatmapUploader uploader { get; set; }
        public string hash { get; set; }
        public DateTime uploaded { get; set; }
        public string directDownload { get; set; }
        public string downloadURL { get; set; }
        public string coverURL { get; set; }
    }

    public class BeatSaverAPIBeatmapMetadata
    {
        public Dictionary<string, bool> difficulties { get; set; }
        public int duration { get; set; }
        public BeatSaverAPIBeatmapMetadataCharacteristics[] characteristics { get; set; }
        public string levelAuthorName { get; set; }
        public string songAuthorName { get; set; }
        public string songName { get; set; }
        public string songSubName { get; set; }
        public double bpm { get; set; }
    }

    public class BeatSaverAPIBeatmapMetadataCharacteristics
    {
        public Dictionary<string, BeatSaverAPIBeatmapMetadataCharacteristicsDifficulty> difficulties { get; set; }
        public string name { get; set; }
    }

    public class BeatSaverAPIBeatmapMetadataCharacteristicsDifficulty
    {
        public double duration { get; set; }
        public double length { get; set; }
        public double njs { get; set; }
        public double njsOffset { get; set; }
        public int bombs { get; set; }
        public int notes { get; set; }
        public int obstacles { get; set; }
    }

    public class BeatSaverAPIBeatmapStats
    {
        public int downloads { get; set; }
        public int plays { get; set; }
        public int downVotes { get; set; }
        public int upVotes { get; set; }
        public double heat { get; set; }
        public double rating { get; set; }
    }

    public class BeatSaverAPIBeatmapUploader
    {
        public string _id { get; set; }
        public string username { get; set; }
    }

#pragma warning restore IDE1006, IDE0060 // Naming Styles
}
