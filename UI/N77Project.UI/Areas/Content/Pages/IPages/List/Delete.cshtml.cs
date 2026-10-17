using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace RazorWebUI.Areas.Content.Pages.IPages.List
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
        public PageSectionList PageSectionList { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PageSectionList = await _context.PageSectionLists
                .Include(p => p.PageSection).FirstOrDefaultAsync(m => m.Id == id);

            if (PageSectionList == null)
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

            PageSectionList = await _context.PageSectionLists.FindAsync(id);

            if (PageSectionList != null)
            {
                _context.PageSectionLists.Remove(PageSectionList);
                await _context.SaveChangesAsync(); TempData["success"] = "Successful";
            }
            return RedirectToPage("/IPages/Section/Details", new { id = PageSectionList.PageSectionId });

         }
    }
}
