using BeatSorter.Repositories.Interfaces;
using BeatSorter.Util.Converters;
using BeatSorter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BeatSorter.ViewModels;

namespace BeatSorter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBeatmapRepository beatmapRepository;

        public HomeController(ILogger<HomeController> logger, IBeatmapRepository beatmapRepository)
        {
            _logger = logger;
            this.beatmapRepository = beatmapRepository;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = CreateViewModel(BeatmapConverter.ToModel(beatmapRepository.GetBeatmapById(1)));
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IndexViewModel CreateViewModel(Beatmap beatmap)
        {
            return new IndexViewModel()
            {
                Title = beatmap.Title,
                BPM = beatmap.BPM,
                LevelAuthor = beatmap.LevelAuthor,
                Uploader = beatmap.Uploader,
                DifficultyNames = beatmap.DifficultyNames,
                DifficultyTypes = beatmap.DifficultyTypes
            };
        }
    }
}
