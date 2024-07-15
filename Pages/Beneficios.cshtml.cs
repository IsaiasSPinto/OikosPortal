using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OikosPortal.Pages
{
    [Authorize]
    public class BeneficiosModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
