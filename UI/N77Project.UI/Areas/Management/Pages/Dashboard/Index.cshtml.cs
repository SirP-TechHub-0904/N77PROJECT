using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebUI.Areas.Management.Pages.Dashboard
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "SuperAdmin")]

    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
