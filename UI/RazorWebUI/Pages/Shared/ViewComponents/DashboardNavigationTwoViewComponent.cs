using Amazon.S3;
using Infrastructure.Context;
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
    public class DashboardNavigationTwoViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
         
        public DashboardNavigationTwoViewComponent(
            AppDbContext context)
        {
            _context = context;
        }

 
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var xsetting = await _context.SuperSettings.FirstOrDefaultAsync();
            return View(xsetting);
        }
    }
}
