using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POE.Data;
using POE.Model;

namespace POE.Pages.Alerts
{
    public class EditModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public EditModel(POE.Data.POEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Alert Alert { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alert == null)
            {
                return NotFound();
            }

            var alert =  await _context.Alert.FirstOrDefaultAsync(m => m.Id == id);
            if (alert == null)
            {
                return NotFound();
            }
            Alert = alert;
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

            _context.Attach(Alert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertExists(Alert.Id))
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

        private bool AlertExists(int id)
        {
          return (_context.Alert?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
