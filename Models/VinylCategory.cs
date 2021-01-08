using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muntean_Tudor_Proiect.Models
{
    public class VinylCategory
    {
        public int ID { get; set; }
        public int VinylID { get; set; }
        public Vinyl Vinyl { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
