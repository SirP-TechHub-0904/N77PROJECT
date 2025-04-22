using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages
{
    public class UHSourceModel : PageModel
    {
        private readonly AppDbContext _context;

        public UHSourceModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; }
        public SuperSetting SuperSetting { get; set; }
         public Setting Setting { get; set; }
        public string Templatechoose { get; set; }
        public string TitleContent { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync();

            var superSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            if (superSetting == null)
            {

                return RedirectToPage("/AuthVadmin/Readonly", new { area = "V2" });
            }

            SuperSetting = superSetting;
             
            Templatechoose = superSetting.TemplateLayoutKey;

            Product = await _context.Products.Include(x => x.ProductFeatures).ToListAsync();
            if(id > 0)
            {
                var category = await _context.ProductCategories
                    .Include(x=>x.Product).ThenInclude(x=>x.ProductFeatures)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if(category != null)
                {
                    Product = Product.Where(x => x.ProductCategoryId == id).ToList();
                    TitleContent = "FOR " + category.Title;
                }

            }
            Setting = await _context.Settings.FirstOrDefaultAsync();
             
            return Page();
        }
    }
}
