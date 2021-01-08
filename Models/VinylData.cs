using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muntean_Tudor_Proiect.Models
{
    public class VinylData
    {
        public IEnumerable<Vinyl> VinylRecords { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<VinylCategory> VinylCategories { get; set; }
    }
}
