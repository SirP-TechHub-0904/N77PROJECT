using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.Management.Pages.V3
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin")]

    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SuperSetting SuperSetting { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync(m => m.Id == id);

            if (SuperSetting == null)
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

            SuperSetting = await _context.SuperSettings.FindAsync(id);

            if (SuperSetting != null)
            {
                _context.SuperSettings.Remove(SuperSetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
