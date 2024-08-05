using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelWebAPI.Entities;

public class Category:BaseEntity
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; }
    // [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    public string Description { get; set; }
    //categorynin birden çok productsı olabilir
    // Navigation property defined with [InverseProperty]
    [InverseProperty(nameof(Product.Category))]
    public ICollection<Product> Products { get; set; } // Navigation property
}