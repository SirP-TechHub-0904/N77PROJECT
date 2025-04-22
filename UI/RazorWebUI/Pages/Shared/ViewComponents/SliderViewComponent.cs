

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Domain.Models;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public SliderViewComponent(
            AppDbContext context,
            IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            const string cacheKey = "SliderViewComponentData";

            // Check if data is already cached
            if (!_memoryCache.TryGetValue(cacheKey, out CachedSliderViewComponentData cachedData))
            {
                // Data not cached, fetch from database
                var slider = await _context.Sliders
                    .Where(x => x.Show == true)
                    .OrderBy(x => x.SortOrder)
                    .Take(4)
                    .ToListAsync();

                var setting = await _context.Settings.FirstOrDefaultAsync();
                var xxsetting = await _context.SuperSettings.FirstOrDefaultAsync();
                var pages = await _context.PageCategories
                    .Include(x => x.WebPages)
                    .Where(x => x.Publish == true)
                    .OrderBy(x => x.MenuSortOrder)
                    .ToListAsync();

                var singlePages = await _context.WebPages
                    .Where(x => x.Publish == true && x.ShowInMainMenu == true)
                    .ToListAsync();

                var topPages = await _context.WebPages
                    .Where(x => x.Publish == true && x.ShowInMainTop == true)
                    .ToListAsync();

                var linkExternal = await _context.WebPages
                    .Where(x => x.Publish == true && x.ShowInMainTop == true && x.EnableDirectUrl == true)
                    .ToListAsync();

                var productPage = await _context.ProductCategories
                    .Where(x => x.Publish == true)
                    .ToListAsync();

                var blogCategory = await _context.BlogCategories
                    .Where(x => x.Publish == true)
                    .ToListAsync();

                // Save fetched data into a cache object
                cachedData = new CachedSliderViewComponentData
                {
                    Slider = slider,
                    Setting = setting,
                    SuperSetting = xxsetting,
                    Pages = pages,
                    SinglePages = singlePages,
                    TopPages = topPages,
                    LinkExternal = linkExternal,
                    ProductPage = productPage,
                    BlogCategory = blogCategory
                };

                // Cache the data with an expiration of 30 minutes
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(50);
                _memoryCache.Set(cacheKey, cachedData, cacheEntryOptions);
            }

            // Set ViewBag values from cached data
            ViewBag.superx = cachedData.SuperSetting;
            ViewBag.setting = cachedData.Setting;
            ViewBag.pages = cachedData.Pages;
            ViewBag.singlePages = cachedData.SinglePages;
            ViewBag.topPages = cachedData.TopPages;
            ViewBag.linkExternal = cachedData.LinkExternal;
            ViewBag.productpage = cachedData.ProductPage;
            ViewBag.blogcategory = cachedData.BlogCategory;

            return View(cachedData.Slider);
        }
    }

    // Helper class to hold cached data
    public class CachedSliderViewComponentData
    {
        public List<Slider> Slider { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public List<PageCategory> Pages { get; set; }
        public List<WebPage> SinglePages { get; set; }
        public List<WebPage> TopPages { get; set; }
        public List<WebPage> LinkExternal { get; set; }
        public List<ProductCategory> ProductPage { get; set; }
        public List<BlogCategory> BlogCategory { get; set; }
    }
}

//namespace JurayUniversal.Pages.Shared.ViewComponents
//{
//    public class SliderViewComponent : ViewComponent
//    {
//        private readonly AppDbContext _context;

//        public SliderViewComponent(
//            AppDbContext context)
//        {
//            _context = context;
//        }

//        public string UserInfo { get; set; }

//        public async Task<IViewComponentResult> InvokeAsync()
//        {

//            var slider = await _context.Sliders.Where(x => x.Show == true).OrderBy(x=>x.SortOrder).Take(4).ToListAsync();
//            var setting = await _context.Settings.FirstOrDefaultAsync();
//            var xxsetting = await _context.SuperSettings.FirstOrDefaultAsync();
//            ViewBag.superx = xxsetting;
//            ViewBag.setting = setting;
//            var Pages = await _context.PageCategories.Include(x => x.WebPages).Where(x => x.Publish == true).OrderBy(x => x.MenuSortOrder).ToListAsync();
//            ViewBag.pages = Pages;

//            var singlePages = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMainMenu == true).ToListAsync();
//            ViewBag.singlePages = singlePages;

//            var topPages = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMainTop == true).ToListAsync();
//            ViewBag.topPages = topPages;

//            var linkExternal = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMainTop == true && x.EnableDirectUrl == true).ToListAsync();
//            ViewBag.linkExternal = topPages;
//            var productpage = await _context.ProductCategories.Where(x => x.Publish == true).ToListAsync();
//            ViewBag.productpage = productpage;

//            var blogcategory = await _context.BlogCategories.Where(x => x.Publish == true).ToListAsync();
//            ViewBag.blogcategory = blogcategory;
//            return View(slider);
//        }
//    }
//}
