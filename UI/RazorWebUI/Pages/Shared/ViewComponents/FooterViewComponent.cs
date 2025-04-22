
using Domain.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public FooterViewComponent(
            AppDbContext context,
            IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
            // Define cache key
            string cacheKey = $"FooterData_{key}";

            // Try to fetch from cache
            if (!_memoryCache.TryGetValue(cacheKey, out FooterCacheData cachedData))
            {
                // If not in cache, query the database
                var mainWebPages = await _context.WebPages.ToListAsync();

                var pages = mainWebPages
                    .Where(x => x.Publish == true && x.ShowInFooter == true && x.SecurityPage == false && x.EnableDirectUrl == false)
                    .OrderBy(x => x.SortOrder)
                    .ToList();

                var secPages = mainWebPages
                    .Where(x => x.Publish == true && x.ShowInFooter == true && x.SecurityPage == true)
                    .OrderBy(x => x.SortOrder)
                    .ToList();

                var linkExternal = mainWebPages
                    .Where(x => x.Publish == true && x.ShowInFooter == true && x.EnableDirectUrl == true)
                    .ToList();

                var setting = await _context.Settings.FirstOrDefaultAsync();
                var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

                // Populate cached data object
                cachedData = new FooterCacheData
                {
                    Pages = pages,
                    SecPages = secPages,
                    LinkExternal = linkExternal,
                    Setting = setting,
                    SuperSetting = supersetting
                };

                // Cache the data with expiration
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(10); // Optional size if needed

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            // Assign data to ViewBag
            ViewBag.pages = cachedData.Pages;
            ViewBag.SecPages = cachedData.SecPages;
            ViewBag.linkExternal = cachedData.LinkExternal;
            ViewBag.setting = cachedData.Setting;
            ViewBag.supersetting = cachedData.SuperSetting;

            // Return the view
            return View();
        }
    }

    // Helper class to cache footer-related data
    public class FooterCacheData
    {
        public List<WebPage> Pages { get; set; }
        public List<WebPage> SecPages { get; set; }
        public List<WebPage> LinkExternal { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
    }
}



//namespace JurayUniversal.Pages.Shared.ViewComponents
//{
//    public class FooterViewComponent : ViewComponent
//    {
//        private readonly AppDbContext _context;

//        public FooterViewComponent(
//            AppDbContext context)
//        {
//            _context = context;
//        }


//        public async Task<IViewComponentResult> InvokeAsync(string key)
//        {
//            var mainwebpages = await _context.WebPages.ToListAsync();
//            var Pages = mainwebpages.Where(x => x.Publish == true && x.ShowInFooter == true && x.SecurityPage == false && x.EnableDirectUrl == false).OrderBy(x=>x.SortOrder).ToList();
//            ViewBag.pages = Pages;
//            var SecPages = mainwebpages.Where(x => x.Publish == true && x.ShowInFooter == true && x.SecurityPage == true).OrderBy(x => x.SortOrder).ToList();
//            ViewBag.SecPages = SecPages;
//             var linkExternal = mainwebpages.Where(x => x.Publish == true && x.ShowInFooter == true && x.EnableDirectUrl == true).ToList();
//            ViewBag.linkExternal = linkExternal;
//            var setting = await _context.Settings.FirstOrDefaultAsync();
//            ViewBag.setting = setting;

//            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();
//            ViewBag.supersetting = supersetting;
//            return View();
//        }
//    }
//}
