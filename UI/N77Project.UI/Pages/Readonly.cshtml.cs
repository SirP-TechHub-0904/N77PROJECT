using BackendApplication.Application.Commands.IdentityCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebUI.Pages
{
    public class ReadonlyModel : PageModel
    {
        private readonly IMediator _mediator;

        public ReadonlyModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {

            try
            {
                AdminSeedAndRole Command = new AdminSeedAndRole();
                await _mediator.Send(Command);
                TempData["success"] = "Success";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "error";
                return RedirectToPage("./Index");

            }
        }
    }
}
