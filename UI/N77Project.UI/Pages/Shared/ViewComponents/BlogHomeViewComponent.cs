// File: Pages/Shared/ViewComponents/BlogHomeViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class BlogHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public BlogHomeViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blog = await _context.Blogs
                .Where(x => x.Publish == true)
                .OrderByDescending(x => x.Date)
                .ThenBy(x => x.SortOrder)
                .Take(4)
                .ToListAsync();

            var setting = await _context.Settings.FirstOrDefaultAsync();
            var suppersetting = await _context.SuperSettings.FirstOrDefaultAsync();

            ViewBag.sxt = setting;
            ViewBag.suppersetting = suppersetting;

            return View(blog);
        }
    }
}