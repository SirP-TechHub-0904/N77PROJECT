// File: Pages/Shared/ViewComponents/ProductHomeViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class ProductHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductHomeViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync();
            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

            ViewBag.setting = setting;
            ViewBag.suppersetting = supersetting;

            var products = await _context.Products
                .Include(x => x.ProductFeatures)
                .Where(x => x.ShowInHome)
                .OrderBy(x => x.SortOrder)
                .Take(6)
                .ToListAsync();

            return View(products);
        }
    }
}
