
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

    public class BlogHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public BlogHomeViewComponent(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Define a unique cache key
            const string cacheKey = "BlogHomeData";

            // Try to get the data from cache
            if (!_memoryCache.TryGetValue(cacheKey, out CachedBlogData cachedData))
            {
                // Data not found in cache, fetch from database
                var blog = await _context.Blogs
                    .Where(x => x.Publish == true)
                    .OrderByDescending(x => x.Date)
                    .ThenBy(x => x.SortOrder)
                    .Take(4)
                    .ToListAsync();

                var setting = await _context.Settings.FirstOrDefaultAsync();
                var suppersetting = await _context.SuperSettings.FirstOrDefaultAsync();

                // Populate the cache data object
                cachedData = new CachedBlogData
                {
                    Blog = blog,
                    Setting = setting,
                    Suppersetting = suppersetting
                };

                // Cache the data with an expiration time of 30 minutes
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(50); // Optional: size if cache size limit is configured

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            // Set ViewBag values from cached data
            ViewBag.sxt = cachedData.Setting;
            ViewBag.suppersetting = cachedData.Suppersetting;

            // Return the blog data to the view
            return View(cachedData.Blog);
        }
    }

    // Helper class to encapsulate cached data
    public class CachedBlogData
    {
        public List<Blog> Blog { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting Suppersetting { get; set; }
    }


    //public class BlogHomeViewComponent : ViewComponent
    //{
    //    private readonly AppDbContext _context;

    //    public BlogHomeViewComponent(
    //        AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public string UserInfo { get; set; }

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {

    //        var blog = await _context.Blogs.Where(x => x.Publish == true).OrderByDescending(x=>x.Date).ThenBy(x=>x.SortOrder).Take(4).ToListAsync();
    //        var setting = await _context.Settings.FirstOrDefaultAsync();
    //        var suppersetting = await _context.SuperSettings.FirstOrDefaultAsync();
    //        ViewBag.sxt = setting;
    //        ViewBag.suppersetting = suppersetting;
    //        return View(blog);
    //    }
    //}

}
