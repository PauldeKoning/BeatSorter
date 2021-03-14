using BeatSorterDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeatSorterDatabase.Util
{

    public class EFBeatmapQueryBuilder : IBeatmapQueryBuilder
    {
        private int? paginationAmountPerPage;
        private int? paginationPage;

        private string songAuthor;
        private string songTitle;

        public void WithPagination(int amountPerPage, int page)
        {
            if (page < 0) page = 0;

            paginationAmountPerPage = amountPerPage;
            paginationPage = page;
        }

        public void WithSongAuthor(string author)
        {
            songAuthor = author;
        }

        public void WithSongTitle(string title)
        {
            songTitle = title;
        }

        private IEnumerable<BeatmapEntity> BuildList(BeatSorterContext context)
        {
            var query = context.Beatmap
                .Include(b => b.Uploader)
                .Include(b => b.Difficulties).AsQueryable();

            if (songAuthor != null)
            {
                query = query.Where(b => b.SongAuthor.Contains(songAuthor)).AsQueryable();
            }

            if (songTitle != null)
            {
                query = query.Where(b => b.Title.Contains(songTitle)).AsQueryable();
            }

            return query;
        }

        public IEnumerable<BeatmapEntity> BuildBeatmapListWithContext(BeatSorterContext context)
        {
            var query = BuildList(context);

            if (paginationAmountPerPage != null && paginationPage != null)
            {
                query = query.Skip((int)paginationPage * (int)paginationAmountPerPage).Take((int)paginationAmountPerPage).AsQueryable();
            }

            return query;
        }

        public IEnumerable<BeatmapEntity> BuildBeatmapListCountWithContext(BeatSorterContext context)
        {
            return BuildList(context);
        }
    }

}
