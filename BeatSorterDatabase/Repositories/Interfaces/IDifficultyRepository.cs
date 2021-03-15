using BeatSorterDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeatSorterDatabase.Repositories.Interfaces
{
    public interface IDifficultyRepository
    {
        public void InsertDifficulty(DifficultyEntity difficulty);
        public DifficultyEntity GetDifficulty(string name, string type, int beatmapId);
    }
}
