using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class Bpg_infoModel : PageModel
    {
        private readonly AppDbContext _context;

        public Bpg_infoModel(AppDbContext context)
        {
            _context = context;
        }

        public string Templatechoose { get; set; }
        public Blog Blog { get; set; }
        public IList<Blog> Blogs { get; set; }
        public IList<BlogCategory> BlogCategories { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public Setting Setting { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blogs
                .Include(b => b.BlogCategory).FirstOrDefaultAsync(m => m.Id == id);

            if (Blog == null)
            {
                return NotFound();
            }
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }

            Templatechoose = superSetting.TemplateLayoutKey;
            SuperSetting = superSetting;
            Blogs = await _context.Blogs.Where(x => x.Id != Blog.Id).Take(8).ToListAsync();
            BlogCategories = await _context.BlogCategories.Include(x=>x.Blogs).Take(10).ToListAsync();
            Setting = await _context.Settings.FirstOrDefaultAsync();
 
            return Page();
        }
    }
}
