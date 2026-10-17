using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace RazorWebUI.Areas.Content.Pages.IPages.Category
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin,Editor")]

    public class DetailsModel : PageModel
    {
        private readonly AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public PageCategory PageCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PageCategory = await _context.PageCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (PageCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
