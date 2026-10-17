using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Pages.Shared.ViewComponents
{
    public class UserNavigationViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public UserNavigationViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userCategory = await _context.UserCategories.ToListAsync();
            
            ViewBag.userCategory = userCategory;
             return View();
        }
    }
}
