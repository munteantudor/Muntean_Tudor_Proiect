using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Muntean_Tudor_Proiect.Data;
using Muntean_Tudor_Proiect.Models;

namespace Muntean_Tudor_Proiect.Pages.Colors
{
    public class IndexModel : PageModel
    {
        private readonly Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext _context;

        public IndexModel(Muntean_Tudor_Proiect.Data.Muntean_Tudor_ProiectContext context)
        {
            _context = context;
        }

        public IList<Color> Color { get;set; }

        public async Task OnGetAsync()
        {
            Color = await _context.Color.ToListAsync();
        }
    }
}
