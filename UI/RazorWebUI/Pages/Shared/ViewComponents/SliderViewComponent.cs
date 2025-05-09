// File: Pages/Shared/ViewComponents/SliderViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public SliderViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slider = await _context.Sliders
                .Where(x => x.Show)
                .OrderBy(x => x.SortOrder)
                .Take(4)
                .ToListAsync();

            var setting = await _context.Settings.FirstOrDefaultAsync();
            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();

            ViewBag.setting = setting;
            ViewBag.superx = supersetting;

            var pages = await _context.PageCategories
                .Include(x => x.WebPages)
                .Where(x => x.Publish)
                .OrderBy(x => x.MenuSortOrder)
                .ToListAsync();
            ViewBag.pages = pages;

            var singlePages = await _context.WebPages
                .Where(x => x.Publish && x.ShowInMainMenu)
                .ToListAsync();
            ViewBag.singlePages = singlePages;

            var topPages = await _context.WebPages
                .Where(x => x.Publish && x.ShowInMainTop)
                .ToListAsync();
            ViewBag.topPages = topPages;

            var linkExternal = await _context.WebPages
                .Where(x => x.Publish && x.ShowInMainTop && x.EnableDirectUrl)
                .ToListAsync();
            ViewBag.linkExternal = linkExternal;

            var productPage = await _context.ProductCategories
                .Where(x => x.Publish)
                .ToListAsync();
            ViewBag.productpage = productPage;

            var blogCategory = await _context.BlogCategories
                .Where(x => x.Publish)
                .ToListAsync();
            ViewBag.blogcategory = blogCategory;

            return View(slider);
        }
    }
}
