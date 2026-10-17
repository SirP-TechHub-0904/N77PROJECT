using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace RazorWebUI.Areas.Content.Pages.ITestimony
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin,Editor")]

    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Testimony Testimony { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Testimony = await _context.Testimonies.FirstOrDefaultAsync(m => m.Id == id);

            if (Testimony == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Testimony = await _context.Testimonies.FindAsync(id);

            if (Testimony != null)
            {
                _context.Testimonies.Remove(Testimony);
                await _context.SaveChangesAsync(); TempData["success"] = "Successful";
            }

            return RedirectToPage("./Index");
        }
    }
}
