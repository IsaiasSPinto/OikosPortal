using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OikosPortal.Pages
{
    [Authorize]
    public class StreamingModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
