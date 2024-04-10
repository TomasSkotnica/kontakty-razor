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
    public class DeleteModel : PageModel
    {
        private readonly kontakty.Data.KontaktyContext _context;

        public DeleteModel(kontakty.Data.KontaktyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kontakt Kontakt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakt.FirstOrDefaultAsync(m => m.Id == id);

            if (kontakt == null)
            {
                return NotFound();
            }
            else
            {
                Kontakt = kontakt;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakt.FindAsync(id);
            if (kontakt != null)
            {
                Kontakt = kontakt;
                _context.Kontakt.Remove(Kontakt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
