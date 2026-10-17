using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class CatBpgModel : PageModel
    {
        private readonly AppDbContext _context;
        
        public string Templatechoose { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public IList<Blog> Blogs { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public IList<BlogCategory> BlogCategoryList { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public int TotalPages { get; set; }
        private const int PageSize = 4; // Number of blogs per page.

        public CatBpgModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(long id, string? title)
        {
            var httpContext = HttpContext;
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }

            Templatechoose = superSetting.TemplateLayoutKey;
            SuperSetting = superSetting;
            //Blogs = await _context.Blogs.Where(x => x.Publish == true && x.BlogCategoryId == id).OrderByDescending(x => x.Date).ToListAsync();
            IQueryable<Blog> blogsQuery = _context.Blogs
                .Where(x => x.Publish == true && x.BlogCategoryId == id);

            // Filter by search query if provided
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                blogsQuery = blogsQuery.Where(x => x.Title.Contains(SearchQuery) || x.Description.Contains(SearchQuery));
            }
            // Count total items for pagination
            int totalItems = await blogsQuery.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            // Apply pagination
            Blogs = await blogsQuery
                .OrderByDescending(x => x.Date)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            BlogCategory = await _context.BlogCategories.FirstOrDefaultAsync(x=>x.Id == id);
            BlogCategoryList = await _context.BlogCategories.Where(x=>x.Publish == true).ToListAsync();

            Setting = await _context.Settings.FirstOrDefaultAsync();
            return Page();
        }


    }
}
