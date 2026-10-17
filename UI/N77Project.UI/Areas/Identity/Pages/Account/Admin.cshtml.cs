using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RazorWebUI.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AdminModel : PageModel
    {


        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AdminModel> _logger;
        private readonly AppDbContext _context;

        public AdminModel(SignInManager<AppUser> signInManager,
            ILogger<AdminModel> logger,
            UserManager<AppUser> userManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        public string TemplateLogin { get; set; }

        [BindProperty]
        public SuperSetting SuperSetting { get; set; }

        [BindProperty]
        public Setting Setting { get; set; }
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            Setting = await _context.Settings.FirstOrDefaultAsync();
            
            TemplateLogin = SuperSetting.LoginTemplateKey;
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            var setting = await _context.SuperSettings.FirstOrDefaultAsync();


            //if (ModelState.IsValid)
            //{
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            //var userss = await _context.Users.ToListAsync();
            //var xuser = await _context.Users.FirstOrDefaultAsync(x=>x.Email == Input.Email);
            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user != null)
            {

                var passcheck = await _userManager.CheckPasswordAsync(user, Input.Password);
                //if (passcheck == true && user.LockoutEnabled == true)
                //{

                //    _logger.LogWarning("User with ID '{UserId}' account locked out.", user.Id);
                //    return RedirectToPage("/Account/Lockout", new { area = "Identity" });

                //}
                if (passcheck == true && user.TwoFactorEnabled == true)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {

                        return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("/Account/LoginWith2fa", new { area = "Identity", ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
                        Setting = await _context.Settings.FirstOrDefaultAsync();
                        return Page();
                    }
                }
                else if (passcheck == true)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var superrole = await _userManager.IsInRoleAsync(user, "SuperAdmin");
                    var SubAdmin = await _userManager.IsInRoleAsync(user, "SubAdmin");
                    var adminrole = await _userManager.IsInRoleAsync(user, "Admin");
                    var editorrole = await _userManager.IsInRoleAsync(user, "Editor");
                    var managerrole = await _userManager.IsInRoleAsync(user, "Manager");
                    var administrator = await _userManager.IsInRoleAsync(user, "Administrator");
                    var useracc = await _userManager.IsInRoleAsync(user, "User");
                
                        if (superrole.Equals(true))
                        {
                            return RedirectToPage("/Major/Index", new { area = "Dashboard" });
                        }
                         

                        returnUrl = returnUrl ?? Url.Content("~/");
                     

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
                    Setting = await _context.Settings.FirstOrDefaultAsync();
                    return Page();
                }
            }
            else
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
                Setting = await _context.Settings.FirstOrDefaultAsync();
                return Page();
            }
            SuperSetting = await _context.SuperSettings.FirstOrDefaultAsync();
            Setting = await _context.Settings.FirstOrDefaultAsync();
            // If we got this far, something failed, redisplay form
            return Page();
        }



    }
}
