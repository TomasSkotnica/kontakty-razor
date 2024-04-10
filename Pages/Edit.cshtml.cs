using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kontakty.Data;
using kontakty.Models;

namespace kontakty.Pages
{
    public class EditModel : PageModel
    {
        private readonly kontakty.Data.KontaktyContext _context;

        public EditModel(kontakty.Data.KontaktyContext context)
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

            var kontakt =  await _context.Kontakt.FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }
            Kontakt = kontakt;
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

            _context.Attach(Kontakt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontaktExists(Kontakt.Id))
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

        private bool KontaktExists(int id)
        {
            return _context.Kontakt.Any(e => e.Id == id);
        }
    }
}
