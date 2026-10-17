// File: Pages/Shared/ViewComponents/FooterViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string key)
        {
            var mainWebPages = await _context.WebPages.ToListAsync();

            var pages = mainWebPages
                .Where(x => x.Publish && x.ShowInFooter && !x.SecurityPage && !x.EnableDirectUrl)
                .OrderBy(x => x.SortOrder)
                .ToList();
            ViewBag.pages = pages;

            var secPages = mainWebPages
                .Where(x => x.Publish && x.ShowInFooter && x.SecurityPage)
                .OrderBy(x => x.SortOrder)
                .ToList();
            ViewBag.SecPages = secPages;

            var linkExternal = mainWebPages
                .Where(x => x.Publish && x.ShowInFooter && x.EnableDirectUrl)
                .ToList();
            ViewBag.linkExternal = linkExternal;

            var setting = await _context.Settings.FirstOrDefaultAsync();
            ViewBag.setting = setting;

            var supersetting = await _context.SuperSettings.FirstOrDefaultAsync();
            ViewBag.supersetting = supersetting;

            return View();
        }
    }
}
