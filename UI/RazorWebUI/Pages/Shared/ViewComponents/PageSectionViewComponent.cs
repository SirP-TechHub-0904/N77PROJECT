
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
    public class PageSectionViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public PageSectionViewComponent(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? position, string? pageset, long? id, long? secid, int? takex)
        {
            // Define a default limit
            int takeLimit = takex ?? 300;

            // Store data for ViewBag
            string cacheKey = $"PageSections_{position}_{pageset}_{id}_{secid}_{takeLimit}";

            // Attempt to retrieve cached data
            if (!_memoryCache.TryGetValue(cacheKey, out CachedPageSectionData cachedData))
            {
                // Data not found in cache, query database
                var setting = await _context.SuperSettings.FirstOrDefaultAsync();

                var pageQuery = _context.PageSections
                    .Include(x => x.PageSectionLists)
                    .Where(x => x.Disable == false)
                    .AsQueryable();

                // Build query based on parameters
                if (!string.IsNullOrEmpty(position) && !string.IsNullOrEmpty(pageset))
                {
                    if (position.ToLower() == "top" && pageset.ToLower() == "home")
                    {
                        pageQuery = pageQuery.Where(x => x.ShowInHome == true && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Top)
                                             .OrderBy(x => x.HomePageSortOrder);
                    }
                    else if (position.ToLower() == "bottom" && pageset.ToLower() == "home")
                    {
                        pageQuery = pageQuery.Where(x => x.ShowInHome == true && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Bottom)
                                             .OrderBy(x => x.HomePageSortOrder);
                    }
                }

                if (!string.IsNullOrEmpty(position))
                {
                    if (position.ToLower() == "fixed")
                    {
                        pageQuery = pageQuery.Where(x => x.FixedAfterFooter == true)
                                             .OrderBy(x => x.HomePageSortOrder);
                    }
                    else if (position.ToLower() == "footer")
                    {
                        pageQuery = pageQuery.Where(x => x.FixedAfterFooter == true)
                                             .OrderBy(x => x.HomePageSortOrder);
                    }
                }

                if (string.IsNullOrEmpty(position) && id.HasValue && id > 0)
                {
                    pageQuery = pageQuery.Where(x => x.WebPageId == id)
                                         .OrderBy(x => x.PageSortOrder);
                }

                if (string.IsNullOrEmpty(position) && secid.HasValue && secid > 0)
                {
                    pageQuery = pageQuery.Where(x => x.Id == secid)
                                         .OrderBy(x => x.PageSortOrder);
                }

                // Apply limit and execute query
                var pageSections = await pageQuery.Take(takeLimit).ToListAsync();

                // Populate cached data
                cachedData = new CachedPageSectionData
                {
                    PageSections = pageSections,
                    Setting = setting,
                    Themedata = setting?.TemplateLayoutKey,
                    Pageset = pageset,
                    Take3 = takex == 3 ? 3 : 300
                };

                // Cache the data with expiration
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(1); // Optional size if size limit is configured

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            // Populate ViewBag from cached data
            ViewBag.themedata = cachedData.Themedata;
            ViewBag.pageset = cachedData.Pageset;
            ViewBag.take3 = cachedData.Take3;

            // Return the cached PageSections to the view
            return View(cachedData.PageSections);
        }
    }

    // Helper class to store cached data
    public class CachedPageSectionData
    {
        public List<PageSection> PageSections { get; set; }
        public SuperSetting Setting { get; set; }
        public string Themedata { get; set; }
        public string Pageset { get; set; }
        public int Take3 { get; set; }
    }


}





//namespace JurayUniversal.Pages.Shared.ViewComponents
//{
//    public class PageSectionViewComponent : ViewComponent
//    {
//        private readonly AppDbContext _context;

//        public PageSectionViewComponent(
//            AppDbContext context)
//        {
//            _context = context;
//        }


//        public async Task<IViewComponentResult> InvokeAsync(string? position, string? pageset, long? id, long? secid, int? takex)
//        {
//            if (takex == 3)
//            {
//                ViewBag.take3 = takex;
//            }
//            else
//            {
//                ViewBag.take3 = 300;
//            }
//            var setting = await _context.SuperSettings.FirstOrDefaultAsync();
//            ViewBag.themedata = setting.TemplateLayoutKey;
//            ViewBag.pageset = pageset;
//            var page = _context.PageSections.Include(x => x.PageSectionLists).Where(x=>x.Disable == false).AsQueryable();
//            if (!String.IsNullOrEmpty(position) && !String.IsNullOrEmpty(pageset))
//            {
//                if (position.ToLower() == "top" && pageset.ToLower() == "home")
//                {
//                    page = page.Where(x => x.ShowInHome == true && x.HomeSortFrom == HomeSortFrom.Top).OrderBy(x => x.HomePageSortOrder).AsQueryable();
//                    return View(await page.ToListAsync());
//                }
//            }
//            if (!String.IsNullOrEmpty(position))
//            {
//                if (position.ToLower() == "fixed")
//                {
//                    page = page.Where(x => x.FixedAfterFooter == true).OrderBy(x => x.HomePageSortOrder).AsQueryable();
//                    return View(await page.ToListAsync());
//                }
//            }
//            if (!String.IsNullOrEmpty(position) && !String.IsNullOrEmpty(pageset))
//            {
//                if (position.ToLower() == "bottom" && pageset.ToLower() == "home")
//                {
//                    page = page.Where(x => x.ShowInHome == true && x.HomeSortFrom == HomeSortFrom.Bottom).OrderBy(x => x.HomePageSortOrder).AsQueryable();
//                    return View(await page.ToListAsync());
//                }
//            }

//            if (String.IsNullOrEmpty(position) && id != null)
//            {
//                if (id > 0)
//                {
//                    page = page.Where(x => x.Disable == false && x.WebPageId == id).OrderBy(x => x.PageSortOrder).AsQueryable();
//                    return View(await page.ToListAsync());
//                }
//            }
//            if (String.IsNullOrEmpty(position) && secid != null)
//            {
//                if (secid > 0)
//                {
//                    page = page.Where(x => x.Disable == false && x.Id == secid).OrderBy(x => x.PageSortOrder).AsQueryable();
//                    return View(await page.ToListAsync());
//                }
//            }
//            if (!String.IsNullOrEmpty(position))
//            {
//                if (position.ToLower() == "footer")
//                {
//                    page = page.Where(x => x.FixedAfterFooter == true).OrderBy(x => x.HomePageSortOrder).AsQueryable();
//                    return View(await page.ToListAsync());
//                }
//            }


//            return View(await page.Where(x => x.WebPageId == 000).ToListAsync());
//        }
//    }
//}
