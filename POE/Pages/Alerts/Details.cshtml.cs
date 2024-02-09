using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POE.Data;
using POE.Model;

namespace POE.Pages.Alerts
{
    public class DetailsModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public DetailsModel(POE.Data.POEContext context)
        {
            _context = context;
        }

      public Alert Alert { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alert == null)
            {
                return NotFound();
            }

            var alert = await _context.Alert.FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }
            else 
            {
                Alert = alert;
            }
            return Page();
        }
    }
}
