using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muntean_Tudor_Proiect.Models
{
    public class Vinyl
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Album Name")]
        public string Album { get; set; }
        public string Artist { get; set; }

        [Range(1, 400)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int ColorID { get; set; }
        public Color Color { get; set; }
        public ICollection<VinylCategory> VinylCategories { get; set; }
    } 

}
