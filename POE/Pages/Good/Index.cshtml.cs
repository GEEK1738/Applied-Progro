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
    public class IndexModel : PageModel
    {
        private readonly POE.Data.POEContext _context;

        public IndexModel(POE.Data.POEContext context)
        {
            _context = context;
        }

        public IList<Goods> Goods { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Goods != null)
            {
                Goods = await _context.Goods.ToListAsync();
            }
        }
    }
}
