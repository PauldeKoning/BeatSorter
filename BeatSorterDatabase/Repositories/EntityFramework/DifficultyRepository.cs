using BeatSorterDatabase.Entities;
using BeatSorterDatabase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeatSorterDatabase.Repositories.EntityFramework
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly BeatSorterContext context;

        public DifficultyRepository(BeatSorterContext context)
        {
            this.context = context;
        }

        public DifficultyEntity GetDifficulty(string name, string type, int beatmapId)
        {
            return context.Difficulty.Include(d => d.Beatmap).FirstOrDefault(d => d.Name == name && d.Type == type && d.Beatmap.Id == beatmapId);
        }

        public void InsertDifficulty(DifficultyEntity difficulty)
        {
            context.Difficulty.Add(difficulty);
            context.SaveChanges();
        }
    }
}
