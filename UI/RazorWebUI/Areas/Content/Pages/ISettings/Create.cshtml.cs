using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.Content.Pages.ISettings
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin,Manager,Admin,Editor")]

    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Setting Setting { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            var se = await _context.Settings.FirstOrDefaultAsync();
            if (se == null)
            {
                _context.Settings.Add(Setting);
                await _context.SaveChangesAsync(); TempData["success"] = "Successful";
            }
            return RedirectToPage("./Index");
        }
    }
}
