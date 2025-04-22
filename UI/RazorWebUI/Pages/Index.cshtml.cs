using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace RazorWebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public IndexModel(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }
       

        public List<Slider> Slider { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public List<PageCategory> Pages { get; set; }
        public List<WebPage> SinglePages { get; set; }
        public List<WebPage> TopPages { get; set; }
        public List<WebPage> LinkExternal { get; set; }
        public List<ProductCategory> ProductPage { get; set; }
        public List<BlogCategory> BlogCategory { get; set; }
        public List<Product> HomeProduct { get; set; }
        public List<Blog> HomeBlog { get; set; }
        public List<Testimony> HomeTestimony { get; set; }
        public List<PageSection> PageSectionsTop { get; set; }
        public List<PageSection> PageSectionsDown { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {

            
             

            var xxsetting = await _context.SuperSettings.FirstOrDefaultAsync();


            const string cacheKey = "SliderViewComponentData123";

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

                var homeproduct = await _context.Products
                    .Include(x => x.ProductFeatures)
                    .Where(x => x.ShowInHome == true)
                    .OrderBy(x => x.SortOrder)
                    .Take(6) // Limit the result to top 6 items
                    .ToListAsync();

                var blog = await _context.Blogs
                  .Where(x => x.Publish == true)
                  .OrderByDescending(x => x.Date)
                  .ThenBy(x => x.SortOrder)
                  .Take(4)
                  .ToListAsync();

                var testimony = await _context.Testimonies
                   .Where(x => x.Show == true)
                   .OrderBy(x => x.SortOrder)
                   .Take(4)
                   .ToListAsync();

                var pagesection = await _context.PageSections
                    .Include(x => x.PageSectionLists)
                    .Where(x => x.Disable == false)
                    .ToListAsync();

                var top = pagesection.Where(x => x.ShowInHome == true && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Top)
                                             .OrderBy(x => x.HomePageSortOrder).Take(3).ToList();
                var bottom = pagesection.Where(x => x.ShowInHome == true && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Bottom)
                                             .OrderBy(x => x.HomePageSortOrder).Take(3).ToList();
                // Save fetched data into a cache object
                cachedData = new CachedSliderViewComponentData
                {
                    _Slider = slider,
                    _Setting = setting,
                    _SuperSetting = xxsetting,
                    _Pages = pages,
                    _SinglePages = singlePages,
                    _TopPages = topPages,
                    _LinkExternal = linkExternal,
                    _ProductPage = productPage,
                    _BlogCategory = blogCategory,
                    _HomeProduct = homeproduct,
                    _HomeTestimony = testimony,
                    _HomeBlog = blog,
                    _PageSectionsTop = top,
                    _PageSectionsDown = bottom
                };

                // Cache the data with an expiration of 30 minutes
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetSize(50);
                _memoryCache.Set(cacheKey, cachedData, cacheEntryOptions);
            }

            // Set ViewBag values from cached data
            SuperSetting = cachedData._SuperSetting;
            Setting = cachedData._Setting;
            Pages = cachedData._Pages;
            SinglePages = cachedData._SinglePages;
            TopPages = cachedData._TopPages;
            LinkExternal = cachedData._LinkExternal;
            ProductPage = cachedData._ProductPage;
            BlogCategory = cachedData._BlogCategory;
            Slider = cachedData._Slider;
            HomeProduct = cachedData._HomeProduct;
            HomeBlog = cachedData._HomeBlog;
            HomeTestimony = cachedData._HomeTestimony;
            PageSectionsTop = cachedData._PageSectionsTop;
            PageSectionsDown = cachedData._PageSectionsDown;
            return Page();
        }
    }


    public class CachedSliderViewComponentData
    {
        public List<Slider> _Slider { get; set; }
        public Setting _Setting { get; set; }
        public SuperSetting _SuperSetting { get; set; }
        public List<PageCategory> _Pages { get; set; }
        public List<WebPage> _SinglePages { get; set; }
        public List<WebPage> _TopPages { get; set; }
        public List<WebPage> _LinkExternal { get; set; }
        public List<ProductCategory> _ProductPage { get; set; }
        public List<Product> _HomeProduct { get; set; }
        public List<BlogCategory> _BlogCategory { get; set; }
        public List<Blog> _HomeBlog { get; set; }
        public List<Testimony> _HomeTestimony { get; set; }
        public List<PageSection> _PageSectionsTop { get; set; }
        public List<PageSection> _PageSectionsDown { get; set; }

    }

}