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

        private bool orderByUploadDate;

        private int uploaderId;

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

        public void WithOrderByUploadDate()
        {
            orderByUploadDate = true;
        }

        public void WithUploader(int uploaderId)
        {
            this.uploaderId = uploaderId;
        }

        private IEnumerable<BeatmapEntity> BuildList(BeatSorterContext context)
        {
            var query = context.Beatmap
                .Include(b => b.Uploader).AsQueryable()
                .Include(b => b.Difficulties).AsQueryable();

            if (orderByUploadDate)
            {
                query = query.AsQueryable().OrderByDescending(b => b.UploadDate).AsQueryable();
            }

            if (uploaderId != 0)
            {
                query = query.AsQueryable().Where(b => b.Uploader.Id == uploaderId).AsQueryable();
            }

            if (songAuthor != null)
            {
                query = query.AsQueryable().Where(b => b.SongAuthor.Contains(songAuthor)).AsQueryable();
            }

            if (songTitle != null)
            {
                query = query.AsQueryable().Where(b => b.Title.Contains(songTitle)).AsQueryable();
            }

            return query.AsQueryable();
        }

        public IEnumerable<BeatmapEntity> BuildBeatmapListWithContext(BeatSorterContext context)
        {
            var query = BuildList(context);

            if (paginationAmountPerPage != null && paginationPage != null)
            {
                query = query.AsQueryable().Skip((int)paginationPage * (int)paginationAmountPerPage).AsQueryable().Take((int)paginationAmountPerPage).AsQueryable();
            }

            return query.AsQueryable();
        }

        public IEnumerable<BeatmapEntity> BuildBeatmapListCountWithContext(BeatSorterContext context)
        {
            return BuildList(context).AsQueryable();
        }
    }

}
