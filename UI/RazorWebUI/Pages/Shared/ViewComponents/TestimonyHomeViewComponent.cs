
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages.Shared.ViewComponents
{
    public class TestimonyHomeViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public TestimonyHomeViewComponent(
            AppDbContext context)
        {
            _context = context;
        }

        public string UserInfo { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var testimony = await _context.Testimonies.Where(x => x.Show == true).OrderBy(x => x.SortOrder).Take(10).ToListAsync();
            var setting = await _context.Settings.FirstOrDefaultAsync();
            var suppersetting = await _context.SuperSettings.FirstOrDefaultAsync();
            ViewBag.sxt = setting;
            ViewBag.suppersetting = suppersetting;
            return View(testimony);
        }
    }
}
