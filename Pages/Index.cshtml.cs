using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using kontakty.Data;
using kontakty.Models;

namespace kontakty.Pages
{
    public class IndexModel : PageModel
    {
        private readonly kontakty.Data.KontaktyContext _context;

        public IndexModel(kontakty.Data.KontaktyContext context)
        {
            _context = context;
        }

        public IList<Kontakt> Kontakt { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Kontakt = await _context.Kontakt.ToListAsync();
        }
    }
}
