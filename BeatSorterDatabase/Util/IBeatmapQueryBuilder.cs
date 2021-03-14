using BeatSorterDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeatSorterDatabase.Util
{
    public interface IBeatmapQueryBuilder
    {
        public void WithSongAuthor(string author);
        public void WithSongTitle(string title);
        public void WithPagination(int amountPerPage, int page);
        public IEnumerable<BeatmapEntity> BuildBeatmapListWithContext(BeatSorterContext context);
        public IEnumerable<BeatmapEntity> BuildBeatmapListCountWithContext(BeatSorterContext context);
    }
}
