using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class UHSource_InfoModel : PageModel
    {
        private readonly AppDbContext _context;

        public UHSource_InfoModel(AppDbContext context)
        {
            _context = context;
        }

        public Setting Setting { get; set; }

        public Product Product { get; set; }
        public SuperSetting SuperSetting { get; set; }
        public string Templatechoose { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }


            Product = await _context.Products
                .Include(x => x.ProductFeatures)
                .Include(x => x.ProductSamples)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
             
            Templatechoose = superSetting.TemplateLayoutKey;
            SuperSetting = superSetting;
            Setting = setting;
            return Page();
        }
    }
}
