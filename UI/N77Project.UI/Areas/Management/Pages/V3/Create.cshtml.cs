using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorWebUI.Areas.Management.Pages.V3
{
    public class CreateModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _role;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<CreateModel> _logger;
        private readonly AppDbContext _context;


        public CreateModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> role,
        ILogger<CreateModel> logger,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _role = role;
            _context = context;
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnGetAsync()
        {
            //var se = await _context.SuperSettings.FirstOrDefaultAsync();
            //if (se == null)
            //{
            //    SuperSetting SuperSetting = new SuperSetting();
            //    _context.SuperSettings.Add(SuperSetting);
            //    Setting s = new Setting();

            //    _context.Settings.Add(s);
                //DataConfig fig = new DataConfig();
                //_context.DataConfigs.Add(fig);
 
                //await _context.SaveChangesAsync();

                var user = new AppUser
                {
                    UserName = "universal@juray.io",
                    Email = "universal@juray.io",
                    PhoneNumber = "000",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    UserStatus = EnumStatus.UserStatus.Active,
                    TempPass=""

                };



                user.Id = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user, (System.Environment.GetEnvironmentVariable("ADMIN_SEED_PASSWORD") ?? ""));
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    AppRole Role = new AppRole("SuperAdmin");
                    var checkrole = await _role.FindByNameAsync("SuperAdmin");
                    if (checkrole == null)
                    {
                        await _role.CreateAsync(Role);

                    }
                    //
                    AppRole Manager = new AppRole("Manager");
                    var checkManager = await _role.FindByNameAsync("Manager");
                    if (checkManager == null)
                    {
                        await _role.CreateAsync(Manager);

                    }
                    //
                    AppRole Managerf = new AppRole("Finance");
                    var checkManagerf = await _role.FindByNameAsync("Finance");
                    if (checkManagerf == null)
                    {
                        await _role.CreateAsync(Managerf);

                    }
                    //
                    AppRole Security = new AppRole("Security");
                    var checkSecurity = await _role.FindByNameAsync("Security");
                    if (checkSecurity == null)
                    {
                        await _role.CreateAsync(Security);

                    }
                    //
                    AppRole JAdmin = new AppRole("SubAdmin");
                    var checkJAdmin = await _role.FindByNameAsync("SubAdmin");
                    if (checkJAdmin == null)
                    {
                        await _role.CreateAsync(JAdmin);

                    }
                     
                    AppRole xRole = new AppRole("Editor");
                    var xcheckrole = await _role.FindByNameAsync("Editor");

                    if (xcheckrole == null)
                    {
                        await _role.CreateAsync(xRole);

                    }
                    AppRole xstaffUser = new AppRole("Staff");
                    var staffUser = await _role.FindByNameAsync("Staff");
                    if (staffUser == null)
                    {
                        await _role.CreateAsync(xstaffUser);

                    }
                    AppRole AdminRole = new AppRole("Admin");
                    var checkAdminRole = await _role.FindByNameAsync("Admin");
                    if (checkAdminRole == null)
                    {
                        await _role.CreateAsync(AdminRole);

                    }
                    AppRole User = new AppRole("User");
                    var checkUser = await _role.FindByNameAsync("User");
                    if (checkUser == null)
                    {
                        await _role.CreateAsync(User);

                    }
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            //}
            return RedirectToPage("./Index");
        }
    }
}
