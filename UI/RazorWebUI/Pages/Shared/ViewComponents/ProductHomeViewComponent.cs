
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
    public class ProductHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public ProductHomeViewComponent(
            AppDbContext context,
            IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
            // Define cache key
            string cacheKey = $"ProductHomeData_{key}";

            // Try to fetch from cache
            if (!_memoryCache.TryGetValue(cacheKey, out ProductHomeCacheData cachedData))
            {
                // If not in cache, query the database
                var setting = await _context.Settings.FirstOrDefaultAsync();
                var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

                var page = await _context.Products
                    .Include(x => x.ProductFeatures)
                    .Where(x => x.ShowInHome == true)
                    .OrderBy(x => x.SortOrder)
                    .Take(6) // Limit the result to top 6 items
                    .ToListAsync();

                // Populate cached data object
                cachedData = new ProductHomeCacheData
                {
                    Setting = setting,
                    SuperSetting = supersetting,
                    Products = page
                };

                // Cache the data with expiration
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(10); // Optional size if needed

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            // Assign data to ViewBag
            ViewBag.setting = cachedData.Setting;
            ViewBag.suppersetting = cachedData.SuperSetting;

            // Return the view with the cached products
            return View(cachedData.Products);
        }
    }

    // Helper class to cache product home data
    public class ProductHomeCacheData
    {
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public List<Product> Products { get; set; }
    }
}


//namespace JurayUniversal.Pages.Shared.ViewComponents
//{
//    public class ProductHomeViewComponent : ViewComponent
//    {
//        private readonly AppDbContext _context;

//        public ProductHomeViewComponent(
//            AppDbContext context)
//        {
//            _context = context;
//        }


//        public string UserInfo { get; set; }

//        public async Task<IViewComponentResult> InvokeAsync(string key)
//        {
//            var setting = await _context.Settings.FirstOrDefaultAsync();
//            var suppersetting = await _context.SuperSettings.FirstOrDefaultAsync();
//            ViewBag.setting = setting;
//            ViewBag.suppersetting = suppersetting;


//            var page = await _context.Products.Include(x=>x.ProductFeatures).Where(x => x.ShowInHome == true).OrderBy(x => x.SortOrder).ToListAsync();

//            page = page.Take(6).ToList();

//            return View(page);
//        }
//    }
//}
