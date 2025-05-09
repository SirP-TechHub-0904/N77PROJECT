// File: Pages/Shared/ViewComponents/HomeTestimonyViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class HomeTestimonyViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public HomeTestimonyViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonies = await _context.Testimonies
                .Where(x => x.Show)
                .OrderBy(x => x.SortOrder)
                .Take(4)
                .ToListAsync();

            var setting = await _context.Settings.FirstOrDefaultAsync();
            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

            ViewBag.sxt = setting;
            ViewBag.suppersetting = supersetting;

            return View(testimonies);
        }
    }
}
