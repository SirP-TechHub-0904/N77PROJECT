using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class SourceModel : PageModel
    {
        private readonly AppDbContext _context;

        public SourceModel(AppDbContext context)
        {
            _context = context;
        }

        public WebPage WebPage { get; set; }
        public string Templatechoose { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }

            Templatechoose = superSetting.TemplateLayoutKey;
            SuperSetting = superSetting;

            if (id == null)
            {
                return NotFound();
            }
            if(id == 000)
            {
                return RedirectToPage("/Contact");
            }
            WebPage = await _context.WebPages.FirstOrDefaultAsync(m => m.Id == id);

            if (WebPage == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
