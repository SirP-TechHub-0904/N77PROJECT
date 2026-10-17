

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
    public class WebsiteCSSViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public WebsiteCSSViewComponent(
            AppDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();
         var DataConfig = await _context.DataConfigs.FirstOrDefaultAsync();

            ViewBag.DataConfigs = DataConfig;
            return View(supersetting);
        }
    }
}
