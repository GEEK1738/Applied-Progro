using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using POE.Data;
using POE.NewFolder;

namespace POE.Pages.Monetarys
{
    public class CreateModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public CreateModel(POE.Data.POEContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Monetary Monetary { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Monetary == null || Monetary == null)
            {
                return Page();
            }

            _context.Monetary.Add(Monetary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
