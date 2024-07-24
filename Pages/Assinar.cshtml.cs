using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OikosPortal.Common;
using System.Security.Claims;

namespace OikosPortal.Pages
{
    [Authorize]
    public class AssinarModel : PageModel
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AssinarModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);

            await _userManager.AddToRoleAsync(user, ApplicationRoles.Assinante);
            await _userManager.AddClaimAsync(user, new Claim(ApplicationClaims.DataAssinatura, DateTime.UtcNow.ToString()));

            await _signInManager.RefreshSignInAsync(user);

            return RedirectToPage("/Index");
        }
    }
}
