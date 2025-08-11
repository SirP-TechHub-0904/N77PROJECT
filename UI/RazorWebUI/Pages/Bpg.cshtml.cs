using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class BpgModel : PageModel
    {
        private readonly AppDbContext _context;

        public BpgModel(AppDbContext context)
        {
            _context = context;
        }

        public string Templatechoose { get; set; }
        public Setting Setting { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public IList<Blog> Blogs { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
             var setting = await _context.Settings.FirstOrDefaultAsync();
             
            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {
               
                return RedirectToPage("/AuthVadmin/Readonly", new {area="V2"});
            }
            SuperSetting = superSetting;

            Templatechoose = SuperSetting.TemplateLayoutKey;
            
            Blogs = await _context.Blogs.Where(x => x.Publish == true).OrderByDescending(x => x.Date).ToListAsync();
            Setting = await _context.Settings.FirstOrDefaultAsync();
             return Page();
        }
    }
}
