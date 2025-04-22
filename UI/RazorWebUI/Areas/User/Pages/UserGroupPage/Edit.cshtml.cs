using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.User.Pages.UserGroupPage
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context) => _context = context;

        [BindProperty] public UserCategory UserCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            UserCategory = await _context.UserCategories.FindAsync(id);
            return UserCategory == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.Attach(UserCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
