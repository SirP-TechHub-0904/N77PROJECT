
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages.Shared.ViewComponents
{
    public class NewsRibonViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public NewsRibonViewComponent(
            AppDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var setting = await _context.Settings.FirstOrDefaultAsync();
            ViewBag.rbTitle = setting.BreakingNewsRibonTitle;
            List<RibonDto> rb = new List<RibonDto>();
            var page = await _context.PageSections.Where(x => x.AddToRibon == true).ToListAsync();

            var firstlist = page.Select(x=> new RibonDto
            {
                Id = x.ButtonLink,
                Path = "/Source",
                Title = x.RibonCustomDisplayTitle != null ? x.RibonCustomDisplayTitle : x.Title,
                SortOrder = x.RibonSortOrder,
                PathDirectUrl = x.DirectUrl,
            }); 

             rb.AddRange(firstlist);
            ///
            var pagelist = await _context.PageSectionLists.Where(x => x.AddToRibon == true).ToListAsync();

            var secondlist = pagelist.Select(x => new RibonDto
            {
                Id = x.ButtonLink,
                Path = "/Source",
                Title = x.RibonCustomDisplayTitle != null ? x.RibonCustomDisplayTitle : x.Title,
                SortOrder = x.RibonSortOrder,
                PathDirectUrl = x.DirectUrl,
                //EnableDirectUrl = x.DirectUrl
            });

            rb.AddRange(secondlist);
            ///
            var blog = await _context.Blogs.Where(x => x.AddToRibon == true).ToListAsync();

            var bloglist = blog.Select(x => new RibonDto
            {
                Id = x.Id.ToString(),
                Path = "/Bpg_info",
                Title = x.RibonCustomDisplayTitle != null ? x.RibonCustomDisplayTitle : x.Title,
                SortOrder = x.RibonSortOrder
            });

            rb.AddRange(bloglist);

            return View(rb.OrderBy(x=>x.SortOrder).ToList());
        }

        
        
    }

    public class RibonDto
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public string PathDirectUrl { get; set; } 
        public string Title { get; set; }
        public int SortOrder {  get; set; }
    }
}
