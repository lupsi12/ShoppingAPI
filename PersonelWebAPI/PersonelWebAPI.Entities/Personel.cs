using PersonelWebAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelWebAPI.Entities
{
    public class Personel:BaseEntity
    {
      
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Birth date is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        //public List<string> Addresses { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public Roles Role { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }
        //personelin bir admini olmalı

        [ForeignKey("Admin")] // Foreign key attribute
        public int AdminId { get; set; } // Foreign key

        // Navigation property defined with [InverseProperty]
        [InverseProperty(nameof(Admin.Personels))]
        public Admin Admin { get; set; } // Navigation property
        
        //personelin birden çok addresi olabilir
        // Navigation property defined with [InverseProperty]
        [InverseProperty(nameof(Addres.Personel))]
        public ICollection<Addres> Addresses { get; set; } // Navigation property
        //personelin birden çok cartsı olabilir
        // Navigation property defined with [InverseProperty]
        [InverseProperty(nameof(Cart.Personel))]
        public ICollection<Cart> Carts { get; set; } // Navigation property
    }
}
