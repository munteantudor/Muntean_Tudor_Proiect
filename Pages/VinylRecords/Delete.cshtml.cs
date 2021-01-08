using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muntean_Tudor_Proiect.Data;
using Muntean_Tudor_Proiect.Models;

namespace Muntean_Tudor_Proiect.Pages.VinylRecords
{
    public class DeleteModel : PageModel
    {
        private readonly Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext _context;

        public DeleteModel(Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vinyl Vinyl { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vinyl = await _context.Vinyl.FirstOrDefaultAsync(m => m.ID == id);

            if (Vinyl == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vinyl = await _context.Vinyl.FindAsync(id);

            if (Vinyl != null)
            {
                _context.Vinyl.Remove(Vinyl);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
