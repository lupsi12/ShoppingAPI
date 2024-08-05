using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelWebAPI.Entities;

public class Product : BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; }
    // [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    public string Description { get; set; }
    [Required(ErrorMessage = "Stock is required")]
    public int Stock { get; set; }
    [Required(ErrorMessage = "Price is required")]
    public int Price { get; set; }
    //productın bir categorysi olmalı

    [ForeignKey("Category")] // Foreign key attribute
    public int CategoryId { get; set; } // Foreign key

    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(Category.Products))]
    public Category Category { get; set; } // Navigation property
    
    
    //personelin bir Supplierı olmalı

    [ForeignKey("Supplier")] // Foreign key attribute
    public int SupplierId { get; set; } // Foreign key

    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(Supplier.Products))]
    public Supplier Supplier { get; set; } // Navigation property
        
    
    //cartın birden çok cartdetaili olabilir
    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(CartDetail.Product))]
    public ICollection<CartDetail> CartDetails { get; set; } // Navigation property
    
}