

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JurayUniversal.Pages.Shared.ViewComponents
{
    public class LoginCSSViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public LoginCSSViewComponent(
            AppDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var supersetting = await _context.DataConfigs.FirstOrDefaultAsync();
            ViewBag.Login = supersetting.LoginCSS;
            return View();
        }
    }
}
