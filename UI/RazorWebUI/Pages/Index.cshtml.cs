using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
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
            SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();

            Slider = await _context.Sliders
                .Where(x => x.Show == true)
                .OrderBy(x => x.SortOrder)
                .Take(4)
                .ToListAsync();

            Setting = await _context.Settings.FirstOrDefaultAsync();

            Pages = await _context.PageCategories
                .Include(x => x.WebPages)
                .Where(x => x.Publish == true)
                .OrderBy(x => x.MenuSortOrder)
                .ToListAsync();

            SinglePages = await _context.WebPages
                .Where(x => x.Publish == true && x.ShowInMainMenu == true)
                .ToListAsync();

            TopPages = await _context.WebPages
                .Where(x => x.Publish == true && x.ShowInMainTop == true)
                .ToListAsync();

            LinkExternal = await _context.WebPages
                .Where(x => x.Publish == true && x.ShowInMainTop == true && x.EnableDirectUrl == true)
                .ToListAsync();

            ProductPage = await _context.ProductCategories
                .Where(x => x.Publish == true)
                .ToListAsync();

            BlogCategory = await _context.BlogCategories
                .Where(x => x.Publish == true)
                .ToListAsync();

            HomeProduct = await _context.Products
                .Include(x => x.ProductFeatures)
                .Where(x => x.ShowInHome == true)
                .OrderBy(x => x.SortOrder)
                .Take(6)
                .ToListAsync();

            HomeBlog = await _context.Blogs
                .Where(x => x.Publish == true)
                .OrderByDescending(x => x.Date)
                .ThenBy(x => x.SortOrder)
                .Take(4)
                .ToListAsync();

            HomeTestimony = await _context.Testimonies
                .Where(x => x.Show == true)
                .OrderBy(x => x.SortOrder)
                .Take(4)
                .ToListAsync();

            var pagesection = await _context.PageSections
                .Include(x => x.PageSectionLists)
                .Where(x => x.Disable == false)
                .ToListAsync();

            PageSectionsTop = pagesection
                .Where(x => x.ShowInHome == true && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Top)
                .OrderBy(x => x.HomePageSortOrder)
                .Take(3)
                .ToList();

            PageSectionsDown = pagesection
                .Where(x => x.ShowInHome == true && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Bottom)
                .OrderBy(x => x.HomePageSortOrder)
                .Take(3)
                .ToList();

            return Page();
        }
    }
}
