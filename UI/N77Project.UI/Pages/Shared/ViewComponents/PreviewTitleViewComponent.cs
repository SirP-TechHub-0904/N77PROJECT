

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class PreviewTitleViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public PreviewTitleViewComponent(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long secid)
        {
            var pagesec = await _context.PageSections
                .Include(x => x.WebPage)
                .Include(x => x.WebPage.PageCategory)
                .FirstOrDefaultAsync(x=>x.Id == secid);
              
            return View(pagesec);
        }
    }
}
