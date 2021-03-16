using BeatSorterDatabase.Repositories.Interfaces;
using BeatSorter.Util.Converters;
using BeatSorter.ViewModels;
using BeatSorterDatabase.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatSorter.Models;

namespace BeatSorter.Controllers
{
    public class BeatmapController : Controller
    {
        private readonly IBeatmapRepository beatmapRepository;
        private readonly IUploaderRepository uploaderRepository;

        public BeatmapController(IBeatmapRepository beatmapRepository, IUploaderRepository uploaderRepository)
        {
            this.beatmapRepository = beatmapRepository;
            this.uploaderRepository = uploaderRepository;
        }

        public IActionResult List(int page, string songAuthor, string songTitle)
        {
            int amountPerPage = 10;

            var beatmaps = new List<BeatmapViewModel>();
            var queryBuilder = CreateBaseQueryBuilder(page, songAuthor, songTitle);
            queryBuilder.WithOrderByUploadDate();
            BeatmapConverter.ToModel(beatmapRepository.GetBeatmaps(queryBuilder)).ForEach(b => beatmaps.Add(new BeatmapViewModel(b)));

            int pageAmount = (int)Math.Ceiling((float)beatmapRepository.GetSelectCount(queryBuilder) / amountPerPage);
            var beatmapListVM = new BeatmapListViewModel(pageAmount, page, beatmaps);
            return View(beatmapListVM);
        }

        public IActionResult Uploader(int id, int page, string songAuthor, string songTitle)
        {
            int amountPerPage = 10;

            var beatmaps = new List<BeatmapViewModel>();
            var queryBuilder = CreateBaseQueryBuilder(page, songAuthor, songTitle);
            queryBuilder.WithUploader(id);
            BeatmapConverter.ToModel(beatmapRepository.GetBeatmaps(queryBuilder)).ForEach(b => beatmaps.Add(new BeatmapViewModel(b)));

            int pageAmount = (int)Math.Ceiling((float)beatmapRepository.GetSelectCount(queryBuilder) / amountPerPage);
            var beatmapListVM = new BeatmapListViewModel(pageAmount, page, beatmaps);

            Uploader uploader = UploaderConverter.ToModel(uploaderRepository.GetUploaderById(id));
            string username = null;
            if (uploader != null) username = uploader.Username;
            return View((username, beatmapListVM));
        }

        private EFBeatmapQueryBuilder CreateBaseQueryBuilder(int page, string songAuthor, string songTitle)
        {
            var queryBuilder = new EFBeatmapQueryBuilder();
            queryBuilder.WithPagination(10, page);
            if (songAuthor != null)
            {
                queryBuilder.WithSongAuthor(songAuthor);
            }
            if (songTitle != null)
            {
                queryBuilder.WithSongTitle(songTitle);
            }
            queryBuilder.WithOrderByUploadDate();

            return queryBuilder;
        }

        public IActionResult Detail(int id)
        {
            var beatmap = beatmapRepository.GetBeatmapById(id);

            if (beatmap != null)
            {
                return View(new BeatmapViewModel(BeatmapConverter.ToModel(beatmap)));
            } 
            else
            {
                return View();
            }
        }
    }
}
