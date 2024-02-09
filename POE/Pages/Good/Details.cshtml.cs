using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POE.Data;
using POE.NewFolder;

namespace POE.Pages.Good
{
    public class DetailsModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public DetailsModel(POE.Data.POEContext context)
        {
            _context = context;
        }

      public Goods Goods { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.FirstOrDefaultAsync(m => m.Id == id);
            if (goods == null)
            {
                return NotFound();
            }
            else 
            {
                Goods = goods;
            }
            return Page();
        }
    }
}
