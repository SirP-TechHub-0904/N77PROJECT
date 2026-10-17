using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace JURAY.Web.Pages
{
    public class SubmittedModel : PageModel
    {
        private readonly AppDbContext _context;

        public SubmittedModel(AppDbContext context)
        {
            _context = context;
        }

        public SuperSetting SuperSetting { get; set; }
        public Setting Setting { get; set; }
        public IList<FAQ> FAQs { get; set; }
        public string Templatechoose { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Setting = await _context.Settings.FirstOrDefaultAsync();
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }

            SuperSetting = superSetting; return Page();
        }
    }
}
