using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelWebAPI.Entities;

public class CartDetail : BaseEntity
{
    //cartdetailin bir cartı olmalı

    [ForeignKey("Cart")] // Foreign key attribute
    public int CartId { get; set; } // Foreign key
    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(Cart.CartDetails))]
    public Cart Cart { get; set; } // Navigation property
    //cartdetailin bir productı olmalı

    [ForeignKey("Product")] // Foreign key attribute
    public int ProductId { get; set; } // Foreign key
    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(Product.CartDetails))]
    public Product Product { get; set; } // Navigation property
    [Required] 
    public int InstantPrice { get; set; } 
    
}