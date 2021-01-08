using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Muntean_Tudor_Proiect.Data;
using Muntean_Tudor_Proiect.Models;

namespace Muntean_Tudor_Proiect.Pages.VinylRecords
{
    public class CreateModel : VinylCategoriesPageModel
    {
        private readonly Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext _context;

        public CreateModel(Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ColorID"] = new SelectList(_context.Set<Color>(), "ID", "ColorName");

            var vinyl = new Vinyl();
            vinyl.VinylCategories = new List<VinylCategory>();
            PopulateAssignedCategoryData(_context, vinyl);

            return Page();
        }

        [BindProperty]
        public Vinyl Vinyl { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newVinyl = new Vinyl();
            if (selectedCategories != null)
            {
                newVinyl.VinylCategories = new List<VinylCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new VinylCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newVinyl.VinylCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Vinyl>(
            newVinyl,
            "Vinyl",
            i => i.Album, i => i.Artist,
            i => i.Price, i => i.PublishingDate, i => i.ColorID))
            {
                _context.Vinyl.Add(newVinyl);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newVinyl);
            return Page();
        }

       
    }
}
