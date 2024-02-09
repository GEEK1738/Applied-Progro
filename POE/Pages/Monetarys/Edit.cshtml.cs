using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE.Data;
using POE.NewFolder;

namespace POE.Pages.Monetarys
{
    public class EditModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public EditModel(POE.Data.POEContext context)
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

            var monetary =  await _context.Monetary.FirstOrDefaultAsync(m => m.Id == id);
            if (monetary == null)
            {
                return NotFound();
            }
            Monetary = monetary;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Monetary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonetaryExists(Monetary.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MonetaryExists(int id)
        {
          return (_context.Monetary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
