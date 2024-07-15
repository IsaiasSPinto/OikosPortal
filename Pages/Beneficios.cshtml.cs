using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OikosPortal.Pages
{
    [Authorize(Roles = "Assinante")]
    public class BeneficiosModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
