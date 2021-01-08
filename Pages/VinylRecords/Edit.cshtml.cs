using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Muntean_Tudor_Proiect.Data;
using Muntean_Tudor_Proiect.Models;

namespace Muntean_Tudor_Proiect.Pages.VinylRecords
{
    public class EditModel : VinylCategoriesPageModel

    {
        private readonly Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext _context;

        public EditModel(Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext context)
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
            Vinyl = await _context.Vinyl
            .Include(b => b.Color)
            .Include(b => b.VinylCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Vinyl == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData
            PopulateAssignedCategoryData(_context, Vinyl);
            ViewData["ColorID"] = new SelectList(_context.Color, "ID",
           "ColorName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
       selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var VinylToUpdate = await _context.Vinyl
            .Include(i => i.Color)
            .Include(i => i.VinylCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (VinylToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Vinyl>(
            VinylToUpdate,
            "Vinyl",
            i => i.Album, i => i.Artist,
            i => i.Price, i => i.PublishingDate, i => i.Color))
            {
                UpdateVinylCategories(_context, selectedCategories, VinylToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateVinylCategories pentru a aplica informatiile din checkboxuri la entitatea Vinyls care
            //este editata
            UpdateVinylCategories(_context, selectedCategories, VinylToUpdate);
            PopulateAssignedCategoryData(_context, VinylToUpdate);
            return Page();
        }
    }
}

