using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace POE.Pages
{
    public class SendAlertModel : PageModel
    {
        public string SendAlert { get; set; }
        public string Allocate { get; set; }
        public string Monetarys { get; set; }
        public string Goods { get; set; }

        public void OnGet()
        {
        }
    }
}
