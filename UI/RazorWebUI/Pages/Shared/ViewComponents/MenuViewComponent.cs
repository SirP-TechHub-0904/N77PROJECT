
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
    public class MenuViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public MenuViewComponent(
            AppDbContext context,
            IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
            // Define cache key
            string cacheKey = $"MenuData_{key}";

            // Try to fetch from cache
            if (!_memoryCache.TryGetValue(cacheKey, out MenuCacheData cachedData))
            {
                // If not in cache, query the database
                var pages = await _context.PageCategories
                    .Include(x => x.WebPages)
                    .Where(x => x.Publish == true)
                    .OrderBy(x => x.MenuSortOrder)
                    .ToListAsync();

                var mainwebpages = await _context.WebPages.ToListAsync();

                var singlePages = mainwebpages
                    .Where(x => x.Publish == true && x.ShowInMainMenu == true)
                    .ToList();

                var topPages = mainwebpages
                    .Where(x => x.Publish == true && x.ShowInMainTop == true)
                    .ToList();

                var linkExternal = mainwebpages
                    .Where(x => x.Publish == true && x.ShowInMainMenu == true && x.EnableDirectUrl == true)
                    .ToList();

                var linkExternalDropdown =  mainwebpages
                    .Where(x => x.Publish == true && x.ShowInMenuDropDown == true && x.EnableDirectUrl == true)
                    .ToList();

                var productPage = await _context.ProductCategories
                    .Where(x => x.Publish == true)
                    .ToListAsync();

                var setting = await _context.Settings.FirstOrDefaultAsync();
                var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

                // Populate the cache data object
                cachedData = new MenuCacheData
                {
                    Pages = pages,
                    SinglePages = singlePages,
                    TopPages = topPages,
                    LinkExternal = linkExternal,
                    LinkExternalDropdown = linkExternalDropdown,
                    ProductPage = productPage,
                    Setting = setting,
                    SuperSetting = supersetting
                };

                // Set the data in cache with expiration policy
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(50); // Optional size if needed

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            // Assign data to ViewBag
            ViewBag.pages = cachedData.Pages;
            ViewBag.singlePages = cachedData.SinglePages;
            ViewBag.topPages = cachedData.TopPages;
            ViewBag.linkExternal = cachedData.LinkExternal;
            ViewBag.linkExternalDropdown = cachedData.LinkExternalDropdown;
            ViewBag.productpage = cachedData.ProductPage;
            ViewBag.setting = cachedData.Setting;
            ViewBag.supersetting = cachedData.SuperSetting;

            // Return the view with the setting object
            return View(cachedData.Setting);
        }
    }

    // Helper class to cache menu-related data
    public class MenuCacheData
    {
        public List<PageCategory> Pages { get; set; }
        public List<WebPage> SinglePages { get; set; }
        public List<WebPage> TopPages { get; set; }
        public List<WebPage> LinkExternal { get; set; }
        public List<WebPage> LinkExternalDropdown { get; set; }
        public List<ProductCategory> ProductPage { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
    }
}



//namespace JurayUniversal.Pages.Shared.ViewComponents
//{
//    public class MenuViewComponent : ViewComponent
//    {
//        private readonly AppDbContext _context;

//        public MenuViewComponent(
//            AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IViewComponentResult> InvokeAsync(string key)
//        {

//            var Pages = await _context.PageCategories.Include(x=>x.WebPages).Where(x => x.Publish == true).OrderBy(x=>x.MenuSortOrder).ToListAsync();
//            ViewBag.pages = Pages;

//            var singlePages = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMainMenu == true).ToListAsync();
//            ViewBag.singlePages = singlePages;

//            var topPages = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMainTop == true).ToListAsync();
//            ViewBag.topPages = topPages;

//            var linkExternal = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMainMenu == true && x.EnableDirectUrl == true).ToListAsync();
//            ViewBag.linkExternal = linkExternal;

//            var linkExternalDropdown = await _context.WebPages.Where(x => x.Publish == true && x.ShowInMenuDropDown == true && x.EnableDirectUrl == true).ToListAsync();
//            ViewBag.linkExternalDropdown = linkExternalDropdown;


//            var productpage = await _context.ProductCategories.Where(x => x.Publish == true).ToListAsync();
//            ViewBag.productpage = productpage;

//            var setting = await _context.Settings.FirstOrDefaultAsync();
//            ViewBag.setting = setting;

//            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();
//            ViewBag.supersetting = supersetting;
//            return View(setting);
//        }
//    }
//}
