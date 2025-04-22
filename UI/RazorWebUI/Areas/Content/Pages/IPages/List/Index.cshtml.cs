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

    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<PageSectionList> PageSectionList { get;set; }

        public async Task OnGetAsync()
        {
            PageSectionList = await _context.PageSectionLists
                .Include(p => p.PageSection)
                .Include(p => p.PageSection)

                .ToListAsync();
        }
    }
}
