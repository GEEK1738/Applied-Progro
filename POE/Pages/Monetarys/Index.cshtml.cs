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
    public class IndexModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public IndexModel(POE.Data.POEContext context)
        {
            _context = context;
        }

        public IList<Monetary> Monetary { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Monetary != null)
            {
                Monetary = await _context.Monetary.ToListAsync();
            }
        }
    }
}
