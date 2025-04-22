using Amazon.S3;

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
    public class RedirectViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
         
        public RedirectViewComponent(
            AppDbContext context)
        {
            _context = context;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var DataConfig = await _context.DataConfigs.FirstOrDefaultAsync();
            
            ViewBag.DataConfigs = DataConfig;
            var xsetting = await _context.SuperSettings.FirstOrDefaultAsync();
            return View(xsetting);
        }
    }
}
