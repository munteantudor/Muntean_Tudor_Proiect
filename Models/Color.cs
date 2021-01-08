using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muntean_Tudor_Proiect.Models
{
    public class Color
    {
        public int ID { get; set; }
        public string ColorName { get; set; }
        public ICollection<Vinyl> VinylRecords { get; set; } //navigation property
    }
}
