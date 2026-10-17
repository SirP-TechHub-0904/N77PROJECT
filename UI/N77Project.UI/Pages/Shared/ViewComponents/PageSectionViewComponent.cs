// File: Pages/Shared/ViewComponents/PageSectionViewComponent.cs

using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class PageSectionViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public PageSectionViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? position, string? pageset, long? id, long? secid, int? takex)
        {
            int takeLimit = takex == 3 ? 3 : 300;
            ViewBag.take3 = takeLimit;
            ViewBag.pageset = pageset;

            var setting = await _context.SuperSettings.FirstOrDefaultAsync();
            ViewBag.themedata = setting?.TemplateLayoutKey;

            var pageQuery = _context.PageSections
                .Include(x => x.PageSectionLists)
                .Where(x => !x.Disable)
                .AsQueryable();
            if (!string.IsNullOrEmpty(pageset))
            {
                pageQuery = pageQuery
                        .Where(x => x.ShowInHome)
                        .OrderBy(x => x.HomePageSortOrder);
            }
            else if (!string.IsNullOrEmpty(position) && !string.IsNullOrEmpty(pageset))
            {
                if (position.ToLower() == "top" && pageset.ToLower() == "home")
                {
                    pageQuery = pageQuery
                        .Where(x => x.ShowInHome && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Top)
                        .OrderBy(x => x.HomePageSortOrder);
                }
                else if (position.ToLower() == "bottom" && pageset.ToLower() == "home")
                {
                    pageQuery = pageQuery
                        .Where(x => x.ShowInHome && x.HomeSortFrom == Domain.Models.EnumStatus.HomeSortFrom.Bottom)
                        .OrderBy(x => x.HomePageSortOrder);
                }
            }
            else if (!string.IsNullOrEmpty(position))
            {
                if (position.ToLower() == "fixed" || position.ToLower() == "footer")
                {
                    pageQuery = pageQuery
                        .Where(x => x.FixedAfterFooter)
                        .OrderBy(x => x.HomePageSortOrder);
                }
            }
            else if (string.IsNullOrEmpty(position) && id.HasValue && id > 0)
            {
                pageQuery = pageQuery
                    .Where(x => x.WebPageId == id)
                    .OrderBy(x => x.PageSortOrder);
            }
            else if (string.IsNullOrEmpty(position) && secid.HasValue && secid > 0)
            {
                pageQuery = pageQuery
                    .Where(x => x.Id == secid)
                    .OrderBy(x => x.PageSortOrder);
            }
            else
            {
                pageQuery = pageQuery
                    .Where(x => x.WebPageId == 0); // fallback if nothing matches
            }

            //var pageSections = await pageQuery.Take(takeLimit).ToListAsync();
            var pageSections = await pageQuery.ToListAsync();

            return View(pageSections);
        }
    }
}
