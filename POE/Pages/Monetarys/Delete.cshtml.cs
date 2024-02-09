using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using POE.Data;
using POE.NewFolder;

namespace POE.Pages.Monetarys
{
    public class DeleteModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public DeleteModel(POE.Data.POEContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Monetary Monetary { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Monetary == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetary.FirstOrDefaultAsync(m => m.Id == id);

            if (monetary == null)
            {
                return NotFound();
            }
            else 
            {
                Monetary = monetary;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Monetary == null)
            {
                return NotFound();
            }
            var monetary = await _context.Monetary.FindAsync(id);

            if (monetary != null)
            {
                Monetary = monetary;
                _context.Monetary.Remove(Monetary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
