using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Entities
{
    public class Addres:BaseEntity
    {
        [ForeignKey("Personel")] // Foreign key attribute
        public int PersonelId { get; set; } // Foreign key

        // Navigation property defined with [InverseProperty]
        [InverseProperty(nameof(Personel.Addresses))]
        public Personel Personel { get; set; } // Navigation property
        [Required (ErrorMessage = "Addres is required")]
        public string Address { get; set; }
    }
}
