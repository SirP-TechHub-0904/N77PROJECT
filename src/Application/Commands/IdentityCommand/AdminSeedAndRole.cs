using Application.Services;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BackendApplication.Application.Commands.IdentityCommands
{
    public sealed class AdminSeedAndRole : IRequest
    {
         
    }
    public class AdminSeedAndRoleHandler : IRequestHandler<AdminSeedAndRole>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminSeedAndRoleHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Handle(AdminSeedAndRole request, CancellationToken cancellationToken)
        {
            try
            {
                AppRole role = new AppRole
                {
                    Name = "SuperAdmin"
                };

                await _roleManager.CreateAsync(role);

            }
            catch (Exception ex) { }

            try
            {
                AppRole role = new AppRole
                {
                    Name = "Admin"
                };

                await _roleManager.CreateAsync(role);

            }
            catch (Exception ex) { }

            //try
            //{
            //    AppRole role = new AppRole
            //    {
            //        Name = "SuperAgent"
            //    };

            //    await _roleManager.CreateAsync(role);

            //}
            //catch (Exception ex) { }

            //try
            //{
            //    AppRole role = new AppRole
            //    {
            //        Name = "Seller"
            //    };

            //    await _roleManager.CreateAsync(role);

            //}
            //catch (Exception ex) { }
            //try
            //{
            //    AppRole role = new AppRole
            //    {
            //        Name = "Enforcement"
            //    };

            //    await _roleManager.CreateAsync(role);

            //}
            //catch (Exception ex) { }
            var user = new AppUser
            {
                UserName = "admin774@nutrition77.ng",
                Email = "admin774@nutrition77.ng",
                PhoneNumber = "00000000",
                FirstName = "Admin",
                LastName = "Account",
                MiddleName = "Secured",
                Date = DateTime.UtcNow.AddHours(1),
                Role = "",
                ResetPassword = false,
                TempPass = "",
                UpdateEducation = false,
                UpdateExperience = false,
                LockoutEnabled = false,
                UpdateProfile = false,
                UserStatus = EnumStatus.UserStatus.Active,
                PlaceOfWork = "",
            };

            var result = await _userManager.CreateAsync(user, (System.Environment.GetEnvironmentVariable("ADMIN_SEED_PASSWORD") ?? ""));
            if (result.Succeeded)
            {
                 
                try
                {
                    await _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
                catch (Exception x) { }

                try {
                    
                    }catch(Exception c) { }
            }
            else
            {
                
            }

             
        }
    }

}
