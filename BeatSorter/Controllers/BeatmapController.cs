using BeatSorterDatabase.Repositories.Interfaces;
using BeatSorter.Util.Converters;
using BeatSorter.ViewModels;
using BeatSorterDatabase.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.Controllers
{
    public class BeatmapController : Controller
    {
        private readonly IBeatmapRepository beatmapRepository;

        public BeatmapController(IBeatmapRepository beatmapRepository)
        {
            this.beatmapRepository = beatmapRepository;
        }

        public IActionResult List(int page, string songAuthor, string songTitle)
        {
            int amountPerPage = 10;

            var beatmaps = new List<BeatmapViewModel>();
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
            BeatmapConverter.ToModel(beatmapRepository.GetBeatmaps(queryBuilder)).ForEach(b => beatmaps.Add(new BeatmapViewModel(b)));

            int pageAmount = (int)Math.Ceiling((float)beatmapRepository.GetSelectCount(queryBuilder) / amountPerPage);
            var beatmapListVM = new BeatmapListViewModel(pageAmount, page, beatmaps);
            return View(beatmapListVM);
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
