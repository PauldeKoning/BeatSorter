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
        private readonly IBeatmapRepository beatmapRepository;

        public HomeController(IBeatmapRepository beatmapRepository)
        {
            this.beatmapRepository = beatmapRepository;
        }

        public IActionResult Index()
        {
            BeatmapViewModel viewModel = new BeatmapViewModel(BeatmapConverter.ToModel(beatmapRepository.GetBeatmapById(1)));
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
    }
}
