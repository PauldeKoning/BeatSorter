using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeatSorter.ViewModels
{
    public class BeatmapListViewModel
    {

        public BeatmapListViewModel(int pageAmount, int page, List<BeatmapViewModel> beatmaps)
        {
            PageAmount = pageAmount;
            Page = page;
            Beatmaps = beatmaps;
        }

        public List<BeatmapViewModel> Beatmaps { get; set; }

        public int PageAmount { get; set; }

        public int Page { get; set; }

        //The number 7 in this context is the amount of numbers in the pagination
        //The number 3 is the amount shown BEFORE current page
        //The number 4 is the amount shown AFTER current page
        public int PaginationStart
        {
            get
            {
                if (PageAmount < 7 || Page - 3 < 0)
                {
                    return 0;
                }
                else
                {
                    //TODO show 7 pages when at last pages
                    return Page - 3;
                }
            }
        }

        public int PaginationEnd
        {
            get
            {
                if (PageAmount < 7 || Page + 4 > PageAmount)
                {
                    return PageAmount;
                }
                else
                {
                    if (Page < 3)
                    {
                        return Page + 4 + (3 - Page);
                    }
                    return Page + 4;
                }
            }
        }

    }
}
