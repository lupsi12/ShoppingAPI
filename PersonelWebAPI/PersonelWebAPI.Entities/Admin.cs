﻿using PersonelWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonelWebAPI.Entities
{
    public class Admin:BaseEntity
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public Roles Role { get; set; }
        //adminin birden çok personeli olmalı
        // Navigation property defined with [InverseProperty]
        [JsonIgnore]
        [InverseProperty(nameof(Personel.Admin))]
        public ICollection<Personel> Personels { get; set; } // Navigation
        //adminin birden çok suppileri olmalı
        [JsonIgnore]
        [InverseProperty(nameof(Supplier.Admin))]                                                     // 
        public ICollection<Supplier> Suppliers { get; set; }

    }
}
