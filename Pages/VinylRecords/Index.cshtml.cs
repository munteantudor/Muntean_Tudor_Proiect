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
    public class IndexModel : PageModel
    {
        private readonly Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext _context;

        public IndexModel(Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext context)
        {
            _context = context;
        }

        public IList<Vinyl> Vinyl { get;set; }
        public VinylData VinylD { get; set; }
        public int VinylID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            VinylD = new VinylData();

            VinylD.VinylRecords = await _context.Vinyl
            .Include(b => b.Color)
            .Include(b => b.VinylCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Album)
            .ToListAsync();
            if (id != null)
            {
                VinylID = id.Value;
                Vinyl vinyl = VinylD.VinylRecords
                .Where(i => i.ID == id.Value).Single();
                VinylD.Categories = vinyl.VinylCategories.Select(s => s.Category);
            }
        }

      
    }
}
