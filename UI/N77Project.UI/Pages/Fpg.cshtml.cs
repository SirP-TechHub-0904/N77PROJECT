using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class FpgModel : PageModel
    {
        private readonly AppDbContext _context;
         public FpgModel(AppDbContext context)
        {
            _context = context;
         }

        public SuperSetting SuperSetting { get; set; }
        public Setting Setting { get; set; }
        public IList<FAQ> FAQs { get; set; }
        public string Templatechoose { get; set; }
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

            FAQs = await _context.FAQs.Where(x => x.Show == true).OrderBy(x => x.SortOrder).ToListAsync();
            Setting = await _context.Settings.FirstOrDefaultAsync(); 
            
            return Page(); 
        }
    }
}
