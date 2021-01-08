using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muntean_Tudor_Proiect.Models;

namespace Muntean_Tudor_Proiect.Data
{
    public class Muntean_Tudor_ProiectContext : DbContext
    {
        public Muntean_Tudor_ProiectContext (DbContextOptions<Muntean_Tudor_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Muntean_Tudor_Proiect.Models.Vinyl> Vinyl { get; set; }

        public DbSet<Muntean_Tudor_Proiect.Models.Color> Color { get; set; }

        public DbSet<Muntean_Tudor_Proiect.Models.Category> Category { get; set; }
    }
}
