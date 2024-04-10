using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using kontakty.Data;
using kontakty.Models;

namespace kontakty.Pages
{
    public class CreateModel : PageModel
    {
        private readonly kontakty.Data.KontaktyContext _context;

        public CreateModel(kontakty.Data.KontaktyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kontakt Kontakt { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kontakt.Add(Kontakt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
