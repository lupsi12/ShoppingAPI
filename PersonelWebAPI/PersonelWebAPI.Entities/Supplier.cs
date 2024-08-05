using PersonelWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Entities
{
    public class Supplier : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name {get; set;}
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public Roles Role { get; set; }
        [Required(ErrorMessage = "Status is required")]

        public Status Status { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        [InverseProperty(nameof(Admin.Suppliers))]
        public Admin Admin { get; set; }
        
        //supplierın birden çok productsı olabilir
        // Navigation property defined with [InverseProperty]
        [InverseProperty(nameof(Product.Supplier))]
        public ICollection<Product> Products { get; set; } // Navigation property
    }
}
