using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace RazorWebUI.Areas.Management.Pages.IConfigSettings
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public DataConfig DataConfig { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            DataConfig = await _context.DataConfigs.FirstOrDefaultAsync();

            if (DataConfig == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
