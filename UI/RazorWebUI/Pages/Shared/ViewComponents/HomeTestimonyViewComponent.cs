
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
    public class HomeTestimonyViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public HomeTestimonyViewComponent(
            AppDbContext context,
            IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Define a cache key
            string cacheKey = "HomeTestimonyData";

            // Try to retrieve cached data
            if (!_memoryCache.TryGetValue(cacheKey, out HomeTestimonyCacheData cachedData))
            {
                // If data is not in cache, query the database
                var testimony = await _context.Testimonies
                    .Where(x => x.Show == true)
                    .OrderBy(x => x.SortOrder)
                    .Take(4)
                    .ToListAsync();

                var setting = await _context.Settings.FirstOrDefaultAsync();
                var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

                // Populate cached data object
                cachedData = new HomeTestimonyCacheData
                {
                    Testimonies = testimony,
                    Setting = setting,
                    SuperSetting = supersetting
                };

                // Cache the data with expiration
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(10); // Optional size if size limit is configured

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            // Assign data to ViewBag
            ViewBag.sxt = cachedData.Setting;
            ViewBag.suppersetting = cachedData.SuperSetting;

            // Return the cached testimonies to the view
            return View(cachedData.Testimonies);
        }
    }

    // Helper class to cache home testimony data
    public class HomeTestimonyCacheData
    {
        public List<Testimony> Testimonies { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
    }
}




//namespace JurayUniversal.Pages.Shared.ViewComponents
//{
//    public class HomeTestimonyViewComponent : ViewComponent
//    {
//        private readonly AppDbContext _context;

//        public HomeTestimonyViewComponent(
//            AppDbContext context)
//        {
//            _context = context;
//        }


//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var testimony = await _context.Testimonies.Where(x => x.Show == true).OrderBy(x => x.SortOrder).Take(4).ToListAsync();
//            var setting = await _context.Settings.FirstOrDefaultAsync();
//            var suppersetting = await _context.SuperSettings.FirstOrDefaultAsync();
//            ViewBag.sxt = setting;
//            ViewBag.suppersetting = suppersetting;
//            return View(testimony);
//        }
//    }
//}
