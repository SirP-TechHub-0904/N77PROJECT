
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.Content.Pages.IBlogs.Post
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin,Editor")]

    public class PostListModel : PageModel
    {
        private readonly AppDbContext _context;

        public PostListModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get; set; }

        public async Task OnGetAsync(long id)
        {
            Blog = await _context.Blogs
                .Include(b => b.BlogCategory).Where(x=>x.BlogCategoryId == id).ToListAsync();
        }
    }
}
