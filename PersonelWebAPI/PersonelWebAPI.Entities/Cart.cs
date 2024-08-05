using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PersonelWebAPI.Enums;

namespace PersonelWebAPI.Entities;

public class Cart : BaseEntity
{
    //CARTIN bir personeli olmalı

    [ForeignKey("Personel")] // Foreign key attribute
    public int PersonelId { get; set; } // Foreign key

    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(Personel.Carts))]
    public Personel Personel { get; set; } // Navigation property
    [Required(ErrorMessage = "CartStatus is required")]
    public CartStatus CartStatus { get; set; }
    
    
    
    //cartın birden çok cartdetaili olabilir
    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(CartDetail.Cart))]
    public ICollection<CartDetail> CartDetails { get; set; } // Navigation property
    
    // Cart'ın bir Sale'i olabilir (One-to-one relation)
    public Sale Sale { get; set; }
}