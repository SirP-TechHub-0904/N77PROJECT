// File: Pages/Shared/ViewComponents/MenuViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public MenuViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
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
                .Where(x => x.Publish && x.ShowInMainMenu && x.EnableDirectUrl)
                .ToListAsync();
            ViewBag.linkExternal = linkExternal;

            var linkExternalDropdown = await _context.WebPages
                .Where(x => x.Publish && x.ShowInMenuDropDown && x.EnableDirectUrl)
                .ToListAsync();
            ViewBag.linkExternalDropdown = linkExternalDropdown;

            var productPage = await _context.ProductCategories
                .Where(x => x.Publish)
                .ToListAsync();
            ViewBag.productpage = productPage;

            var setting = await _context.Settings.FirstOrDefaultAsync();
            ViewBag.setting = setting;

            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();
            ViewBag.supersetting = supersetting;

            return View(setting);
        }
    }
}
