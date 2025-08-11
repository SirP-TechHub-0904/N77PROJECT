using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.User.Pages.UserGroupPage
{
    public class GroupListsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        public GroupListsModel(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [BindProperty]
        public IFormFile ExcelFile { get; set; }

        public UserCategory UserCategory { get; set; }
        public List<UserCategoryGroup> UserList { get; set; }

        public async Task<IActionResult> OnGetAsync(long id)
        {
            UserCategory = await _context.UserCategories.FindAsync(id);
            if (UserCategory == null) return NotFound();

            UserList = await _context.UserCategoryGroups
                .Include(x => x.User)
                .Where(x => x.UserCategoryId == id)
                .ToListAsync();

            return Page();
        }

    }
}
