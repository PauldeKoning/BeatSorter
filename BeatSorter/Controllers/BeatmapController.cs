using BeatSorter.Repositories.Interfaces;
using BeatSorter.Util.Converters;
using BeatSorter.ViewModels;
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

        public IActionResult List(int page = 0)
        {
            int amountPerPage = 10;

            var beatmaps = new List<BeatmapViewModel>();
            BeatmapConverter.ToModel(beatmapRepository.GetBeatmapsPaginated(amountPerPage, page).ToList()).ForEach(b => beatmaps.Add(new BeatmapViewModel(b)));

            int pageAmount = (int)Math.Ceiling(Convert.ToDouble(beatmapRepository.GetSelectCount() / amountPerPage));
            var beatmapListVM = new BeatmapListViewModel(pageAmount, page, beatmaps);
            return View(beatmapListVM);
        }
    }
}
