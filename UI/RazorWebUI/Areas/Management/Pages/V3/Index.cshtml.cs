using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.Management.Pages.V3
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin")]

    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public SuperSetting SuperSetting { get; set; }
         public DataConfig DataConfig { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
             
            SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
                          DataConfig = await _context.DataConfigs.FirstOrDefaultAsync();

            return Page();
        }
    }
}
