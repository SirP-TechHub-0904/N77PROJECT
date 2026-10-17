using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class TpgModel : PageModel
    {
        private readonly AppDbContext _context;

        public TpgModel(AppDbContext context)
        {
            _context = context;
        }

        public string Templatechoose { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public IList<Testimony> Testimonies { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }
            Templatechoose = superSetting.TemplateLayoutKey;
            SuperSetting = superSetting;

            Testimonies = await _context.Testimonies.ToListAsync();
            return Page();
        }
    }
}
